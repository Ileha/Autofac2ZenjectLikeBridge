using System;
using Autofac;
using Autofac.Builder;
using JetBrains.Annotations;

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
            SingleRegistrationStyle> ByFunction(Action<ContainerBuilder> subScopeInstaller);

        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> ByInstaller<TInstaller>(
            [CanBeNull] Func<ILifetimeScope, ContainerBuilder, TInstaller> installerFactory = null)
            where TInstaller : class, IInstaller;
    }

    public interface ISubScopeFactoryBuilder<out TP0, out TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TInstance : class, IDisposable
        where TFactory : IFactory<TP0, TInstance>
    {
        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> ByFunction(Action<ContainerBuilder, TP0> subScopeInstaller);

        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> ByInstaller<TInstaller>(
            [CanBeNull] Func<ILifetimeScope, ContainerBuilder, TP0, TInstaller> installerFactory = null)
            where TInstaller : class, IInstaller;
    }

    public interface ISubScopeFactoryBuilder<out TP0, out TP1, out TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TInstance : class, IDisposable
        where TFactory : IFactory<TP0, TP1, TInstance>
    {
        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> ByFunction(Action<ContainerBuilder, TP0, TP1> subScopeInstaller);

        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> ByInstaller<TInstaller>(
            [CanBeNull] Func<ILifetimeScope, ContainerBuilder, TP0, TP1, TInstaller> installerFactory = null)
            where TInstaller : class, IInstaller;
    }

    public interface ISubScopeFactoryBuilder<out TP0, out TP1, out TP2, out TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TInstance : class, IDisposable
        where TFactory : IFactory<TP0, TP1, TP2, TInstance>
    {
        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> ByFunction(Action<ContainerBuilder, TP0, TP1, TP2> subScopeInstaller);

        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> ByInstaller<TInstaller>(
            [CanBeNull] Func<ILifetimeScope, ContainerBuilder, TP0, TP1, TP2, TInstaller> installerFactory = null)
            where TInstaller : class, IInstaller;
    }

    public interface ISubScopeFactoryBuilder<out TP0, out TP1, out TP2, out TP3, out TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TInstance : class, IDisposable
        where TFactory : IFactory<TP0, TP1, TP2, TP3, TInstance>
    {
        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> ByFunction(Action<ContainerBuilder, TP0, TP1, TP2, TP3> subScopeInstaller);

        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> ByInstaller<TInstaller>(
            [CanBeNull] Func<ILifetimeScope, ContainerBuilder, TP0, TP1, TP2, TP3, TInstaller> installerFactory = null)
            where TInstaller : class, IInstaller;
    }

    public interface ISubScopeFactoryBuilder<out TP0, out TP1, out TP2, out TP3, out TP4, out TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TInstance : class, IDisposable
        where TFactory : IFactory<TP0, TP1, TP2, TP3, TP4, TInstance>
    {
        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> ByFunction(Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4> subScopeInstaller);

        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> ByInstaller<TInstaller>(
            [CanBeNull] Func<ILifetimeScope, ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TInstaller> installerFactory = null)
            where TInstaller : class, IInstaller;
    }

    public interface ISubScopeFactoryBuilder<out TP0, out TP1, out TP2, out TP3, out TP4, out TP5, out TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TInstance : class, IDisposable
        where TFactory : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>
    {
        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> ByFunction(Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5> subScopeInstaller);

        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> ByInstaller<TInstaller>(
            [CanBeNull] Func<ILifetimeScope, ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TInstaller> installerFactory = null)
            where TInstaller : class, IInstaller;
    }

    public interface ISubScopeFactoryBuilder<out TP0, out TP1, out TP2, out TP3, out TP4, out TP5, out TP6, out TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TInstance : class, IDisposable
        where TFactory : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>
    {
        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> ByFunction(Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6> subScopeInstaller);

        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> ByInstaller<TInstaller>(
            [CanBeNull] Func<ILifetimeScope, ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstaller> installerFactory = null)
            where TInstaller : class, IInstaller;
    }

    public interface ISubScopeFactoryBuilder<out TP0, out TP1, out TP2, out TP3, out TP4, out TP5, out TP6, out TP7, out TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TInstance : class, IDisposable
        where TFactory : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>
    {
        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> ByFunction(Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7> subScopeInstaller);

        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> ByInstaller<TInstaller>(
            [CanBeNull] Func<ILifetimeScope, ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstaller> installerFactory = null)
            where TInstaller : class, IInstaller;
    }

    public interface ISubScopeFactoryBuilder<out TP0, out TP1, out TP2, out TP3, out TP4, out TP5, out TP6, out TP7, out TP8, out TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TInstance : class, IDisposable
        where TFactory : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>
    {
        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> ByFunction(Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8> subScopeInstaller);

        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> ByInstaller<TInstaller>(
            [CanBeNull] Func<ILifetimeScope, ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstaller> installerFactory = null)
            where TInstaller : class, IInstaller;
    }

    public interface ISubScopeFactoryBuilder<out TP0, out TP1, out TP2, out TP3, out TP4, out TP5, out TP6, out TP7, out TP8, out TP9, out TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TInstance : class, IDisposable
        where TFactory : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>
    {
        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> ByFunction(Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9> subScopeInstaller);

        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> ByInstaller<TInstaller>(
            [CanBeNull] Func<ILifetimeScope, ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstaller> installerFactory = null)
            where TInstaller : class, IInstaller;
    }

}