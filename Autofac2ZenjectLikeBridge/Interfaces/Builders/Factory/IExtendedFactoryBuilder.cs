using System;
using Autofac;
using Autofac.Builder;

namespace Autofac2ZenjectLikeBridge.Interfaces.Builders.Factory
{
    //generated amount 10

    public interface IExtendedFactoryBuilder<in TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TFactory : IFactory<TInstance>
    {
        IRegistrationBuilder<TFactory, TActivatorData, SingleRegistrationStyle> FromNewInstance();
        IRegistrationBuilder<TFactory, TActivatorData, SingleRegistrationStyle> FromFunction(Func<ILifetimeScope, TInstance> func);
    }

    public interface IExtendedFactoryBuilder<TP0, in TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TFactory : IFactory<TP0, TInstance>
    {
        IRegistrationBuilder<TFactory, TActivatorData, SingleRegistrationStyle> FromNewInstance();
        IRegistrationBuilder<TFactory, TActivatorData, SingleRegistrationStyle> FromFunction(Func<ILifetimeScope, TInstance> func);
    }

    public interface IExtendedFactoryBuilder<TP0, TP1, in TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TFactory : IFactory<TP0, TP1, TInstance>
    {
        IRegistrationBuilder<TFactory, TActivatorData, SingleRegistrationStyle> FromNewInstance();
        IRegistrationBuilder<TFactory, TActivatorData, SingleRegistrationStyle> FromFunction(Func<ILifetimeScope, TInstance> func);
    }

    public interface IExtendedFactoryBuilder<TP0, TP1, TP2, in TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TFactory : IFactory<TP0, TP1, TP2, TInstance>
    {
        IRegistrationBuilder<TFactory, TActivatorData, SingleRegistrationStyle> FromNewInstance();
        IRegistrationBuilder<TFactory, TActivatorData, SingleRegistrationStyle> FromFunction(Func<ILifetimeScope, TInstance> func);
    }

    public interface IExtendedFactoryBuilder<TP0, TP1, TP2, TP3, in TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TFactory : IFactory<TP0, TP1, TP2, TP3, TInstance>
    {
        IRegistrationBuilder<TFactory, TActivatorData, SingleRegistrationStyle> FromNewInstance();
        IRegistrationBuilder<TFactory, TActivatorData, SingleRegistrationStyle> FromFunction(Func<ILifetimeScope, TInstance> func);
    }

    public interface IExtendedFactoryBuilder<TP0, TP1, TP2, TP3, TP4, in TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TFactory : IFactory<TP0, TP1, TP2, TP3, TP4, TInstance>
    {
        IRegistrationBuilder<TFactory, TActivatorData, SingleRegistrationStyle> FromNewInstance();
        IRegistrationBuilder<TFactory, TActivatorData, SingleRegistrationStyle> FromFunction(Func<ILifetimeScope, TInstance> func);
    }

    public interface IExtendedFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, in TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TFactory : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>
    {
        IRegistrationBuilder<TFactory, TActivatorData, SingleRegistrationStyle> FromNewInstance();
        IRegistrationBuilder<TFactory, TActivatorData, SingleRegistrationStyle> FromFunction(Func<ILifetimeScope, TInstance> func);
    }

    public interface IExtendedFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, in TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TFactory : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>
    {
        IRegistrationBuilder<TFactory, TActivatorData, SingleRegistrationStyle> FromNewInstance();
        IRegistrationBuilder<TFactory, TActivatorData, SingleRegistrationStyle> FromFunction(Func<ILifetimeScope, TInstance> func);
    }

    public interface IExtendedFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, in TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TFactory : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>
    {
        IRegistrationBuilder<TFactory, TActivatorData, SingleRegistrationStyle> FromNewInstance();
        IRegistrationBuilder<TFactory, TActivatorData, SingleRegistrationStyle> FromFunction(Func<ILifetimeScope, TInstance> func);
    }

    public interface IExtendedFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, in TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TFactory : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>
    {
        IRegistrationBuilder<TFactory, TActivatorData, SingleRegistrationStyle> FromNewInstance();
        IRegistrationBuilder<TFactory, TActivatorData, SingleRegistrationStyle> FromFunction(Func<ILifetimeScope, TInstance> func);
    }

    public interface IExtendedFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, in TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TFactory : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>
    {
        IRegistrationBuilder<TFactory, TActivatorData, SingleRegistrationStyle> FromNewInstance();
        IRegistrationBuilder<TFactory, TActivatorData, SingleRegistrationStyle> FromFunction(Func<ILifetimeScope, TInstance> func);
    }

}