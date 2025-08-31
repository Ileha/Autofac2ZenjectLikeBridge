using System;
using Autofac;
using Autofac.Builder;
using Autofac2ZenjectLikeBridge.Interfaces;
using Autofac2ZenjectLikeBridge.Interfaces.Builders.Instance;

namespace Autofac2ZenjectLikeBridge.Builders.Instance
{
    public class SubScopeBuilder<TComponent> : ISubScopeBuilder<TComponent>
        where TComponent : IDisposable
    {
        private readonly ContainerBuilder _builder;

        public SubScopeBuilder(ContainerBuilder builder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public IRegistrationBuilder<TComponent, SimpleActivatorData, SingleRegistrationStyle> FromFunction(Action<ContainerBuilder> subScopeInstaller)
        {
            return _builder
                .Register(
                    (IComponentContext _, ILifetimeScope scope)
                        => scope.ResolveFromSubScope<TComponent>(subScopeInstaller));
        }

        public IRegistrationBuilder<TComponent, SimpleActivatorData, SingleRegistrationStyle> FromInstaller<TInstaller>(TInstaller installer)
            where TInstaller : class, IInstaller
        {
            return _builder
                .Register(
                    (IComponentContext _, ILifetimeScope scope)
                        => scope.ResolveFromSubScope<TComponent, TInstaller>());
        }
    }
}