using System;
using Autofac;
using Autofac.Builder;
using Autofac.Core;
using Autofac2ZenjectLikeBridge.Interfaces.Builders.Instance;

namespace Autofac2ZenjectLikeBridge.Builders.Instance
{
    public class SubScopeRegistrationBuilder<TComponent>
        : ISubScopeRegistrationBuilder<TComponent>
        where TComponent : class, IDisposable
    {
        public ContainerBuilder Builder { get; }

        public SubScopeRegistrationBuilder(ContainerBuilder builder)
        {
            Builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public IRegistrationBuilder<TComponent, SimpleActivatorData, SingleRegistrationStyle> ByFunction(Action<ContainerBuilder> subScopeLoader)
        {
            return Builder
                .Register(
                    (IComponentContext _, ILifetimeScope scope)
                        => scope.ResolveFromSubScope<TComponent>(subScopeLoader));
        }

        public IRegistrationBuilder<TComponent, SimpleActivatorData, SingleRegistrationStyle> ByModule<TModule>(
            Func<ILifetimeScope, TModule> moduleFactory = null) where TModule : class, IModule
        {
            return Builder
                .Register(
                    (IComponentContext _, ILifetimeScope scope)
                        => scope.ResolveFromSubScope<TComponent, TModule>(moduleFactory));
        }
    }
}