using System;
using Autofac;
using Autofac.Builder;

namespace Autofac2ZenjectLikeBridge.Interfaces.Builders.Factory
{
    //generated amount 10

    public interface ISubScopeFactoryBuilder<out TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TInstance : class, IDisposable
        where TFactory : IFactory<TInstance>
    {
        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> FromFunction(Action<ContainerBuilder> subScopeInstaller);

        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> FromInstaller<TInstaller>()
            where TInstaller : class, IInstaller;
    }

    public interface ISubScopeFactoryBuilder<TP0, out TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TInstance : class, IDisposable
        where TFactory : IFactory<TP0, TInstance>
    {
        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> FromFunction(Action<ContainerBuilder> subScopeInstaller);

        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> FromInstaller<TInstaller>()
            where TInstaller : class, IInstaller;
    }

    public interface ISubScopeFactoryBuilder<TP0, TP1, out TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TInstance : class, IDisposable
        where TFactory : IFactory<TP0, TP1, TInstance>
    {
        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> FromFunction(Action<ContainerBuilder> subScopeInstaller);

        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> FromInstaller<TInstaller>()
            where TInstaller : class, IInstaller;
    }

    public interface ISubScopeFactoryBuilder<TP0, TP1, TP2, out TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TInstance : class, IDisposable
        where TFactory : IFactory<TP0, TP1, TP2, TInstance>
    {
        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> FromFunction(Action<ContainerBuilder> subScopeInstaller);

        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> FromInstaller<TInstaller>()
            where TInstaller : class, IInstaller;
    }

    public interface ISubScopeFactoryBuilder<TP0, TP1, TP2, TP3, out TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TInstance : class, IDisposable
        where TFactory : IFactory<TP0, TP1, TP2, TP3, TInstance>
    {
        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> FromFunction(Action<ContainerBuilder> subScopeInstaller);

        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> FromInstaller<TInstaller>()
            where TInstaller : class, IInstaller;
    }

    public interface ISubScopeFactoryBuilder<TP0, TP1, TP2, TP3, TP4, out TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TInstance : class, IDisposable
        where TFactory : IFactory<TP0, TP1, TP2, TP3, TP4, TInstance>
    {
        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> FromFunction(Action<ContainerBuilder> subScopeInstaller);

        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> FromInstaller<TInstaller>()
            where TInstaller : class, IInstaller;
    }

    public interface ISubScopeFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, out TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TInstance : class, IDisposable
        where TFactory : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>
    {
        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> FromFunction(Action<ContainerBuilder> subScopeInstaller);

        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> FromInstaller<TInstaller>()
            where TInstaller : class, IInstaller;
    }

    public interface ISubScopeFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, out TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TInstance : class, IDisposable
        where TFactory : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>
    {
        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> FromFunction(Action<ContainerBuilder> subScopeInstaller);

        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> FromInstaller<TInstaller>()
            where TInstaller : class, IInstaller;
    }

    public interface ISubScopeFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, out TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TInstance : class, IDisposable
        where TFactory : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>
    {
        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> FromFunction(Action<ContainerBuilder> subScopeInstaller);

        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> FromInstaller<TInstaller>()
            where TInstaller : class, IInstaller;
    }

    public interface ISubScopeFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, out TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TInstance : class, IDisposable
        where TFactory : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>
    {
        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> FromFunction(Action<ContainerBuilder> subScopeInstaller);

        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> FromInstaller<TInstaller>()
            where TInstaller : class, IInstaller;
    }

    public interface ISubScopeFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, out TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TInstance : class, IDisposable
        where TFactory : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>
    {
        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> FromFunction(Action<ContainerBuilder> subScopeInstaller);

        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> FromInstaller<TInstaller>()
            where TInstaller : class, IInstaller;
    }

}