using System;
using Autofac;
using Autofac.Core;
using Autofac2ZenjectLikeBridge.Extensions.HarmonyPatcher;
using Autofac2ZenjectLikeBridge.Interfaces;
using JetBrains.Annotations;

namespace Autofac2ZenjectLikeBridge
{
    public static partial class DIExtensions
    {
        //generated amount 10

        public static TComponent ResolveFromSubScope<TComponent>(
            this ILifetimeScope scope,
            Action<ContainerBuilder> subScopeInstaller)
            where TComponent : IDisposable
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
                .AddToHarmony(service);

            return service;
        }

        public static TComponent ResolveFromSubScope<TP0, TComponent>(
            this ILifetimeScope scope,
            Action<ContainerBuilder, TP0> subScopeInstaller,
			TP0 param0)
            where TComponent : IDisposable
        {
            var guid = Guid.NewGuid();

            var subScope = scope
                .BeginLifetimeScope(
                    guid,
                    scopeBuilder =>
                    {
                        scopeBuilder.OverrideExternallyOwnedInScope<TComponent>(guid);
                        subScopeInstaller(scopeBuilder,
							param0);
                    });

            var service = subScope.Resolve<TComponent>();

            subScope
                .AddToHarmony(service);

            return service;
        }

        public static TComponent ResolveFromSubScope<TP0, TP1, TComponent>(
            this ILifetimeScope scope,
            Action<ContainerBuilder, TP0, TP1> subScopeInstaller,
			TP0 param0,
			TP1 param1)
            where TComponent : IDisposable
        {
            var guid = Guid.NewGuid();

            var subScope = scope
                .BeginLifetimeScope(
                    guid,
                    scopeBuilder =>
                    {
                        scopeBuilder.OverrideExternallyOwnedInScope<TComponent>(guid);
                        subScopeInstaller(scopeBuilder,
							param0,
							param1);
                    });

            var service = subScope.Resolve<TComponent>();

            subScope
                .AddToHarmony(service);

            return service;
        }

        public static TComponent ResolveFromSubScope<TP0, TP1, TP2, TComponent>(
            this ILifetimeScope scope,
            Action<ContainerBuilder, TP0, TP1, TP2> subScopeInstaller,
			TP0 param0,
			TP1 param1,
			TP2 param2)
            where TComponent : IDisposable
        {
            var guid = Guid.NewGuid();

            var subScope = scope
                .BeginLifetimeScope(
                    guid,
                    scopeBuilder =>
                    {
                        scopeBuilder.OverrideExternallyOwnedInScope<TComponent>(guid);
                        subScopeInstaller(scopeBuilder,
							param0,
							param1,
							param2);
                    });

            var service = subScope.Resolve<TComponent>();

            subScope
                .AddToHarmony(service);

            return service;
        }

        public static TComponent ResolveFromSubScope<TP0, TP1, TP2, TP3, TComponent>(
            this ILifetimeScope scope,
            Action<ContainerBuilder, TP0, TP1, TP2, TP3> subScopeInstaller,
			TP0 param0,
			TP1 param1,
			TP2 param2,
			TP3 param3)
            where TComponent : IDisposable
        {
            var guid = Guid.NewGuid();

            var subScope = scope
                .BeginLifetimeScope(
                    guid,
                    scopeBuilder =>
                    {
                        scopeBuilder.OverrideExternallyOwnedInScope<TComponent>(guid);
                        subScopeInstaller(scopeBuilder,
							param0,
							param1,
							param2,
							param3);
                    });

            var service = subScope.Resolve<TComponent>();

            subScope
                .AddToHarmony(service);

            return service;
        }

        public static TComponent ResolveFromSubScope<TP0, TP1, TP2, TP3, TP4, TComponent>(
            this ILifetimeScope scope,
            Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4> subScopeInstaller,
			TP0 param0,
			TP1 param1,
			TP2 param2,
			TP3 param3,
			TP4 param4)
            where TComponent : IDisposable
        {
            var guid = Guid.NewGuid();

            var subScope = scope
                .BeginLifetimeScope(
                    guid,
                    scopeBuilder =>
                    {
                        scopeBuilder.OverrideExternallyOwnedInScope<TComponent>(guid);
                        subScopeInstaller(scopeBuilder,
							param0,
							param1,
							param2,
							param3,
							param4);
                    });

            var service = subScope.Resolve<TComponent>();

            subScope
                .AddToHarmony(service);

            return service;
        }

        public static TComponent ResolveFromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TComponent>(
            this ILifetimeScope scope,
            Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5> subScopeInstaller,
			TP0 param0,
			TP1 param1,
			TP2 param2,
			TP3 param3,
			TP4 param4,
			TP5 param5)
            where TComponent : IDisposable
        {
            var guid = Guid.NewGuid();

            var subScope = scope
                .BeginLifetimeScope(
                    guid,
                    scopeBuilder =>
                    {
                        scopeBuilder.OverrideExternallyOwnedInScope<TComponent>(guid);
                        subScopeInstaller(scopeBuilder,
							param0,
							param1,
							param2,
							param3,
							param4,
							param5);
                    });

            var service = subScope.Resolve<TComponent>();

            subScope
                .AddToHarmony(service);

            return service;
        }

        public static TComponent ResolveFromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TComponent>(
            this ILifetimeScope scope,
            Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6> subScopeInstaller,
			TP0 param0,
			TP1 param1,
			TP2 param2,
			TP3 param3,
			TP4 param4,
			TP5 param5,
			TP6 param6)
            where TComponent : IDisposable
        {
            var guid = Guid.NewGuid();

            var subScope = scope
                .BeginLifetimeScope(
                    guid,
                    scopeBuilder =>
                    {
                        scopeBuilder.OverrideExternallyOwnedInScope<TComponent>(guid);
                        subScopeInstaller(scopeBuilder,
							param0,
							param1,
							param2,
							param3,
							param4,
							param5,
							param6);
                    });

            var service = subScope.Resolve<TComponent>();

            subScope
                .AddToHarmony(service);

            return service;
        }

        public static TComponent ResolveFromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TComponent>(
            this ILifetimeScope scope,
            Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7> subScopeInstaller,
			TP0 param0,
			TP1 param1,
			TP2 param2,
			TP3 param3,
			TP4 param4,
			TP5 param5,
			TP6 param6,
			TP7 param7)
            where TComponent : IDisposable
        {
            var guid = Guid.NewGuid();

            var subScope = scope
                .BeginLifetimeScope(
                    guid,
                    scopeBuilder =>
                    {
                        scopeBuilder.OverrideExternallyOwnedInScope<TComponent>(guid);
                        subScopeInstaller(scopeBuilder,
							param0,
							param1,
							param2,
							param3,
							param4,
							param5,
							param6,
							param7);
                    });

            var service = subScope.Resolve<TComponent>();

            subScope
                .AddToHarmony(service);

            return service;
        }

        public static TComponent ResolveFromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TComponent>(
            this ILifetimeScope scope,
            Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8> subScopeInstaller,
			TP0 param0,
			TP1 param1,
			TP2 param2,
			TP3 param3,
			TP4 param4,
			TP5 param5,
			TP6 param6,
			TP7 param7,
			TP8 param8)
            where TComponent : IDisposable
        {
            var guid = Guid.NewGuid();

            var subScope = scope
                .BeginLifetimeScope(
                    guid,
                    scopeBuilder =>
                    {
                        scopeBuilder.OverrideExternallyOwnedInScope<TComponent>(guid);
                        subScopeInstaller(scopeBuilder,
							param0,
							param1,
							param2,
							param3,
							param4,
							param5,
							param6,
							param7,
							param8);
                    });

            var service = subScope.Resolve<TComponent>();

            subScope
                .AddToHarmony(service);

            return service;
        }

        public static TComponent ResolveFromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TComponent>(
            this ILifetimeScope scope,
            Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9> subScopeInstaller,
			TP0 param0,
			TP1 param1,
			TP2 param2,
			TP3 param3,
			TP4 param4,
			TP5 param5,
			TP6 param6,
			TP7 param7,
			TP8 param8,
			TP9 param9)
            where TComponent : IDisposable
        {
            var guid = Guid.NewGuid();

            var subScope = scope
                .BeginLifetimeScope(
                    guid,
                    scopeBuilder =>
                    {
                        scopeBuilder.OverrideExternallyOwnedInScope<TComponent>(guid);
                        subScopeInstaller(scopeBuilder,
							param0,
							param1,
							param2,
							param3,
							param4,
							param5,
							param6,
							param7,
							param8,
							param9);
                    });

            var service = subScope.Resolve<TComponent>();

            subScope
                .AddToHarmony(service);

            return service;
        }


        public static TComponent ResolveFromModuleSubScope<TComponent, TModule>(
            this ILifetimeScope scope,
            [CanBeNull] Func<ILifetimeScope, TModule> moduleFactory = null)
            where TComponent : IDisposable
            where TModule : class, IModule
        {
            var guid = Guid.NewGuid();

            var subScope = scope
                .BeginLifetimeScope(
                    guid,
                    scopeBuilder =>
                    {
                        scopeBuilder.OverrideExternallyOwnedInScope<TComponent>(guid);
                        var module = moduleFactory == null
                            ? scope.CreateInstance<TModule>()
                            : moduleFactory.Invoke(scope);
                        scopeBuilder.RegisterModule(module);
                    });

            var service = subScope.Resolve<TComponent>();

            subScope
                .AddToHarmony(service);

            return service;
        }
        public static TComponent ResolveFromModuleSubScope<TP0, TComponent, TModule>(
            this ILifetimeScope scope,
			TP0 param0,
            [CanBeNull] Func<ILifetimeScope, TP0, TModule> moduleFactory = null)
            where TComponent : IDisposable
            where TModule : class, IModule
        {
            var guid = Guid.NewGuid();

            var subScope = scope
                .BeginLifetimeScope(
                    guid,
                    scopeBuilder =>
                    {
                        scopeBuilder.OverrideExternallyOwnedInScope<TComponent>(guid);
                        var module = moduleFactory == null
                            ? scope.CreateInstance<TModule>(param0)
                            : moduleFactory.Invoke(scope, param0);
                        scopeBuilder.RegisterModule(module);
                    });

            var service = subScope.Resolve<TComponent>();

            subScope
                .AddToHarmony(service);

            return service;
        }
        public static TComponent ResolveFromModuleSubScope<TP0, TP1, TComponent, TModule>(
            this ILifetimeScope scope,
			TP0 param0,
			TP1 param1,
            [CanBeNull] Func<ILifetimeScope, TP0, TP1, TModule> moduleFactory = null)
            where TComponent : IDisposable
            where TModule : class, IModule
        {
            var guid = Guid.NewGuid();

            var subScope = scope
                .BeginLifetimeScope(
                    guid,
                    scopeBuilder =>
                    {
                        scopeBuilder.OverrideExternallyOwnedInScope<TComponent>(guid);
                        var module = moduleFactory == null
                            ? scope.CreateInstance<TModule>(param0,
							param1)
                            : moduleFactory.Invoke(scope, param0, param1);
                        scopeBuilder.RegisterModule(module);
                    });

            var service = subScope.Resolve<TComponent>();

            subScope
                .AddToHarmony(service);

            return service;
        }
        public static TComponent ResolveFromModuleSubScope<TP0, TP1, TP2, TComponent, TModule>(
            this ILifetimeScope scope,
			TP0 param0,
			TP1 param1,
			TP2 param2,
            [CanBeNull] Func<ILifetimeScope, TP0, TP1, TP2, TModule> moduleFactory = null)
            where TComponent : IDisposable
            where TModule : class, IModule
        {
            var guid = Guid.NewGuid();

            var subScope = scope
                .BeginLifetimeScope(
                    guid,
                    scopeBuilder =>
                    {
                        scopeBuilder.OverrideExternallyOwnedInScope<TComponent>(guid);
                        var module = moduleFactory == null
                            ? scope.CreateInstance<TModule>(param0,
							param1,
							param2)
                            : moduleFactory.Invoke(scope, param0, param1, param2);
                        scopeBuilder.RegisterModule(module);
                    });

            var service = subScope.Resolve<TComponent>();

            subScope
                .AddToHarmony(service);

            return service;
        }
        public static TComponent ResolveFromModuleSubScope<TP0, TP1, TP2, TP3, TComponent, TModule>(
            this ILifetimeScope scope,
			TP0 param0,
			TP1 param1,
			TP2 param2,
			TP3 param3,
            [CanBeNull] Func<ILifetimeScope, TP0, TP1, TP2, TP3, TModule> moduleFactory = null)
            where TComponent : IDisposable
            where TModule : class, IModule
        {
            var guid = Guid.NewGuid();

            var subScope = scope
                .BeginLifetimeScope(
                    guid,
                    scopeBuilder =>
                    {
                        scopeBuilder.OverrideExternallyOwnedInScope<TComponent>(guid);
                        var module = moduleFactory == null
                            ? scope.CreateInstance<TModule>(param0,
							param1,
							param2,
							param3)
                            : moduleFactory.Invoke(scope, param0, param1, param2, param3);
                        scopeBuilder.RegisterModule(module);
                    });

            var service = subScope.Resolve<TComponent>();

            subScope
                .AddToHarmony(service);

            return service;
        }
        public static TComponent ResolveFromModuleSubScope<TP0, TP1, TP2, TP3, TP4, TComponent, TModule>(
            this ILifetimeScope scope,
			TP0 param0,
			TP1 param1,
			TP2 param2,
			TP3 param3,
			TP4 param4,
            [CanBeNull] Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TModule> moduleFactory = null)
            where TComponent : IDisposable
            where TModule : class, IModule
        {
            var guid = Guid.NewGuid();

            var subScope = scope
                .BeginLifetimeScope(
                    guid,
                    scopeBuilder =>
                    {
                        scopeBuilder.OverrideExternallyOwnedInScope<TComponent>(guid);
                        var module = moduleFactory == null
                            ? scope.CreateInstance<TModule>(param0,
							param1,
							param2,
							param3,
							param4)
                            : moduleFactory.Invoke(scope, param0, param1, param2, param3, param4);
                        scopeBuilder.RegisterModule(module);
                    });

            var service = subScope.Resolve<TComponent>();

            subScope
                .AddToHarmony(service);

            return service;
        }
        public static TComponent ResolveFromModuleSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TComponent, TModule>(
            this ILifetimeScope scope,
			TP0 param0,
			TP1 param1,
			TP2 param2,
			TP3 param3,
			TP4 param4,
			TP5 param5,
            [CanBeNull] Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TModule> moduleFactory = null)
            where TComponent : IDisposable
            where TModule : class, IModule
        {
            var guid = Guid.NewGuid();

            var subScope = scope
                .BeginLifetimeScope(
                    guid,
                    scopeBuilder =>
                    {
                        scopeBuilder.OverrideExternallyOwnedInScope<TComponent>(guid);
                        var module = moduleFactory == null
                            ? scope.CreateInstance<TModule>(param0,
							param1,
							param2,
							param3,
							param4,
							param5)
                            : moduleFactory.Invoke(scope, param0, param1, param2, param3, param4, param5);
                        scopeBuilder.RegisterModule(module);
                    });

            var service = subScope.Resolve<TComponent>();

            subScope
                .AddToHarmony(service);

            return service;
        }
        public static TComponent ResolveFromModuleSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TComponent, TModule>(
            this ILifetimeScope scope,
			TP0 param0,
			TP1 param1,
			TP2 param2,
			TP3 param3,
			TP4 param4,
			TP5 param5,
			TP6 param6,
            [CanBeNull] Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TModule> moduleFactory = null)
            where TComponent : IDisposable
            where TModule : class, IModule
        {
            var guid = Guid.NewGuid();

            var subScope = scope
                .BeginLifetimeScope(
                    guid,
                    scopeBuilder =>
                    {
                        scopeBuilder.OverrideExternallyOwnedInScope<TComponent>(guid);
                        var module = moduleFactory == null
                            ? scope.CreateInstance<TModule>(param0,
							param1,
							param2,
							param3,
							param4,
							param5,
							param6)
                            : moduleFactory.Invoke(scope, param0, param1, param2, param3, param4, param5, param6);
                        scopeBuilder.RegisterModule(module);
                    });

            var service = subScope.Resolve<TComponent>();

            subScope
                .AddToHarmony(service);

            return service;
        }
        public static TComponent ResolveFromModuleSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TComponent, TModule>(
            this ILifetimeScope scope,
			TP0 param0,
			TP1 param1,
			TP2 param2,
			TP3 param3,
			TP4 param4,
			TP5 param5,
			TP6 param6,
			TP7 param7,
            [CanBeNull] Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TModule> moduleFactory = null)
            where TComponent : IDisposable
            where TModule : class, IModule
        {
            var guid = Guid.NewGuid();

            var subScope = scope
                .BeginLifetimeScope(
                    guid,
                    scopeBuilder =>
                    {
                        scopeBuilder.OverrideExternallyOwnedInScope<TComponent>(guid);
                        var module = moduleFactory == null
                            ? scope.CreateInstance<TModule>(param0,
							param1,
							param2,
							param3,
							param4,
							param5,
							param6,
							param7)
                            : moduleFactory.Invoke(scope, param0, param1, param2, param3, param4, param5, param6, param7);
                        scopeBuilder.RegisterModule(module);
                    });

            var service = subScope.Resolve<TComponent>();

            subScope
                .AddToHarmony(service);

            return service;
        }
        public static TComponent ResolveFromModuleSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TComponent, TModule>(
            this ILifetimeScope scope,
			TP0 param0,
			TP1 param1,
			TP2 param2,
			TP3 param3,
			TP4 param4,
			TP5 param5,
			TP6 param6,
			TP7 param7,
			TP8 param8,
            [CanBeNull] Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TModule> moduleFactory = null)
            where TComponent : IDisposable
            where TModule : class, IModule
        {
            var guid = Guid.NewGuid();

            var subScope = scope
                .BeginLifetimeScope(
                    guid,
                    scopeBuilder =>
                    {
                        scopeBuilder.OverrideExternallyOwnedInScope<TComponent>(guid);
                        var module = moduleFactory == null
                            ? scope.CreateInstance<TModule>(param0,
							param1,
							param2,
							param3,
							param4,
							param5,
							param6,
							param7,
							param8)
                            : moduleFactory.Invoke(scope, param0, param1, param2, param3, param4, param5, param6, param7, param8);
                        scopeBuilder.RegisterModule(module);
                    });

            var service = subScope.Resolve<TComponent>();

            subScope
                .AddToHarmony(service);

            return service;
        }
        public static TComponent ResolveFromModuleSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TComponent, TModule>(
            this ILifetimeScope scope,
			TP0 param0,
			TP1 param1,
			TP2 param2,
			TP3 param3,
			TP4 param4,
			TP5 param5,
			TP6 param6,
			TP7 param7,
			TP8 param8,
			TP9 param9,
            [CanBeNull] Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TModule> moduleFactory = null)
            where TComponent : IDisposable
            where TModule : class, IModule
        {
            var guid = Guid.NewGuid();

            var subScope = scope
                .BeginLifetimeScope(
                    guid,
                    scopeBuilder =>
                    {
                        scopeBuilder.OverrideExternallyOwnedInScope<TComponent>(guid);
                        var module = moduleFactory == null
                            ? scope.CreateInstance<TModule>(param0,
							param1,
							param2,
							param3,
							param4,
							param5,
							param6,
							param7,
							param8,
							param9)
                            : moduleFactory.Invoke(scope, param0, param1, param2, param3, param4, param5, param6, param7, param8, param9);
                        scopeBuilder.RegisterModule(module);
                    });

            var service = subScope.Resolve<TComponent>();

            subScope
                .AddToHarmony(service);

            return service;
        }

    }
}