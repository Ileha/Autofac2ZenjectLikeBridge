using System;
using Autofac;
using Autofac2ZenjectLikeBridge.Interfaces;
using Autofac2ZenjectLikeBridge.Interfaces.Builders.Decorator;

namespace Autofac2ZenjectLikeBridge.Builders.Decorator
{
    public class SubScopeDecoratorBuilder<TDecorator, TService> : ISubScopeDecoratorBuilder<TDecorator, TService>
        where TDecorator : TService, IDisposable
        where TService : class
    {
        public ContainerBuilder Builder { get; }

        public SubScopeDecoratorBuilder(ContainerBuilder builder)
        {
            Builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public void FromFunction(Action<ContainerBuilder, TService> subScopeInstaller)
        {
            Builder
                .RegisterDecorator<TService>(
                    (context, _, nestedService) => ResolveFromSubScope<TDecorator>(subScopeInstaller, context, nestedService));
        }

        public void FromInstaller<TInstaller>()
            where TInstaller : class, IInstaller
        {
            Builder
                .RegisterDecorator<TService>(
                    (context, _, nestedService) => ResolveFromSubScopeInstaller<TDecorator, TInstaller>(context, nestedService));
        }

        public void FromFunction(Action<ContainerBuilder, TService> subScopeInstaller, object fromKey, object toKey = null)
        {
            Builder
                .RegisterDecorator<TService>(
                    (context, _, nestedService) => ResolveFromSubScope<TDecorator>(subScopeInstaller, context, nestedService),
                    fromKey,
                    toKey);
        }

        public void FromInstaller<TInstaller>(object fromKey, object toKey = null)
            where TInstaller : class, IInstaller
        {
            Builder
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
            return scope.ResolveFromSubScope<TService, TComponent>(subScopeInstaller, nestedService);
        }

        private static TComponent ResolveFromSubScopeInstaller<TComponent, TInstaller>(IComponentContext context, TService nestedService)
            where TInstaller : class, IInstaller
            where TComponent : IDisposable
        {
            var scope = context.Resolve<ILifetimeScope>();
            return scope.ResolveFromSubScope<TService, TComponent, TInstaller>(nestedService);
        }
    }
}