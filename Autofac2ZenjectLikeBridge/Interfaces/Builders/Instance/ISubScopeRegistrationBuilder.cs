using System;
using Autofac;
using Autofac.Builder;

namespace Autofac2ZenjectLikeBridge.Interfaces.Builders.Instance
{
    public interface ISubScopeRegistrationBuilder<out TComponent> : IExtendedRegistrationBuilderBase
        where TComponent : class, IDisposable
    {
        IRegistrationBuilder<
            TComponent,
            SimpleActivatorData,
            SingleRegistrationStyle> FromFunction(Action<ContainerBuilder> subScopeInstaller);

        IRegistrationBuilder<
            TComponent,
            SimpleActivatorData,
            SingleRegistrationStyle> FromInstaller<TInstaller>(TInstaller installer)
            where TInstaller : class, IInstaller;
    }
}