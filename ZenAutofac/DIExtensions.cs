using System;
using System.Linq;
using Autofac;
using Autofac.Builder;
using Autofac.Core;
using Autofac.Core.Registration;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using ZenAutofac.Builders.Decorator;
using ZenAutofac.Builders.Instance;
using ZenAutofac.Interfaces.Builders.Decorator;
using ZenAutofac.Interfaces.Builders.Instance;
using Module = Autofac.Module;

namespace ZenAutofac
{
    public static partial class DIExtensions
    {
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
            where T : class
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return new ExtendedRegistrationBuilder<T>(builder);
        }

        public static ISubScopeRegistrationBuilder<T> FromSubScope<T>(
            this IExtendedRegistrationBuilder<T> builder)
            where T : class, IDisposable
        {
            return new SubScopeRegistrationBuilder<T>(builder.Builder);
        }

        public static ISubScopeDecoratorBuilder<TDecorator, TService> FromSubScope<TDecorator, TService>(
            this IExtendedDecoratorBuilder<TDecorator, TService> builder)
            where TDecorator : TService, IDisposable
            where TService : class
        {
            return new SubScopeDecoratorBuilder<TDecorator, TService>(builder.Builder);
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public static void OverrideExternallyOwnedInScope<T>(this ContainerBuilder builder, object scopeTag)
        {
            var module = new OverrideExternallyOwnedModule<T>(scopeTag);

            builder.RegisterModule(module);
        }

        public static IExtendedDecoratorBuilder<TDecorator, TService> RegisterDecoratorExtended<TDecorator, TService>(
            this ContainerBuilder builder)
            where TDecorator : TService
            where TService : class
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return new ExtendedDecoratorBuilder<TDecorator, TService>(builder);
        }

        public class OverrideExternallyOwnedModule<T> : Module
        {
            [CanBeNull] private readonly object _tag;

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
    }
}