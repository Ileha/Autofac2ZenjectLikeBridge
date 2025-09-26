using System;
using Autofac;
using Autofac.Builder;
using Autofac.Core;
using ZenAutofac.Interfaces;
using ZenAutofac.Interfaces.Builders.Factory;

namespace ZenAutofac.Builders.Factory
{
    //generated amount 10

    public class SubScopeFactoryBuilder<TInstance>
        : ISubScopeFactoryBuilder<
            TInstance,
            IFactory<TInstance>,
            ConcreteReflectionActivatorData>
        where TInstance : class, IDisposable
    {
        public ContainerBuilder Builder { get; }

        public SubScopeFactoryBuilder(ContainerBuilder builder)
        {
            Builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public IRegistrationBuilder<IFactory<TInstance>, ConcreteReflectionActivatorData, SingleRegistrationStyle>
            ByFunction(
            Action<ContainerBuilder> subScopeLoader)
        {
            return Builder
                .RegisterType<Entities.Factories.DIExtensions.AutofacSubScopeFactory<TInstance>>()
                .WithParameters(TypedParameter.From(subScopeLoader))
                .As<IFactory<TInstance>>();
        }

        public IRegistrationBuilder<
            IFactory<TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> ByModule<TModule>(
            Func<ILifetimeScope, TModule> moduleFactory = null)
            where TModule : class, IModule
        {
            return Builder
                .RegisterType<Entities.Factories.DIExtensions.AutofacSubScopeModuleFactory<TInstance, TModule>>()
                .WithParameter(TypedParameter.From(moduleFactory))
                .As<IFactory<TInstance>>();
        }
    }

    public class SubScopeFactoryBuilder<TP0, TInstance>
        : ISubScopeFactoryBuilder<
            TP0,
			TInstance,
            IFactory<TP0, TInstance>,
            ConcreteReflectionActivatorData>
        where TInstance : class, IDisposable
    {
        public ContainerBuilder Builder { get; }

        public SubScopeFactoryBuilder(ContainerBuilder builder)
        {
            Builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public IRegistrationBuilder<IFactory<TP0, TInstance>, ConcreteReflectionActivatorData, SingleRegistrationStyle>
            ByFunction(
            Action<ContainerBuilder, TP0> subScopeLoader)
        {
            return Builder
                .RegisterType<Entities.Factories.DIExtensions.AutofacSubScopeFactory<TP0, TInstance>>()
                .WithParameters(TypedParameter.From(subScopeLoader))
                .As<IFactory<TP0, TInstance>>();
        }

        public IRegistrationBuilder<
            IFactory<TP0, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> ByModule<TModule>(
            Func<ILifetimeScope, TP0, TModule> moduleFactory = null)
            where TModule : class, IModule
        {
            return Builder
                .RegisterType<Entities.Factories.DIExtensions.AutofacSubScopeModuleFactory<TP0, TInstance, TModule>>()
                .WithParameter(TypedParameter.From(moduleFactory))
                .As<IFactory<TP0, TInstance>>();
        }
    }

    public class SubScopeFactoryBuilder<TP0, TP1, TInstance>
        : ISubScopeFactoryBuilder<
            TP0, TP1,
			TInstance,
            IFactory<TP0, TP1, TInstance>,
            ConcreteReflectionActivatorData>
        where TInstance : class, IDisposable
    {
        public ContainerBuilder Builder { get; }

        public SubScopeFactoryBuilder(ContainerBuilder builder)
        {
            Builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public IRegistrationBuilder<IFactory<TP0, TP1, TInstance>, ConcreteReflectionActivatorData, SingleRegistrationStyle>
            ByFunction(
            Action<ContainerBuilder, TP0, TP1> subScopeLoader)
        {
            return Builder
                .RegisterType<Entities.Factories.DIExtensions.AutofacSubScopeFactory<TP0, TP1, TInstance>>()
                .WithParameters(TypedParameter.From(subScopeLoader))
                .As<IFactory<TP0, TP1, TInstance>>();
        }

        public IRegistrationBuilder<
            IFactory<TP0, TP1, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> ByModule<TModule>(
            Func<ILifetimeScope, TP0, TP1, TModule> moduleFactory = null)
            where TModule : class, IModule
        {
            return Builder
                .RegisterType<Entities.Factories.DIExtensions.AutofacSubScopeModuleFactory<TP0, TP1, TInstance, TModule>>()
                .WithParameter(TypedParameter.From(moduleFactory))
                .As<IFactory<TP0, TP1, TInstance>>();
        }
    }

    public class SubScopeFactoryBuilder<TP0, TP1, TP2, TInstance>
        : ISubScopeFactoryBuilder<
            TP0, TP1, TP2,
			TInstance,
            IFactory<TP0, TP1, TP2, TInstance>,
            ConcreteReflectionActivatorData>
        where TInstance : class, IDisposable
    {
        public ContainerBuilder Builder { get; }

        public SubScopeFactoryBuilder(ContainerBuilder builder)
        {
            Builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public IRegistrationBuilder<IFactory<TP0, TP1, TP2, TInstance>, ConcreteReflectionActivatorData, SingleRegistrationStyle>
            ByFunction(
            Action<ContainerBuilder, TP0, TP1, TP2> subScopeLoader)
        {
            return Builder
                .RegisterType<Entities.Factories.DIExtensions.AutofacSubScopeFactory<TP0, TP1, TP2, TInstance>>()
                .WithParameters(TypedParameter.From(subScopeLoader))
                .As<IFactory<TP0, TP1, TP2, TInstance>>();
        }

        public IRegistrationBuilder<
            IFactory<TP0, TP1, TP2, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> ByModule<TModule>(
            Func<ILifetimeScope, TP0, TP1, TP2, TModule> moduleFactory = null)
            where TModule : class, IModule
        {
            return Builder
                .RegisterType<Entities.Factories.DIExtensions.AutofacSubScopeModuleFactory<TP0, TP1, TP2, TInstance, TModule>>()
                .WithParameter(TypedParameter.From(moduleFactory))
                .As<IFactory<TP0, TP1, TP2, TInstance>>();
        }
    }

    public class SubScopeFactoryBuilder<TP0, TP1, TP2, TP3, TInstance>
        : ISubScopeFactoryBuilder<
            TP0, TP1, TP2, TP3,
			TInstance,
            IFactory<TP0, TP1, TP2, TP3, TInstance>,
            ConcreteReflectionActivatorData>
        where TInstance : class, IDisposable
    {
        public ContainerBuilder Builder { get; }

        public SubScopeFactoryBuilder(ContainerBuilder builder)
        {
            Builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public IRegistrationBuilder<IFactory<TP0, TP1, TP2, TP3, TInstance>, ConcreteReflectionActivatorData, SingleRegistrationStyle>
            ByFunction(
            Action<ContainerBuilder, TP0, TP1, TP2, TP3> subScopeLoader)
        {
            return Builder
                .RegisterType<Entities.Factories.DIExtensions.AutofacSubScopeFactory<TP0, TP1, TP2, TP3, TInstance>>()
                .WithParameters(TypedParameter.From(subScopeLoader))
                .As<IFactory<TP0, TP1, TP2, TP3, TInstance>>();
        }

        public IRegistrationBuilder<
            IFactory<TP0, TP1, TP2, TP3, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> ByModule<TModule>(
            Func<ILifetimeScope, TP0, TP1, TP2, TP3, TModule> moduleFactory = null)
            where TModule : class, IModule
        {
            return Builder
                .RegisterType<Entities.Factories.DIExtensions.AutofacSubScopeModuleFactory<TP0, TP1, TP2, TP3, TInstance, TModule>>()
                .WithParameter(TypedParameter.From(moduleFactory))
                .As<IFactory<TP0, TP1, TP2, TP3, TInstance>>();
        }
    }

    public class SubScopeFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TInstance>
        : ISubScopeFactoryBuilder<
            TP0, TP1, TP2, TP3, TP4,
			TInstance,
            IFactory<TP0, TP1, TP2, TP3, TP4, TInstance>,
            ConcreteReflectionActivatorData>
        where TInstance : class, IDisposable
    {
        public ContainerBuilder Builder { get; }

        public SubScopeFactoryBuilder(ContainerBuilder builder)
        {
            Builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public IRegistrationBuilder<IFactory<TP0, TP1, TP2, TP3, TP4, TInstance>, ConcreteReflectionActivatorData, SingleRegistrationStyle>
            ByFunction(
            Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4> subScopeLoader)
        {
            return Builder
                .RegisterType<Entities.Factories.DIExtensions.AutofacSubScopeFactory<TP0, TP1, TP2, TP3, TP4, TInstance>>()
                .WithParameters(TypedParameter.From(subScopeLoader))
                .As<IFactory<TP0, TP1, TP2, TP3, TP4, TInstance>>();
        }

        public IRegistrationBuilder<
            IFactory<TP0, TP1, TP2, TP3, TP4, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> ByModule<TModule>(
            Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TModule> moduleFactory = null)
            where TModule : class, IModule
        {
            return Builder
                .RegisterType<Entities.Factories.DIExtensions.AutofacSubScopeModuleFactory<TP0, TP1, TP2, TP3, TP4, TInstance, TModule>>()
                .WithParameter(TypedParameter.From(moduleFactory))
                .As<IFactory<TP0, TP1, TP2, TP3, TP4, TInstance>>();
        }
    }

    public class SubScopeFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>
        : ISubScopeFactoryBuilder<
            TP0, TP1, TP2, TP3, TP4, TP5,
			TInstance,
            IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>,
            ConcreteReflectionActivatorData>
        where TInstance : class, IDisposable
    {
        public ContainerBuilder Builder { get; }

        public SubScopeFactoryBuilder(ContainerBuilder builder)
        {
            Builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public IRegistrationBuilder<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>, ConcreteReflectionActivatorData, SingleRegistrationStyle>
            ByFunction(
            Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5> subScopeLoader)
        {
            return Builder
                .RegisterType<Entities.Factories.DIExtensions.AutofacSubScopeFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>>()
                .WithParameters(TypedParameter.From(subScopeLoader))
                .As<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>>();
        }

        public IRegistrationBuilder<
            IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> ByModule<TModule>(
            Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TModule> moduleFactory = null)
            where TModule : class, IModule
        {
            return Builder
                .RegisterType<Entities.Factories.DIExtensions.AutofacSubScopeModuleFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance, TModule>>()
                .WithParameter(TypedParameter.From(moduleFactory))
                .As<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>>();
        }
    }

    public class SubScopeFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>
        : ISubScopeFactoryBuilder<
            TP0, TP1, TP2, TP3, TP4, TP5, TP6,
			TInstance,
            IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>,
            ConcreteReflectionActivatorData>
        where TInstance : class, IDisposable
    {
        public ContainerBuilder Builder { get; }

        public SubScopeFactoryBuilder(ContainerBuilder builder)
        {
            Builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public IRegistrationBuilder<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>, ConcreteReflectionActivatorData, SingleRegistrationStyle>
            ByFunction(
            Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6> subScopeLoader)
        {
            return Builder
                .RegisterType<Entities.Factories.DIExtensions.AutofacSubScopeFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>>()
                .WithParameters(TypedParameter.From(subScopeLoader))
                .As<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>>();
        }

        public IRegistrationBuilder<
            IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> ByModule<TModule>(
            Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TModule> moduleFactory = null)
            where TModule : class, IModule
        {
            return Builder
                .RegisterType<Entities.Factories.DIExtensions.AutofacSubScopeModuleFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance, TModule>>()
                .WithParameter(TypedParameter.From(moduleFactory))
                .As<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>>();
        }
    }

    public class SubScopeFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>
        : ISubScopeFactoryBuilder<
            TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7,
			TInstance,
            IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>,
            ConcreteReflectionActivatorData>
        where TInstance : class, IDisposable
    {
        public ContainerBuilder Builder { get; }

        public SubScopeFactoryBuilder(ContainerBuilder builder)
        {
            Builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public IRegistrationBuilder<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>, ConcreteReflectionActivatorData, SingleRegistrationStyle>
            ByFunction(
            Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7> subScopeLoader)
        {
            return Builder
                .RegisterType<Entities.Factories.DIExtensions.AutofacSubScopeFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>>()
                .WithParameters(TypedParameter.From(subScopeLoader))
                .As<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>>();
        }

        public IRegistrationBuilder<
            IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> ByModule<TModule>(
            Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TModule> moduleFactory = null)
            where TModule : class, IModule
        {
            return Builder
                .RegisterType<Entities.Factories.DIExtensions.AutofacSubScopeModuleFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance, TModule>>()
                .WithParameter(TypedParameter.From(moduleFactory))
                .As<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>>();
        }
    }

    public class SubScopeFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>
        : ISubScopeFactoryBuilder<
            TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8,
			TInstance,
            IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>,
            ConcreteReflectionActivatorData>
        where TInstance : class, IDisposable
    {
        public ContainerBuilder Builder { get; }

        public SubScopeFactoryBuilder(ContainerBuilder builder)
        {
            Builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public IRegistrationBuilder<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>, ConcreteReflectionActivatorData, SingleRegistrationStyle>
            ByFunction(
            Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8> subScopeLoader)
        {
            return Builder
                .RegisterType<Entities.Factories.DIExtensions.AutofacSubScopeFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>>()
                .WithParameters(TypedParameter.From(subScopeLoader))
                .As<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>>();
        }

        public IRegistrationBuilder<
            IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> ByModule<TModule>(
            Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TModule> moduleFactory = null)
            where TModule : class, IModule
        {
            return Builder
                .RegisterType<Entities.Factories.DIExtensions.AutofacSubScopeModuleFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance, TModule>>()
                .WithParameter(TypedParameter.From(moduleFactory))
                .As<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>>();
        }
    }

    public class SubScopeFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>
        : ISubScopeFactoryBuilder<
            TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9,
			TInstance,
            IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>,
            ConcreteReflectionActivatorData>
        where TInstance : class, IDisposable
    {
        public ContainerBuilder Builder { get; }

        public SubScopeFactoryBuilder(ContainerBuilder builder)
        {
            Builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public IRegistrationBuilder<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>, ConcreteReflectionActivatorData, SingleRegistrationStyle>
            ByFunction(
            Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9> subScopeLoader)
        {
            return Builder
                .RegisterType<Entities.Factories.DIExtensions.AutofacSubScopeFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>>()
                .WithParameters(TypedParameter.From(subScopeLoader))
                .As<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>>();
        }

        public IRegistrationBuilder<
            IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> ByModule<TModule>(
            Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TModule> moduleFactory = null)
            where TModule : class, IModule
        {
            return Builder
                .RegisterType<Entities.Factories.DIExtensions.AutofacSubScopeModuleFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance, TModule>>()
                .WithParameter(TypedParameter.From(moduleFactory))
                .As<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>>();
        }
    }

}