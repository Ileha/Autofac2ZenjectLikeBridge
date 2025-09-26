using System;
using Autofac;
using Autofac.Core;
using JetBrains.Annotations;
using ZenAutofac.Interfaces.Builders.Decorator;

namespace ZenAutofac.Builders.Decorator
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

        public void ByFunction(Action<ContainerBuilder, TService> subScopeLoader)
        {
            Builder
                .RegisterDecorator<TService>(
                    (context, _, nestedService) => ResolveFromSubScope<TDecorator>(subScopeLoader, context, nestedService));
        }

        public void ByModule<TModule>(
            Func<ILifetimeScope, TService, TModule> moduleFactory = null)
            where TModule : class, IModule
        {
            Builder
                .RegisterDecorator<TService>(
                    (context, _, nestedService) => ResolveFromSubScopeModule<TDecorator, TModule>(context, nestedService, moduleFactory));
        }

        public void ByFunction(Action<ContainerBuilder, TService> subScopeLoader, object fromKey, object toKey = null)
        {
            Builder
                .RegisterDecorator<TService>(
                    (context, _, nestedService) => ResolveFromSubScope<TDecorator>(subScopeLoader, context, nestedService),
                    fromKey,
                    toKey);
        }

        public void ByModule<TModule>(
            object fromKey,
            object toKey = null,
            Func<ILifetimeScope, TService, TModule> moduleFactory = null)
            where TModule : class, IModule
        {
            Builder
                .RegisterDecorator<TService>(
                    (context, _, nestedService) => ResolveFromSubScopeModule<TDecorator, TModule>(context, nestedService, moduleFactory),
                    fromKey,
                    toKey);
        }

        private static TComponent ResolveFromSubScope<TComponent>(
            Action<ContainerBuilder, TService> subScopeLoader,
            IComponentContext context,
            TService nestedService)
            where TComponent : IDisposable
        {
            var scope = context.Resolve<ILifetimeScope>();
            return scope.ResolveFromSubScope<TService, TComponent>(subScopeLoader, nestedService);
        }

        private static TComponent ResolveFromSubScopeModule<TComponent, TModule>(
            IComponentContext context,
            TService nestedService,
            [CanBeNull] Func<ILifetimeScope, TService, TModule> moduleFactory = null)
            where TModule : class, IModule
            where TComponent : IDisposable
        {
            var scope = context.Resolve<ILifetimeScope>();
            return scope.ResolveFromSubScope<TService, TComponent, TModule>(nestedService, moduleFactory);
        }
    }
}