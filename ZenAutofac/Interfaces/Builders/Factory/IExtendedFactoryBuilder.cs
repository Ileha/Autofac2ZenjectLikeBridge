using System;
using Autofac;
using Autofac.Builder;

namespace ZenAutofac.Interfaces.Builders.Factory
{
    //generated amount 10

    public interface IExtendedFactoryBuilder<in TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TFactory : IFactory<TInstance>
    {
        IRegistrationBuilder<TFactory, TActivatorData, SingleRegistrationStyle> FromNewInstance();
        IRegistrationBuilder<TFactory, TActivatorData, SingleRegistrationStyle> FromFunction(Func<ILifetimeScope, TInstance> func);
    }

    public interface IExtendedFactoryBuilder<out TP0, in TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TFactory : IFactory<TP0, TInstance>
    {
        IRegistrationBuilder<TFactory, TActivatorData, SingleRegistrationStyle> FromNewInstance();
        IRegistrationBuilder<TFactory, TActivatorData, SingleRegistrationStyle> FromFunction(Func<ILifetimeScope, TP0, TInstance> func);
    }

    public interface IExtendedFactoryBuilder<out TP0, out TP1, in TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TFactory : IFactory<TP0, TP1, TInstance>
    {
        IRegistrationBuilder<TFactory, TActivatorData, SingleRegistrationStyle> FromNewInstance();
        IRegistrationBuilder<TFactory, TActivatorData, SingleRegistrationStyle> FromFunction(Func<ILifetimeScope, TP0, TP1, TInstance> func);
    }

    public interface IExtendedFactoryBuilder<out TP0, out TP1, out TP2, in TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TFactory : IFactory<TP0, TP1, TP2, TInstance>
    {
        IRegistrationBuilder<TFactory, TActivatorData, SingleRegistrationStyle> FromNewInstance();
        IRegistrationBuilder<TFactory, TActivatorData, SingleRegistrationStyle> FromFunction(Func<ILifetimeScope, TP0, TP1, TP2, TInstance> func);
    }

    public interface IExtendedFactoryBuilder<out TP0, out TP1, out TP2, out TP3, in TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TFactory : IFactory<TP0, TP1, TP2, TP3, TInstance>
    {
        IRegistrationBuilder<TFactory, TActivatorData, SingleRegistrationStyle> FromNewInstance();
        IRegistrationBuilder<TFactory, TActivatorData, SingleRegistrationStyle> FromFunction(Func<ILifetimeScope, TP0, TP1, TP2, TP3, TInstance> func);
    }

    public interface IExtendedFactoryBuilder<out TP0, out TP1, out TP2, out TP3, out TP4, in TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TFactory : IFactory<TP0, TP1, TP2, TP3, TP4, TInstance>
    {
        IRegistrationBuilder<TFactory, TActivatorData, SingleRegistrationStyle> FromNewInstance();
        IRegistrationBuilder<TFactory, TActivatorData, SingleRegistrationStyle> FromFunction(Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TInstance> func);
    }

    public interface IExtendedFactoryBuilder<out TP0, out TP1, out TP2, out TP3, out TP4, out TP5, in TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TFactory : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>
    {
        IRegistrationBuilder<TFactory, TActivatorData, SingleRegistrationStyle> FromNewInstance();
        IRegistrationBuilder<TFactory, TActivatorData, SingleRegistrationStyle> FromFunction(Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TInstance> func);
    }

    public interface IExtendedFactoryBuilder<out TP0, out TP1, out TP2, out TP3, out TP4, out TP5, out TP6, in TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TFactory : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>
    {
        IRegistrationBuilder<TFactory, TActivatorData, SingleRegistrationStyle> FromNewInstance();
        IRegistrationBuilder<TFactory, TActivatorData, SingleRegistrationStyle> FromFunction(Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance> func);
    }

    public interface IExtendedFactoryBuilder<out TP0, out TP1, out TP2, out TP3, out TP4, out TP5, out TP6, out TP7, in TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TFactory : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>
    {
        IRegistrationBuilder<TFactory, TActivatorData, SingleRegistrationStyle> FromNewInstance();
        IRegistrationBuilder<TFactory, TActivatorData, SingleRegistrationStyle> FromFunction(Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance> func);
    }

    public interface IExtendedFactoryBuilder<out TP0, out TP1, out TP2, out TP3, out TP4, out TP5, out TP6, out TP7, out TP8, in TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TFactory : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>
    {
        IRegistrationBuilder<TFactory, TActivatorData, SingleRegistrationStyle> FromNewInstance();
        IRegistrationBuilder<TFactory, TActivatorData, SingleRegistrationStyle> FromFunction(Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance> func);
    }

    public interface IExtendedFactoryBuilder<out TP0, out TP1, out TP2, out TP3, out TP4, out TP5, out TP6, out TP7, out TP8, out TP9, in TInstance, out TFactory, out TActivatorData>
        : IExtendedBuilderBase
        where TFactory : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>
    {
        IRegistrationBuilder<TFactory, TActivatorData, SingleRegistrationStyle> FromNewInstance();
        IRegistrationBuilder<TFactory, TActivatorData, SingleRegistrationStyle> FromFunction(Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance> func);
    }

}