using System;
using Autofac;
using Autofac.Builder;

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
            SingleRegistrationStyle> ByInstaller<TInstaller>()
            where TInstaller : class, IInstaller;
    }
}