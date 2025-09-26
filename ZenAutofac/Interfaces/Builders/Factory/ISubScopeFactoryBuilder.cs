using System;
using Autofac;
using Autofac.Builder;
using Autofac.Core;
using JetBrains.Annotations;

namespace ZenAutofac.Interfaces.Builders.Factory
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
            SingleRegistrationStyle> ByFunction(Action<ContainerBuilder> subScopeLoader);

        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> ByModule<TModule>(
            [CanBeNull] Func<ILifetimeScope, TModule> moduleFactory = null)
            where TModule : class, IModule;
    }

    public interface ISubScopeFactoryBuilder<out TP0, out TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TInstance : class, IDisposable
        where TFactory : IFactory<TP0, TInstance>
    {
        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> ByFunction(Action<ContainerBuilder, TP0> subScopeLoader);

        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> ByModule<TModule>(
            [CanBeNull] Func<ILifetimeScope, TP0, TModule> moduleFactory = null)
            where TModule : class, IModule;
    }

    public interface ISubScopeFactoryBuilder<out TP0, out TP1, out TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TInstance : class, IDisposable
        where TFactory : IFactory<TP0, TP1, TInstance>
    {
        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> ByFunction(Action<ContainerBuilder, TP0, TP1> subScopeLoader);

        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> ByModule<TModule>(
            [CanBeNull] Func<ILifetimeScope, TP0, TP1, TModule> moduleFactory = null)
            where TModule : class, IModule;
    }

    public interface ISubScopeFactoryBuilder<out TP0, out TP1, out TP2, out TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TInstance : class, IDisposable
        where TFactory : IFactory<TP0, TP1, TP2, TInstance>
    {
        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> ByFunction(Action<ContainerBuilder, TP0, TP1, TP2> subScopeLoader);

        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> ByModule<TModule>(
            [CanBeNull] Func<ILifetimeScope, TP0, TP1, TP2, TModule> moduleFactory = null)
            where TModule : class, IModule;
    }

    public interface ISubScopeFactoryBuilder<out TP0, out TP1, out TP2, out TP3, out TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TInstance : class, IDisposable
        where TFactory : IFactory<TP0, TP1, TP2, TP3, TInstance>
    {
        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> ByFunction(Action<ContainerBuilder, TP0, TP1, TP2, TP3> subScopeLoader);

        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> ByModule<TModule>(
            [CanBeNull] Func<ILifetimeScope, TP0, TP1, TP2, TP3, TModule> moduleFactory = null)
            where TModule : class, IModule;
    }

    public interface ISubScopeFactoryBuilder<out TP0, out TP1, out TP2, out TP3, out TP4, out TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TInstance : class, IDisposable
        where TFactory : IFactory<TP0, TP1, TP2, TP3, TP4, TInstance>
    {
        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> ByFunction(Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4> subScopeLoader);

        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> ByModule<TModule>(
            [CanBeNull] Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TModule> moduleFactory = null)
            where TModule : class, IModule;
    }

    public interface ISubScopeFactoryBuilder<out TP0, out TP1, out TP2, out TP3, out TP4, out TP5, out TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TInstance : class, IDisposable
        where TFactory : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>
    {
        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> ByFunction(Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5> subScopeLoader);

        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> ByModule<TModule>(
            [CanBeNull] Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TModule> moduleFactory = null)
            where TModule : class, IModule;
    }

    public interface ISubScopeFactoryBuilder<out TP0, out TP1, out TP2, out TP3, out TP4, out TP5, out TP6, out TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TInstance : class, IDisposable
        where TFactory : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>
    {
        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> ByFunction(Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6> subScopeLoader);

        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> ByModule<TModule>(
            [CanBeNull] Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TModule> moduleFactory = null)
            where TModule : class, IModule;
    }

    public interface ISubScopeFactoryBuilder<out TP0, out TP1, out TP2, out TP3, out TP4, out TP5, out TP6, out TP7, out TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TInstance : class, IDisposable
        where TFactory : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>
    {
        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> ByFunction(Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7> subScopeLoader);

        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> ByModule<TModule>(
            [CanBeNull] Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TModule> moduleFactory = null)
            where TModule : class, IModule;
    }

    public interface ISubScopeFactoryBuilder<out TP0, out TP1, out TP2, out TP3, out TP4, out TP5, out TP6, out TP7, out TP8, out TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TInstance : class, IDisposable
        where TFactory : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>
    {
        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> ByFunction(Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8> subScopeLoader);

        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> ByModule<TModule>(
            [CanBeNull] Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TModule> moduleFactory = null)
            where TModule : class, IModule;
    }

    public interface ISubScopeFactoryBuilder<out TP0, out TP1, out TP2, out TP3, out TP4, out TP5, out TP6, out TP7, out TP8, out TP9, out TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TInstance : class, IDisposable
        where TFactory : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>
    {
        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> ByFunction(Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9> subScopeLoader);

        IRegistrationBuilder<
            TFactory,
            TActivatorData,
            SingleRegistrationStyle> ByModule<TModule>(
            [CanBeNull] Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TModule> moduleFactory = null)
            where TModule : class, IModule;
    }

}