using System;
using Autofac;
using Autofac2ZenjectLikeBridge.Interfaces;
using Autofac2ZenjectLikeBridge.Interfaces.Builders.Decorator;
using JetBrains.Annotations;

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

        public void ByFunction(Action<ContainerBuilder, TService> subScopeInstaller)
        {
            Builder
                .RegisterDecorator<TService>(
                    (context, _, nestedService) => ResolveFromSubScope<TDecorator>(subScopeInstaller, context, nestedService));
        }

        public void ByInstaller<TInstaller>(
            Func<ILifetimeScope, ContainerBuilder, TService, TInstaller> installerFactory = null)
            where TInstaller : class, IInstaller
        {
            Builder
                .RegisterDecorator<TService>(
                    (context, _, nestedService) => ResolveFromSubScopeInstaller<TDecorator, TInstaller>(context, nestedService, installerFactory));
        }

        public void ByFunction(Action<ContainerBuilder, TService> subScopeInstaller, object fromKey, object toKey = null)
        {
            Builder
                .RegisterDecorator<TService>(
                    (context, _, nestedService) => ResolveFromSubScope<TDecorator>(subScopeInstaller, context, nestedService),
                    fromKey,
                    toKey);
        }

        public void ByInstaller<TInstaller>(
            object fromKey,
            object toKey = null,
            Func<ILifetimeScope, ContainerBuilder, TService, TInstaller> installerFactory = null)
            where TInstaller : class, IInstaller
        {
            Builder
                .RegisterDecorator<TService>(
                    (context, _, nestedService) => ResolveFromSubScopeInstaller<TDecorator, TInstaller>(context, nestedService, installerFactory),
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

        private static TComponent ResolveFromSubScopeInstaller<TComponent, TInstaller>(
            IComponentContext context,
            TService nestedService,
            [CanBeNull] Func<ILifetimeScope, ContainerBuilder, TService, TInstaller> installerFactory = null)
            where TInstaller : class, IInstaller
            where TComponent : IDisposable
        {
            var scope = context.Resolve<ILifetimeScope>();
            return scope.ResolveFromSubScope<TService, TComponent, TInstaller>(nestedService, installerFactory);
        }
    }
}