using System;
using Autofac;
using Autofac.Builder;
using Autofac2ZenjectLikeBridge.Extensions.HarmonyPatcher;
using Autofac2ZenjectLikeBridge.Interfaces;
using Autofac2ZenjectLikeBridge.Interfaces.Builders;

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
                    (IComponentContext _, ILifetimeScope scope) =>
                    {
                        var guid = Guid.NewGuid();

                        var subScope = scope
                            .BeginLifetimeScope(
                                guid,
                                scopeBuilder =>
                                {
                                    scopeBuilder.OverrideExternallyOwnedInScope<TComponent>(guid);
                                    subScopeInstaller(scopeBuilder);
                                });

                        var service = subScope.Resolve<TComponent>();

                        subScope
                            .AddToHarmony(service);

                        return service;
                    });
        }

        public IRegistrationBuilder<TComponent, SimpleActivatorData, SingleRegistrationStyle> FromInstaller<TInstaller>(TInstaller installer)
            where TInstaller : class, IInstaller
        {
            return _builder
                .Register(
                    (IComponentContext _, ILifetimeScope scope) =>
                    {
                        var guid = Guid.NewGuid();

                        var subScope = scope
                            .BeginLifetimeScope(
                                guid,
                                scopeBuilder =>
                                {
                                    scopeBuilder.OverrideExternallyOwnedInScope<TComponent>(guid);
                                    var installerInstance = scope.CreateInstance<IInstaller>(scopeBuilder);
                                    installerInstance.Install();
                                });

                        var service = subScope.Resolve<TComponent>();

                        subScope
                            .AddToHarmony(service);

                        return service;
                    });
        }
    }
}