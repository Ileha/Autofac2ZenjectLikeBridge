using System;
using Autofac;
using Autofac.Builder;
using JetBrains.Annotations;

namespace Autofac2ZenjectLikeBridge.Interfaces.Builders.Instance
{
    public interface ISubScopeRegistrationBuilder<out TComponent> : IExtendedBuilderBase
        where TComponent : class, IDisposable
    {
        IRegistrationBuilder<
            TComponent,
            SimpleActivatorData,
            SingleRegistrationStyle> ByFunction(Action<ContainerBuilder> subScopeInstaller);

        IRegistrationBuilder<
            TComponent,
            SimpleActivatorData,
            SingleRegistrationStyle> ByInstaller<TInstaller>(
            [CanBeNull] Func<ILifetimeScope, ContainerBuilder, TInstaller> installerFactory = null)
            where TInstaller : class, IInstaller;
    }
}