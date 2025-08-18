using Autofac;
using Autofac.Builder;
using Autofac.Core;
using Autofac.Core.Registration;
using Autofac2ZenjectLikeBridge.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Autofac2ZenjectLikeBridge;

public static partial class DIExtensions
{
    // public static IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle>
    //     WithParameters<TLimit, TReflectionActivatorData, TStyle>(
    //         this IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle> registration,
    //         params Parameter[] parameters)
    //     where TReflectionActivatorData : ReflectionActivatorData
    // {
    //     ArgumentNullException.ThrowIfNull(parameters);
    //
    //     ArgumentNullException.ThrowIfNull(registration);
    //
    //     return registration
    //         .WithParameters(LinqExtensions.FromParams(parameters));
    // }

    public static T CreateInstance<T>(this IServiceProvider provider, params object[] parameters)
        where T : class
    {
        ArgumentNullException.ThrowIfNull(provider);

        return ActivatorUtilities.CreateInstance<T>(provider, parameters);
    }

    public static IServiceProvider AsServiceProvider(this IComponentContext scope)
    {
        ArgumentNullException.ThrowIfNull(scope);

        return new ContainerWrapper(scope);
    }

    public static T CreateInstance<T>(this IComponentContext scope, params object[] parameters)
        where T : class
    {
        ArgumentNullException.ThrowIfNull(scope);

        return scope.AsServiceProvider().CreateInstance<T>(parameters);
    }

    #region RegisterDecorator

    public static void RegisterDecoratorFromFunction<TDecorator, TService>(
        this ContainerBuilder builder,
        Func<IComponentContext, TService, TDecorator> createFunction)
        where TDecorator : TService
        where TService : class
    {
        builder
            .RegisterDecorator<TService>((context, _, baseHandler) => createFunction(context, baseHandler));
    }

    public static void RegisterDecoratorFromFunction<TDecorator, TService>(
        this ContainerBuilder builder,
        Func<IComponentContext, TService, TDecorator> createFunction,
        object fromKey,
        object? toKey = null)
        where TDecorator : TService
        where TService : class
    {
        builder
            .RegisterDecorator<TService>(
                (context, _, baseHandler) => createFunction(context, baseHandler),
                fromKey,
                toKey);
    }

    public static void RegisterDecoratorFromSubScope<TDecorator, TService>(
        this ContainerBuilder builder,
        Action<ContainerBuilder, TService> subScopeInstaller)
        where TService : class
        where TDecorator : TService, ICollection<IDisposable>, IDisposable
    {
        builder
            .RegisterDecorator<TService>(
                (context, _, nestedService) =>
                {
                    var scope = context.Resolve<ILifetimeScope>();
                    var guid = Guid.NewGuid();

                    var subScope = scope.BeginLifetimeScope(
                        guid,
                        subScopeBuilder =>
                        {
                            subScopeBuilder.OverrideExternallyOwnedInScope<TDecorator>(guid);

                            subScopeInstaller(subScopeBuilder, nestedService);
                        });

                    var instance = subScope.Resolve<TDecorator>();

                    subScope
                        .AddTo(instance);

                    return instance;
                });
    }

    public static void RegisterDecoratorFromSubScope<TDecorator, TService>(
        this ContainerBuilder builder,
        Action<ContainerBuilder, TService> subScopeInstaller,
        object fromKey,
        object? toKey = null)
        where TService : class
        where TDecorator : TService, ICollection<IDisposable>, IDisposable
    {
        builder
            .RegisterDecorator<TService>(
                (context, nestedService) =>
                {
                    var scope = context.Resolve<ILifetimeScope>();
                    var guid = Guid.NewGuid();

                    var subScope = scope.BeginLifetimeScope(
                        guid,
                        subScopeBuilder =>
                        {
                            subScopeBuilder.OverrideExternallyOwnedInScope<TDecorator>(guid);

                            subScopeInstaller(subScopeBuilder, nestedService);
                        });

                    var instance = subScope.Resolve<TDecorator>();

                    subScope
                        .AddTo(instance);

                    return instance;
                },
                fromKey,
                toKey);
    }

    #endregion

    public static IRegistrationBuilder<
        TComponent,
        SimpleActivatorData,
        SingleRegistrationStyle> RegisterFromSubScope<TComponent>(
        this ContainerBuilder builder,
        Action<ContainerBuilder> subScopeInstaller)
        where TComponent : ICollection<IDisposable>, IDisposable
    {
        ArgumentNullException.ThrowIfNull(builder);

        ArgumentNullException.ThrowIfNull(subScopeInstaller);

        return builder
            .Register(
                (IComponentContext _, ILifetimeScope scope) =>
                {
                    var guid = Guid.NewGuid();

                    var subScope = scope
                        .BeginLifetimeScope(
                            guid,
                            scopeBuilder =>
                            {
                                scopeBuilder.OverrideExternallyOwnedInScope<TComponent>(guid);
                                subScopeInstaller(scopeBuilder);
                            });

                    var service = subScope.Resolve<TComponent>();

                    subScope
                        .AddTo(service);

                    return service;
                });
    }

    public static void OverrideExternallyOwnedInScope<T>(this ContainerBuilder builder, object scopeTag)
    {
        var module = new OverrideExternallyOwnedModule<T>(scopeTag);

        builder.RegisterModule(module);
    }

    public class OverrideExternallyOwnedModule<T> : Module
    {
        private readonly object? _tag;

        public OverrideExternallyOwnedModule(object? tag)
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

        public object? GetService(Type serviceType)
        {
            // The method must return null if the service is not registered, otherwise, 'ActivatorUtilities.CreateInstance' will throw an exception
            _context.TryResolve(serviceType, out var service);
            return service;
        }
    }
}