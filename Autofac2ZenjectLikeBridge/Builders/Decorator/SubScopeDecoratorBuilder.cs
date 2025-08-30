using System;
using Autofac;
using Autofac2ZenjectLikeBridge.Extensions.HarmonyPatcher;
using Autofac2ZenjectLikeBridge.Interfaces;
using Autofac2ZenjectLikeBridge.Interfaces.Builders.Decorator;

namespace Autofac2ZenjectLikeBridge.Builders.Decorator
{
    public class SubScopeDecoratorBuilder<TDecorator, TService> : ISubScopeDecoratorBuilder<TDecorator, TService>
        where TDecorator : TService, IDisposable
    {
        private readonly ContainerBuilder _builder;

        public SubScopeDecoratorBuilder(ContainerBuilder builder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public void FromFunction(Action<ContainerBuilder, TService> subScopeInstaller)
        {
            _builder
                .RegisterDecorator<TService>(
                    (context, _, nestedService) => ResolveFromSubScope<TDecorator>(subScopeInstaller, context, nestedService),
                    // ReSharper disable once AssignNullToNotNullAttribute
                    null,
                    null);
        }

        public void FromInstaller<TInstaller>(TInstaller installer)
            where TInstaller : class, IInstaller
        {
            _builder
                .RegisterDecorator<TService>(
                    (context, _, nestedService) => ResolveFromSubScopeInstaller<TDecorator, TInstaller>(context, nestedService),
                    // ReSharper disable once AssignNullToNotNullAttribute
                    null,
                    null);
        }

        public void FromFunction(Action<ContainerBuilder, TService> subScopeInstaller, object fromKey, object toKey = null)
        {
            _builder
                .RegisterDecorator<TService>(
                    (context, _, nestedService) => ResolveFromSubScope<TDecorator>(subScopeInstaller, context, nestedService),
                    fromKey,
                    toKey);
        }

        public void FromInstaller<TInstaller>(TInstaller installer, object fromKey, object toKey = null)
            where TInstaller : class, IInstaller
        {
            _builder
                .RegisterDecorator<TService>(
                    (context, _, nestedService) => ResolveFromSubScopeInstaller<TDecorator, TInstaller>(context, nestedService),
                    fromKey,
                    toKey);
        }

        private static TComponent ResolveFromSubScope<TComponent>(
            Action<ContainerBuilder, TService> subScopeInstaller,
            IComponentContext context,
            TService nestedService)
            where TComponent : IDisposable
        {
            var scope = context.Resolve<ILifetimeScope>();
            var guid = Guid.NewGuid();

            var subScope = scope.BeginLifetimeScope(
                guid,
                subScopeBuilder =>
                {
                    subScopeBuilder.OverrideExternallyOwnedInScope<TComponent>(guid);
                    subScopeInstaller(subScopeBuilder, nestedService);
                });

            var instance = subScope.Resolve<TComponent>();

            subScope
                .AddToHarmony(instance);

            return instance;
        }

        private static TComponent ResolveFromSubScopeInstaller<TComponent, TInstaller>(IComponentContext context, TService nestedService)
            where TInstaller : class, IInstaller
            where TComponent : IDisposable
        {
            var scope = context.Resolve<ILifetimeScope>();
            var guid = Guid.NewGuid();

            var subScope = scope.BeginLifetimeScope(
                guid,
                subScopeBuilder =>
                {
                    subScopeBuilder.OverrideExternallyOwnedInScope<TComponent>(guid);
                    var installerInstance = scope.CreateInstance<TInstaller>(subScopeBuilder, nestedService);
                    installerInstance.Install();
                });

            var instance = subScope.Resolve<TComponent>();

            subScope
                .AddToHarmony(instance);

            return instance;
        }
    }
}