using System;
using System.Linq;
using Autofac;
using Autofac.Builder;
using Autofac.Core;
using Autofac.Core.Registration;
using Autofac2ZenjectLikeBridge.Builders.Decorator;
using Autofac2ZenjectLikeBridge.Builders.Instance;
using Autofac2ZenjectLikeBridge.Extensions.HarmonyPatcher;
using Autofac2ZenjectLikeBridge.Interfaces;
using Autofac2ZenjectLikeBridge.Interfaces.Builders.Decorator;
using Autofac2ZenjectLikeBridge.Interfaces.Builders.Instance;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Module = Autofac.Module;

namespace Autofac2ZenjectLikeBridge
{
    public static partial class DIExtensions
    {

        // public static IExtendedRegistrationFactoryBuilderWithDispose<
        //     TInstance,
        //     TPlaceholderFactory,
        //     SimpleActivatorData> AsDispose<TInstance, TPlaceholderFactory>(
        //         this IExtendedRegistrationFactoryBuilder<TInstance, TPlaceholderFactory, SimpleActivatorData> builder)
        //     where TInstance : IDisposable
        //     where TPlaceholderFactory : IFactory<TInstance>
        // {
        //     return new ExtendedRegistrationPlaceholderFactoryBuilder()
        // }

        public interface IExtendedRegistrationFactoryBuilder<in TInstance, out TFactory, out TActivatorData>
            where TFactory : IFactory<TInstance>
        {
            IRegistrationBuilder<TFactory, TActivatorData, SingleRegistrationStyle> FromNewInstance();
            IRegistrationBuilder<TFactory, TActivatorData, SingleRegistrationStyle> FromFunction(Func<ILifetimeScope, TInstance> func);
        }

        public interface IExtendedRegistrationFactoryBuilderWithDispose<TInstance, out TFactory, out TActivatorData>
            : IExtendedRegistrationFactoryBuilder<TInstance, TFactory, TActivatorData>
            where TInstance : IDisposable
            where TFactory : IFactory<TInstance>
        {
            ISubScopeFactoryBuilder<TInstance, TFactory, TActivatorData> FromSubScope();
        }

        public class ExtendedRegistrationPlaceholderFactoryBuilder<TInstance, TPlaceholderFactory>
            : IExtendedRegistrationFactoryBuilder<TInstance, TPlaceholderFactory, SimpleActivatorData>
            where TPlaceholderFactory : PlaceholderFactory<TInstance>
            where TInstance : class
        {
            protected readonly ContainerBuilder Builder;

            public ExtendedRegistrationPlaceholderFactoryBuilder(ContainerBuilder builder)
            {
                Builder = builder;
            }

            public IRegistrationBuilder<TPlaceholderFactory, SimpleActivatorData, SingleRegistrationStyle> FromNewInstance()
            {
                return Builder
                    .Register((IComponentContext _, ILifetimeScope scope) =>
                    {
                        var subScope = scope
                            .BeginLifetimeScope(subScopeBuilder =>
                            {
                                new ExtendedRegistrationFactoryBuilder<TInstance>(subScopeBuilder)
                                    .FromNewInstance()
                                    .SingleInstance();

                                subScopeBuilder
                                    .RegisterType<TPlaceholderFactory>()
                                    .SingleInstance()
                                    .ExternallyOwned();
                            });

                        var placeholderFactory = subScope.Resolve<TPlaceholderFactory>();
                        var factory = subScope.Resolve<IFactory<TInstance>>();
                        placeholderFactory.Nested = factory;

                        subScope
                            .AddToHarmony(placeholderFactory);

                        return placeholderFactory;
                    });
            }

            public IRegistrationBuilder<TPlaceholderFactory, SimpleActivatorData, SingleRegistrationStyle> FromFunction(Func<ILifetimeScope, TInstance> func)
            {
                return Builder
                    .Register((IComponentContext _, ILifetimeScope scope) =>
                    {
                        var subScope = scope
                            .BeginLifetimeScope(subScopeBuilder =>
                            {
                                new ExtendedRegistrationFactoryBuilder<TInstance>(subScopeBuilder)
                                    .FromFunction(func)
                                    .SingleInstance();

                                subScopeBuilder
                                    .RegisterType<TPlaceholderFactory>()
                                    .SingleInstance()
                                    .ExternallyOwned();
                            });

                        var placeholderFactory = subScope.Resolve<TPlaceholderFactory>();
                        var factory = subScope.Resolve<IFactory<TInstance>>();
                        placeholderFactory.Nested = factory;

                        subScope
                            .AddToHarmony(placeholderFactory);

                        return placeholderFactory;
                    });
            }
        }

        public class ExtendedRegistrationPlaceholderFactoryBuilderWithDispose<TInstance, TPlaceholderFactory>
            : ExtendedRegistrationPlaceholderFactoryBuilder<TInstance, TPlaceholderFactory>,
                IExtendedRegistrationFactoryBuilderWithDispose<TInstance, TPlaceholderFactory, SimpleActivatorData>
            where TPlaceholderFactory : PlaceholderFactory<TInstance>
            where TInstance : class, IDisposable
        {
            public ExtendedRegistrationPlaceholderFactoryBuilderWithDispose(ContainerBuilder builder)
                : base(builder)
            {
            }

            public ISubScopeFactoryBuilder<TInstance, TPlaceholderFactory, SimpleActivatorData> FromSubScope()
            {
                return new SubScopePlaceholderFactoryBuilder<TInstance, TPlaceholderFactory>(Builder);
            }
        }

        public class ExtendedRegistrationFactoryBuilder<TInstance>
            : IExtendedRegistrationFactoryBuilder<TInstance, IFactory<TInstance>, ConcreteReflectionActivatorData>
            where TInstance : class
        {
            protected readonly ContainerBuilder Builder;

            public ExtendedRegistrationFactoryBuilder(ContainerBuilder builder)
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

        public class ExtendedRegistrationFactoryBuilderWithDispose<TInstance>
            : ExtendedRegistrationFactoryBuilder<TInstance>,
                IExtendedRegistrationFactoryBuilderWithDispose<TInstance, IFactory<TInstance>, ConcreteReflectionActivatorData>
            where TInstance : class, IDisposable
        {
            public ExtendedRegistrationFactoryBuilderWithDispose(ContainerBuilder builder)
                : base(builder)
            {
            }

            public ISubScopeFactoryBuilder<TInstance, IFactory<TInstance>, ConcreteReflectionActivatorData> FromSubScope()
            {
                return new SubScopeFactoryBuilder<TInstance>(Builder);
            }
        }

        public interface ISubScopeFactoryBuilder<out TInstance, out TFactory, out TActivatorData>
            where TInstance : IDisposable
            where TFactory : IFactory<TInstance>
        {
            IRegistrationBuilder<
                TFactory,
                TActivatorData,
                SingleRegistrationStyle> FromFunction(Action<ContainerBuilder> subScopeInstaller);

            IRegistrationBuilder<
                TFactory,
                TActivatorData,
                SingleRegistrationStyle> FromInstaller<TInstaller>(TInstaller installer)
                where TInstaller : class, IInstaller;
        }

        public class SubScopePlaceholderFactoryBuilder<TInstance, TPlaceholderFactory> : ISubScopeFactoryBuilder<TInstance, TPlaceholderFactory, SimpleActivatorData>
            where TInstance : IDisposable
            where TPlaceholderFactory : PlaceholderFactory<TInstance>
        {
            private readonly ContainerBuilder _builder;

            public SubScopePlaceholderFactoryBuilder(ContainerBuilder builder)
            {
                _builder = builder ?? throw new ArgumentNullException(nameof(builder));
            }

            public IRegistrationBuilder<TPlaceholderFactory, SimpleActivatorData, SingleRegistrationStyle>
                FromFunction(Action<ContainerBuilder> subScopeInstaller)
            {
                throw new NotImplementedException();
            }

            public IRegistrationBuilder<TPlaceholderFactory, SimpleActivatorData, SingleRegistrationStyle>
                FromInstaller<TInstaller>(TInstaller installer)
                where TInstaller : class, IInstaller
            {
                throw new NotImplementedException();
            }
        }

        public class SubScopeFactoryBuilder<TInstance> : ISubScopeFactoryBuilder<TInstance, IFactory<TInstance>, ConcreteReflectionActivatorData>
            where TInstance : IDisposable
        {
            private readonly ContainerBuilder _builder;

            public SubScopeFactoryBuilder(ContainerBuilder builder)
            {
                _builder = builder ?? throw new ArgumentNullException(nameof(builder));
            }

            public IRegistrationBuilder<IFactory<TInstance>, ConcreteReflectionActivatorData, SingleRegistrationStyle>
                FromFunction(
                Action<ContainerBuilder> subScopeInstaller)
            {
                return _builder
                    .RegisterType<Entities.Factories.DIExtensions.AutofacSubScopeFactory<TInstance>>()
                    .WithParameters(TypedParameter.From(subScopeInstaller))
                    .As<IFactory<TInstance>>();
            }

            public IRegistrationBuilder<IFactory<TInstance>, ConcreteReflectionActivatorData, SingleRegistrationStyle>
                FromInstaller<TInstaller>(
                TInstaller installer)
                where TInstaller : class, IInstaller
            {
                return _builder
                    .RegisterType<Entities.Factories.DIExtensions.AutofacSubScopeInstallerFactory<TInstance, TInstaller>>()
                    .As<IFactory<TInstance>>();
            }
        }

        public static IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle>
            WithParameters<TLimit, TReflectionActivatorData, TStyle>(
                this IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle> registration,
                params Parameter[] parameters)
            where TReflectionActivatorData : ReflectionActivatorData
        {
            if (parameters is null)
                throw new ArgumentNullException(nameof(parameters));

            if (registration is null)
                throw new ArgumentNullException(nameof(registration));

            return registration
                .WithParameters(parameters.AsEnumerable());
        }

        public static T CreateInstance<T>(this IServiceProvider provider, params object[] parameters)
            where T : class
        {
            if (provider is null)
                throw new ArgumentNullException(nameof(provider));

            return ActivatorUtilities.CreateInstance<T>(provider, parameters);
        }

        public static IServiceProvider AsServiceProvider(this IComponentContext scope)
        {
            if (scope is null)
                throw new ArgumentNullException(nameof(scope));

            return new ContainerWrapper(scope);
        }

        public static T CreateInstance<T>(this IComponentContext scope, params object[] parameters)
            where T : class
        {
            if (scope is null)
                throw new ArgumentNullException(nameof(scope));

            return scope.AsServiceProvider().CreateInstance<T>(parameters);
        }

        public static IExtendedRegistrationBuilder<T> RegisterExtended<T>(this ContainerBuilder builder)
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return new ExtendedRegistrationBuilder<T>(builder);
        }

        [Obsolete("use RegisterExtended")]
        public static IRegistrationBuilder<
            TComponent,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterFromSubScope<TComponent>(
            this ContainerBuilder builder,
            Action<ContainerBuilder> subScopeInstaller)
            where TComponent : IDisposable
        {
            return RegisterExtended<TComponent>(builder)
                .FromSubScope<TComponent>()
                .FromFunction(subScopeInstaller);
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public static void OverrideExternallyOwnedInScope<T>(this ContainerBuilder builder, object scopeTag)
        {
            var module = new OverrideExternallyOwnedModule<T>(scopeTag);

            builder.RegisterModule(module);
        }

        public class OverrideExternallyOwnedModule<T> : Module
        {
            [CanBeNull]
            private readonly object _tag;

            public OverrideExternallyOwnedModule([CanBeNull] object tag)
            {
                _tag = tag;
            }

            protected override void AttachToComponentRegistration(
                IComponentRegistryBuilder componentRegistryBuilder,
                IComponentRegistration registration)
            {
                if (registration.Ownership == InstanceOwnership.ExternallyOwned)
                    return;

                if (registration != registration.Target)
                    return;

                if (registration.Services
                    .OfType<IServiceWithType>()
                    .All(s => s.ServiceType != typeof(T)))
                    return;

                if (_tag != null &&
                    !registration.MatchingLifetimeScopeTags().Contains(_tag))
                    return;

                var newRegistration = new ComponentRegistration(
                    registration.Id,
                    registration.Activator,
                    registration.Lifetime,
                    registration.Sharing,
                    InstanceOwnership.ExternallyOwned,
                    registration.Services,
                    registration.Metadata);

                componentRegistryBuilder.Register(newRegistration);
            }
        }

        internal class ContainerWrapper : IServiceProvider
        {
            private readonly IComponentContext _context;

            public ContainerWrapper(IComponentContext context)
            {
                _context = context;
            }

            [CanBeNull]
            public object GetService(Type serviceType)
            {
                // The method must return null if the service is not registered, otherwise, 'ActivatorUtilities.CreateInstance' will throw an exception
                _context.TryResolve(serviceType, out var service);
                return service;
            }
        }

        #region RegisterDecorator

        public static IExtendedRegistrationDecoratorBuilder<TDecorator, TService> RegisterDecoratorExtended<TDecorator, TService>(
            this ContainerBuilder builder)
            where TDecorator : TService
            where TService : class
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return new ExtendedRegistrationDecoratorBuilder<TDecorator, TService>(builder);
        }

        [Obsolete("use RegisterDecoratorExtended")]
        public static void RegisterDecoratorFromFunction<TDecorator, TService>(
            this ContainerBuilder builder,
            Func<IComponentContext, TService, TDecorator> createFunction)
            where TDecorator : TService
            where TService : class
        {
            builder
                .RegisterDecoratorExtended<TDecorator, TService>()
                .RegisterDecoratorFromFunction(createFunction);
        }

        [Obsolete("use RegisterDecoratorExtended")]
        public static void RegisterDecoratorFromFunction<TDecorator, TService>(
            this ContainerBuilder builder,
            Func<IComponentContext, TService, TDecorator> createFunction,
            object fromKey,
            [CanBeNull] object toKey = null)
            where TDecorator : TService
            where TService : class
        {
            builder
                .RegisterDecoratorExtended<TDecorator, TService>()
                .RegisterDecoratorFromFunction(createFunction, fromKey, toKey);
        }

        [Obsolete("use RegisterDecoratorExtended")]
        public static void RegisterDecoratorFromSubScope<TDecorator, TService>(
            this ContainerBuilder builder,
            Action<ContainerBuilder, TService> subScopeInstaller)
            where TService : class
            where TDecorator : TService, IDisposable
        {
            builder
                .RegisterDecoratorExtended<TDecorator, TService>()
                .FromSubScope<TDecorator>()
                .FromFunction(subScopeInstaller);
        }

        [Obsolete("use RegisterDecoratorExtended")]
        public static void RegisterDecoratorFromSubScope<TDecorator, TService>(
            this ContainerBuilder builder,
            Action<ContainerBuilder, TService> subScopeInstaller,
            object fromKey,
            [CanBeNull] object toKey = null)
            where TDecorator : TService, IDisposable
            where TService : class
        {
            builder
                .RegisterDecoratorExtended<TDecorator, TService>()
                .FromSubScope<TDecorator>()
                .FromFunction(subScopeInstaller, fromKey, toKey);
        }

        #endregion
    }
}