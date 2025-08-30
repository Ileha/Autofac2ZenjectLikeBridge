using System;

namespace Autofac2ZenjectLikeBridge.Interfaces.Builders.Instance
{
    public interface IExtendedRegistrationBuilder<in TComponent>
    {
        // IRegistrationBuilder<
        //     TComponent,
        //     SimpleActivatorData,
        //     SingleRegistrationStyle> FromInstance();
        //
        // IRegistrationBuilder<
        //     TComponent,
        //     SimpleActivatorData,
        //     SingleRegistrationStyle> FromNewInstance();

        ISubScopeBuilder<TComponentDisposable> FromSubScope<TComponentDisposable>()
            where TComponentDisposable : TComponent, IDisposable;
    }
}