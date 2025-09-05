using System;
using Autofac;
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



        public static TComponent ResolveFromSubScope<TComponent, TInstaller>(
            this ILifetimeScope scope,
            [CanBeNull] Func<ContainerBuilder, TInstaller> installerFactory = null)
            where TComponent : IDisposable
            where TInstaller : class, IInstaller
        {
            var guid = Guid.NewGuid();

            var subScope = scope
                .BeginLifetimeScope(
                    guid,
                    scopeBuilder =>
                    {
                        scopeBuilder.OverrideExternallyOwnedInScope<TComponent>(guid);
                        var installerInstance = installerFactory == null
                            ? scope.CreateInstance<TInstaller>(scopeBuilder)
                            : installerFactory.Invoke(scopeBuilder);
                        installerInstance.Install();
                    });

            var service = subScope.Resolve<TComponent>();

            subScope
                .AddToHarmony(service);

            return service;
        }


        public static TComponent ResolveFromSubScope<TP0, TComponent, TInstaller>(
            this ILifetimeScope scope,
			TP0 param0,
            [CanBeNull] Func<ContainerBuilder, TP0, TInstaller> installerFactory = null)
            where TComponent : IDisposable
            where TInstaller : class, IInstaller
        {
            var guid = Guid.NewGuid();

            var subScope = scope
                .BeginLifetimeScope(
                    guid,
                    scopeBuilder =>
                    {
                        scopeBuilder.OverrideExternallyOwnedInScope<TComponent>(guid);
                        var installerInstance = installerFactory == null
                            ? scope.CreateInstance<TInstaller>(scopeBuilder,
							param0)
                            : installerFactory.Invoke(scopeBuilder, param0);
                        installerInstance.Install();
                    });

            var service = subScope.Resolve<TComponent>();

            subScope
                .AddToHarmony(service);

            return service;
        }


        public static TComponent ResolveFromSubScope<TP0, TP1, TComponent, TInstaller>(
            this ILifetimeScope scope,
			TP0 param0,
			TP1 param1,
            [CanBeNull] Func<ContainerBuilder, TP0, TP1, TInstaller> installerFactory = null)
            where TComponent : IDisposable
            where TInstaller : class, IInstaller
        {
            var guid = Guid.NewGuid();

            var subScope = scope
                .BeginLifetimeScope(
                    guid,
                    scopeBuilder =>
                    {
                        scopeBuilder.OverrideExternallyOwnedInScope<TComponent>(guid);
                        var installerInstance = installerFactory == null
                            ? scope.CreateInstance<TInstaller>(scopeBuilder,
							param0,
							param1)
                            : installerFactory.Invoke(scopeBuilder, param0, param1);
                        installerInstance.Install();
                    });

            var service = subScope.Resolve<TComponent>();

            subScope
                .AddToHarmony(service);

            return service;
        }


        public static TComponent ResolveFromSubScope<TP0, TP1, TP2, TComponent, TInstaller>(
            this ILifetimeScope scope,
			TP0 param0,
			TP1 param1,
			TP2 param2,
            [CanBeNull] Func<ContainerBuilder, TP0, TP1, TP2, TInstaller> installerFactory = null)
            where TComponent : IDisposable
            where TInstaller : class, IInstaller
        {
            var guid = Guid.NewGuid();

            var subScope = scope
                .BeginLifetimeScope(
                    guid,
                    scopeBuilder =>
                    {
                        scopeBuilder.OverrideExternallyOwnedInScope<TComponent>(guid);
                        var installerInstance = installerFactory == null
                            ? scope.CreateInstance<TInstaller>(scopeBuilder,
							param0,
							param1,
							param2)
                            : installerFactory.Invoke(scopeBuilder, param0, param1, param2);
                        installerInstance.Install();
                    });

            var service = subScope.Resolve<TComponent>();

            subScope
                .AddToHarmony(service);

            return service;
        }


        public static TComponent ResolveFromSubScope<TP0, TP1, TP2, TP3, TComponent, TInstaller>(
            this ILifetimeScope scope,
			TP0 param0,
			TP1 param1,
			TP2 param2,
			TP3 param3,
            [CanBeNull] Func<ContainerBuilder, TP0, TP1, TP2, TP3, TInstaller> installerFactory = null)
            where TComponent : IDisposable
            where TInstaller : class, IInstaller
        {
            var guid = Guid.NewGuid();

            var subScope = scope
                .BeginLifetimeScope(
                    guid,
                    scopeBuilder =>
                    {
                        scopeBuilder.OverrideExternallyOwnedInScope<TComponent>(guid);
                        var installerInstance = installerFactory == null
                            ? scope.CreateInstance<TInstaller>(scopeBuilder,
							param0,
							param1,
							param2,
							param3)
                            : installerFactory.Invoke(scopeBuilder, param0, param1, param2, param3);
                        installerInstance.Install();
                    });

            var service = subScope.Resolve<TComponent>();

            subScope
                .AddToHarmony(service);

            return service;
        }


        public static TComponent ResolveFromSubScope<TP0, TP1, TP2, TP3, TP4, TComponent, TInstaller>(
            this ILifetimeScope scope,
			TP0 param0,
			TP1 param1,
			TP2 param2,
			TP3 param3,
			TP4 param4,
            [CanBeNull] Func<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TInstaller> installerFactory = null)
            where TComponent : IDisposable
            where TInstaller : class, IInstaller
        {
            var guid = Guid.NewGuid();

            var subScope = scope
                .BeginLifetimeScope(
                    guid,
                    scopeBuilder =>
                    {
                        scopeBuilder.OverrideExternallyOwnedInScope<TComponent>(guid);
                        var installerInstance = installerFactory == null
                            ? scope.CreateInstance<TInstaller>(scopeBuilder,
							param0,
							param1,
							param2,
							param3,
							param4)
                            : installerFactory.Invoke(scopeBuilder, param0, param1, param2, param3, param4);
                        installerInstance.Install();
                    });

            var service = subScope.Resolve<TComponent>();

            subScope
                .AddToHarmony(service);

            return service;
        }


        public static TComponent ResolveFromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TComponent, TInstaller>(
            this ILifetimeScope scope,
			TP0 param0,
			TP1 param1,
			TP2 param2,
			TP3 param3,
			TP4 param4,
			TP5 param5,
            [CanBeNull] Func<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TInstaller> installerFactory = null)
            where TComponent : IDisposable
            where TInstaller : class, IInstaller
        {
            var guid = Guid.NewGuid();

            var subScope = scope
                .BeginLifetimeScope(
                    guid,
                    scopeBuilder =>
                    {
                        scopeBuilder.OverrideExternallyOwnedInScope<TComponent>(guid);
                        var installerInstance = installerFactory == null
                            ? scope.CreateInstance<TInstaller>(scopeBuilder,
							param0,
							param1,
							param2,
							param3,
							param4,
							param5)
                            : installerFactory.Invoke(scopeBuilder, param0, param1, param2, param3, param4, param5);
                        installerInstance.Install();
                    });

            var service = subScope.Resolve<TComponent>();

            subScope
                .AddToHarmony(service);

            return service;
        }


        public static TComponent ResolveFromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TComponent, TInstaller>(
            this ILifetimeScope scope,
			TP0 param0,
			TP1 param1,
			TP2 param2,
			TP3 param3,
			TP4 param4,
			TP5 param5,
			TP6 param6,
            [CanBeNull] Func<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstaller> installerFactory = null)
            where TComponent : IDisposable
            where TInstaller : class, IInstaller
        {
            var guid = Guid.NewGuid();

            var subScope = scope
                .BeginLifetimeScope(
                    guid,
                    scopeBuilder =>
                    {
                        scopeBuilder.OverrideExternallyOwnedInScope<TComponent>(guid);
                        var installerInstance = installerFactory == null
                            ? scope.CreateInstance<TInstaller>(scopeBuilder,
							param0,
							param1,
							param2,
							param3,
							param4,
							param5,
							param6)
                            : installerFactory.Invoke(scopeBuilder, param0, param1, param2, param3, param4, param5, param6);
                        installerInstance.Install();
                    });

            var service = subScope.Resolve<TComponent>();

            subScope
                .AddToHarmony(service);

            return service;
        }


        public static TComponent ResolveFromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TComponent, TInstaller>(
            this ILifetimeScope scope,
			TP0 param0,
			TP1 param1,
			TP2 param2,
			TP3 param3,
			TP4 param4,
			TP5 param5,
			TP6 param6,
			TP7 param7,
            [CanBeNull] Func<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstaller> installerFactory = null)
            where TComponent : IDisposable
            where TInstaller : class, IInstaller
        {
            var guid = Guid.NewGuid();

            var subScope = scope
                .BeginLifetimeScope(
                    guid,
                    scopeBuilder =>
                    {
                        scopeBuilder.OverrideExternallyOwnedInScope<TComponent>(guid);
                        var installerInstance = installerFactory == null
                            ? scope.CreateInstance<TInstaller>(scopeBuilder,
							param0,
							param1,
							param2,
							param3,
							param4,
							param5,
							param6,
							param7)
                            : installerFactory.Invoke(scopeBuilder, param0, param1, param2, param3, param4, param5, param6, param7);
                        installerInstance.Install();
                    });

            var service = subScope.Resolve<TComponent>();

            subScope
                .AddToHarmony(service);

            return service;
        }


        public static TComponent ResolveFromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TComponent, TInstaller>(
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
            [CanBeNull] Func<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstaller> installerFactory = null)
            where TComponent : IDisposable
            where TInstaller : class, IInstaller
        {
            var guid = Guid.NewGuid();

            var subScope = scope
                .BeginLifetimeScope(
                    guid,
                    scopeBuilder =>
                    {
                        scopeBuilder.OverrideExternallyOwnedInScope<TComponent>(guid);
                        var installerInstance = installerFactory == null
                            ? scope.CreateInstance<TInstaller>(scopeBuilder,
							param0,
							param1,
							param2,
							param3,
							param4,
							param5,
							param6,
							param7,
							param8)
                            : installerFactory.Invoke(scopeBuilder, param0, param1, param2, param3, param4, param5, param6, param7, param8);
                        installerInstance.Install();
                    });

            var service = subScope.Resolve<TComponent>();

            subScope
                .AddToHarmony(service);

            return service;
        }


        public static TComponent ResolveFromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TComponent, TInstaller>(
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
            [CanBeNull] Func<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstaller> installerFactory = null)
            where TComponent : IDisposable
            where TInstaller : class, IInstaller
        {
            var guid = Guid.NewGuid();

            var subScope = scope
                .BeginLifetimeScope(
                    guid,
                    scopeBuilder =>
                    {
                        scopeBuilder.OverrideExternallyOwnedInScope<TComponent>(guid);
                        var installerInstance = installerFactory == null
                            ? scope.CreateInstance<TInstaller>(scopeBuilder,
							param0,
							param1,
							param2,
							param3,
							param4,
							param5,
							param6,
							param7,
							param8,
							param9)
                            : installerFactory.Invoke(scopeBuilder, param0, param1, param2, param3, param4, param5, param6, param7, param8, param9);
                        installerInstance.Install();
                    });

            var service = subScope.Resolve<TComponent>();

            subScope
                .AddToHarmony(service);

            return service;
        }


    }
}