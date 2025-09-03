using Autofac.Builder;

namespace Autofac2ZenjectLikeBridge.Interfaces.Builders.Instance
{
    public interface IExtendedRegistrationBuilder<TComponent> : IExtendedBuilderBase
        where TComponent : class
    {
        IRegistrationBuilder<
            TComponent,
            SimpleActivatorData,
            SingleRegistrationStyle> FromInstance(TComponent instance);

        IRegistrationBuilder<
            TComponent,
            SimpleActivatorData,
            SingleRegistrationStyle> FromNewInstance();
    }
}