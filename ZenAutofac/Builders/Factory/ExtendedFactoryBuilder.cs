using System;
using Autofac;
using Autofac.Builder;
using ZenAutofac.Interfaces;
using ZenAutofac.Interfaces.Builders.Factory;

namespace ZenAutofac.Builders.Factory
{
    //generated amount 10

    public class ExtendedFactoryBuilder<TInstance>
        : IExtendedFactoryBuilder<
            TInstance,
            IFactory<TInstance>,
            ConcreteReflectionActivatorData>
        where TInstance : class
    {
        public ContainerBuilder Builder { get; }

        public ExtendedFactoryBuilder(ContainerBuilder builder)
        {
            Builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public IRegistrationBuilder<IFactory<TInstance>, ConcreteReflectionActivatorData, SingleRegistrationStyle> FromNewInstance()
        {
            return Builder
                .RegisterType<Entities.Factories.DIExtensions.AutofacCreateInstanceFactory<TInstance>>()
                .As<IFactory<TInstance>>();
        }

        public IRegistrationBuilder<IFactory<TInstance>, ConcreteReflectionActivatorData, SingleRegistrationStyle> FromFunction(
            Func<ILifetimeScope, TInstance> func)
        {
            return Builder
                .RegisterType<Entities.Factories.DIExtensions.AutofacFunctionFactory<TInstance>>()
                .WithParameters(TypedParameter.From(func))
                .As<IFactory<TInstance>>();
        }
    }

    public class ExtendedFactoryBuilder<TP0, TInstance>
        : IExtendedFactoryBuilder<
            TP0, TInstance,
            IFactory<TP0, TInstance>,
            ConcreteReflectionActivatorData>
        where TInstance : class
    {
        public ContainerBuilder Builder { get; }

        public ExtendedFactoryBuilder(ContainerBuilder builder)
        {
            Builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public IRegistrationBuilder<IFactory<TP0, TInstance>, ConcreteReflectionActivatorData, SingleRegistrationStyle> FromNewInstance()
        {
            return Builder
                .RegisterType<Entities.Factories.DIExtensions.AutofacCreateInstanceFactory<TP0, TInstance>>()
                .As<IFactory<TP0, TInstance>>();
        }

        public IRegistrationBuilder<IFactory<TP0, TInstance>, ConcreteReflectionActivatorData, SingleRegistrationStyle> FromFunction(
            Func<ILifetimeScope, TP0, TInstance> func)
        {
            return Builder
                .RegisterType<Entities.Factories.DIExtensions.AutofacFunctionFactory<TP0, TInstance>>()
                .WithParameters(TypedParameter.From(func))
                .As<IFactory<TP0, TInstance>>();
        }
    }

    public class ExtendedFactoryBuilder<TP0, TP1, TInstance>
        : IExtendedFactoryBuilder<
            TP0, TP1, TInstance,
            IFactory<TP0, TP1, TInstance>,
            ConcreteReflectionActivatorData>
        where TInstance : class
    {
        public ContainerBuilder Builder { get; }

        public ExtendedFactoryBuilder(ContainerBuilder builder)
        {
            Builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public IRegistrationBuilder<IFactory<TP0, TP1, TInstance>, ConcreteReflectionActivatorData, SingleRegistrationStyle> FromNewInstance()
        {
            return Builder
                .RegisterType<Entities.Factories.DIExtensions.AutofacCreateInstanceFactory<TP0, TP1, TInstance>>()
                .As<IFactory<TP0, TP1, TInstance>>();
        }

        public IRegistrationBuilder<IFactory<TP0, TP1, TInstance>, ConcreteReflectionActivatorData, SingleRegistrationStyle> FromFunction(
            Func<ILifetimeScope, TP0, TP1, TInstance> func)
        {
            return Builder
                .RegisterType<Entities.Factories.DIExtensions.AutofacFunctionFactory<TP0, TP1, TInstance>>()
                .WithParameters(TypedParameter.From(func))
                .As<IFactory<TP0, TP1, TInstance>>();
        }
    }

    public class ExtendedFactoryBuilder<TP0, TP1, TP2, TInstance>
        : IExtendedFactoryBuilder<
            TP0, TP1, TP2, TInstance,
            IFactory<TP0, TP1, TP2, TInstance>,
            ConcreteReflectionActivatorData>
        where TInstance : class
    {
        public ContainerBuilder Builder { get; }

        public ExtendedFactoryBuilder(ContainerBuilder builder)
        {
            Builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public IRegistrationBuilder<IFactory<TP0, TP1, TP2, TInstance>, ConcreteReflectionActivatorData, SingleRegistrationStyle> FromNewInstance()
        {
            return Builder
                .RegisterType<Entities.Factories.DIExtensions.AutofacCreateInstanceFactory<TP0, TP1, TP2, TInstance>>()
                .As<IFactory<TP0, TP1, TP2, TInstance>>();
        }

        public IRegistrationBuilder<IFactory<TP0, TP1, TP2, TInstance>, ConcreteReflectionActivatorData, SingleRegistrationStyle> FromFunction(
            Func<ILifetimeScope, TP0, TP1, TP2, TInstance> func)
        {
            return Builder
                .RegisterType<Entities.Factories.DIExtensions.AutofacFunctionFactory<TP0, TP1, TP2, TInstance>>()
                .WithParameters(TypedParameter.From(func))
                .As<IFactory<TP0, TP1, TP2, TInstance>>();
        }
    }

    public class ExtendedFactoryBuilder<TP0, TP1, TP2, TP3, TInstance>
        : IExtendedFactoryBuilder<
            TP0, TP1, TP2, TP3, TInstance,
            IFactory<TP0, TP1, TP2, TP3, TInstance>,
            ConcreteReflectionActivatorData>
        where TInstance : class
    {
        public ContainerBuilder Builder { get; }

        public ExtendedFactoryBuilder(ContainerBuilder builder)
        {
            Builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public IRegistrationBuilder<IFactory<TP0, TP1, TP2, TP3, TInstance>, ConcreteReflectionActivatorData, SingleRegistrationStyle> FromNewInstance()
        {
            return Builder
                .RegisterType<Entities.Factories.DIExtensions.AutofacCreateInstanceFactory<TP0, TP1, TP2, TP3, TInstance>>()
                .As<IFactory<TP0, TP1, TP2, TP3, TInstance>>();
        }

        public IRegistrationBuilder<IFactory<TP0, TP1, TP2, TP3, TInstance>, ConcreteReflectionActivatorData, SingleRegistrationStyle> FromFunction(
            Func<ILifetimeScope, TP0, TP1, TP2, TP3, TInstance> func)
        {
            return Builder
                .RegisterType<Entities.Factories.DIExtensions.AutofacFunctionFactory<TP0, TP1, TP2, TP3, TInstance>>()
                .WithParameters(TypedParameter.From(func))
                .As<IFactory<TP0, TP1, TP2, TP3, TInstance>>();
        }
    }

    public class ExtendedFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TInstance>
        : IExtendedFactoryBuilder<
            TP0, TP1, TP2, TP3, TP4, TInstance,
            IFactory<TP0, TP1, TP2, TP3, TP4, TInstance>,
            ConcreteReflectionActivatorData>
        where TInstance : class
    {
        public ContainerBuilder Builder { get; }

        public ExtendedFactoryBuilder(ContainerBuilder builder)
        {
            Builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public IRegistrationBuilder<IFactory<TP0, TP1, TP2, TP3, TP4, TInstance>, ConcreteReflectionActivatorData, SingleRegistrationStyle> FromNewInstance()
        {
            return Builder
                .RegisterType<Entities.Factories.DIExtensions.AutofacCreateInstanceFactory<TP0, TP1, TP2, TP3, TP4, TInstance>>()
                .As<IFactory<TP0, TP1, TP2, TP3, TP4, TInstance>>();
        }

        public IRegistrationBuilder<IFactory<TP0, TP1, TP2, TP3, TP4, TInstance>, ConcreteReflectionActivatorData, SingleRegistrationStyle> FromFunction(
            Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TInstance> func)
        {
            return Builder
                .RegisterType<Entities.Factories.DIExtensions.AutofacFunctionFactory<TP0, TP1, TP2, TP3, TP4, TInstance>>()
                .WithParameters(TypedParameter.From(func))
                .As<IFactory<TP0, TP1, TP2, TP3, TP4, TInstance>>();
        }
    }

    public class ExtendedFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>
        : IExtendedFactoryBuilder<
            TP0, TP1, TP2, TP3, TP4, TP5, TInstance,
            IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>,
            ConcreteReflectionActivatorData>
        where TInstance : class
    {
        public ContainerBuilder Builder { get; }

        public ExtendedFactoryBuilder(ContainerBuilder builder)
        {
            Builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public IRegistrationBuilder<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>, ConcreteReflectionActivatorData, SingleRegistrationStyle> FromNewInstance()
        {
            return Builder
                .RegisterType<Entities.Factories.DIExtensions.AutofacCreateInstanceFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>>()
                .As<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>>();
        }

        public IRegistrationBuilder<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>, ConcreteReflectionActivatorData, SingleRegistrationStyle> FromFunction(
            Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TInstance> func)
        {
            return Builder
                .RegisterType<Entities.Factories.DIExtensions.AutofacFunctionFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>>()
                .WithParameters(TypedParameter.From(func))
                .As<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>>();
        }
    }

    public class ExtendedFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>
        : IExtendedFactoryBuilder<
            TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance,
            IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>,
            ConcreteReflectionActivatorData>
        where TInstance : class
    {
        public ContainerBuilder Builder { get; }

        public ExtendedFactoryBuilder(ContainerBuilder builder)
        {
            Builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public IRegistrationBuilder<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>, ConcreteReflectionActivatorData, SingleRegistrationStyle> FromNewInstance()
        {
            return Builder
                .RegisterType<Entities.Factories.DIExtensions.AutofacCreateInstanceFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>>()
                .As<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>>();
        }

        public IRegistrationBuilder<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>, ConcreteReflectionActivatorData, SingleRegistrationStyle> FromFunction(
            Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance> func)
        {
            return Builder
                .RegisterType<Entities.Factories.DIExtensions.AutofacFunctionFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>>()
                .WithParameters(TypedParameter.From(func))
                .As<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>>();
        }
    }

    public class ExtendedFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>
        : IExtendedFactoryBuilder<
            TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance,
            IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>,
            ConcreteReflectionActivatorData>
        where TInstance : class
    {
        public ContainerBuilder Builder { get; }

        public ExtendedFactoryBuilder(ContainerBuilder builder)
        {
            Builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public IRegistrationBuilder<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>, ConcreteReflectionActivatorData, SingleRegistrationStyle> FromNewInstance()
        {
            return Builder
                .RegisterType<Entities.Factories.DIExtensions.AutofacCreateInstanceFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>>()
                .As<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>>();
        }

        public IRegistrationBuilder<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>, ConcreteReflectionActivatorData, SingleRegistrationStyle> FromFunction(
            Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance> func)
        {
            return Builder
                .RegisterType<Entities.Factories.DIExtensions.AutofacFunctionFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>>()
                .WithParameters(TypedParameter.From(func))
                .As<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>>();
        }
    }

    public class ExtendedFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>
        : IExtendedFactoryBuilder<
            TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance,
            IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>,
            ConcreteReflectionActivatorData>
        where TInstance : class
    {
        public ContainerBuilder Builder { get; }

        public ExtendedFactoryBuilder(ContainerBuilder builder)
        {
            Builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public IRegistrationBuilder<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>, ConcreteReflectionActivatorData, SingleRegistrationStyle> FromNewInstance()
        {
            return Builder
                .RegisterType<Entities.Factories.DIExtensions.AutofacCreateInstanceFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>>()
                .As<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>>();
        }

        public IRegistrationBuilder<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>, ConcreteReflectionActivatorData, SingleRegistrationStyle> FromFunction(
            Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance> func)
        {
            return Builder
                .RegisterType<Entities.Factories.DIExtensions.AutofacFunctionFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>>()
                .WithParameters(TypedParameter.From(func))
                .As<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>>();
        }
    }

    public class ExtendedFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>
        : IExtendedFactoryBuilder<
            TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance,
            IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>,
            ConcreteReflectionActivatorData>
        where TInstance : class
    {
        public ContainerBuilder Builder { get; }

        public ExtendedFactoryBuilder(ContainerBuilder builder)
        {
            Builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public IRegistrationBuilder<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>, ConcreteReflectionActivatorData, SingleRegistrationStyle> FromNewInstance()
        {
            return Builder
                .RegisterType<Entities.Factories.DIExtensions.AutofacCreateInstanceFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>>()
                .As<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>>();
        }

        public IRegistrationBuilder<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>, ConcreteReflectionActivatorData, SingleRegistrationStyle> FromFunction(
            Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance> func)
        {
            return Builder
                .RegisterType<Entities.Factories.DIExtensions.AutofacFunctionFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>>()
                .WithParameters(TypedParameter.From(func))
                .As<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>>();
        }
    }

}