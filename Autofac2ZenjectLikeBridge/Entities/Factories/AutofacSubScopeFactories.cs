using System;
using Autofac;
using Autofac.Core;
using Autofac2ZenjectLikeBridge.Interfaces;
using JetBrains.Annotations;

namespace Autofac2ZenjectLikeBridge.Entities.Factories
{
    public static partial class DIExtensions
    {
        //generated amount 10

        internal class AutofacSubScopeFactory<TInstance>
            : IFactory<TInstance>
            where TInstance : IDisposable
        {
            private readonly ILifetimeScope _scope;
            private readonly Action<ContainerBuilder> _subScopeInstaller;

            public AutofacSubScopeFactory(ILifetimeScope scope,
                Action<ContainerBuilder> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create()
            {
                return _scope.ResolveFromSubScope<TInstance>(_subScopeInstaller);
            }
        }

        internal class AutofacSubScopeFactory<TP0, TInstance>
            : IFactory<TP0, TInstance>
            where TInstance : IDisposable
        {
            private readonly ILifetimeScope _scope;
            private readonly Action<ContainerBuilder, TP0> _subScopeInstaller;

            public AutofacSubScopeFactory(ILifetimeScope scope,
                Action<ContainerBuilder, TP0> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(
				TP0 param0)
            {
                return _scope.ResolveFromSubScope<TP0, TInstance>(_subScopeInstaller,
					param0);
            }
        }

        internal class AutofacSubScopeFactory<TP0, TP1, TInstance>
            : IFactory<TP0, TP1, TInstance>
            where TInstance : IDisposable
        {
            private readonly ILifetimeScope _scope;
            private readonly Action<ContainerBuilder, TP0, TP1> _subScopeInstaller;

            public AutofacSubScopeFactory(ILifetimeScope scope,
                Action<ContainerBuilder, TP0, TP1> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(
				TP0 param0,
				TP1 param1)
            {
                return _scope.ResolveFromSubScope<TP0, TP1, TInstance>(_subScopeInstaller,
					param0,
					param1);
            }
        }

        internal class AutofacSubScopeFactory<TP0, TP1, TP2, TInstance>
            : IFactory<TP0, TP1, TP2, TInstance>
            where TInstance : IDisposable
        {
            private readonly ILifetimeScope _scope;
            private readonly Action<ContainerBuilder, TP0, TP1, TP2> _subScopeInstaller;

            public AutofacSubScopeFactory(ILifetimeScope scope,
                Action<ContainerBuilder, TP0, TP1, TP2> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(
				TP0 param0,
				TP1 param1,
				TP2 param2)
            {
                return _scope.ResolveFromSubScope<TP0, TP1, TP2, TInstance>(_subScopeInstaller,
					param0,
					param1,
					param2);
            }
        }

        internal class AutofacSubScopeFactory<TP0, TP1, TP2, TP3, TInstance>
            : IFactory<TP0, TP1, TP2, TP3, TInstance>
            where TInstance : IDisposable
        {
            private readonly ILifetimeScope _scope;
            private readonly Action<ContainerBuilder, TP0, TP1, TP2, TP3> _subScopeInstaller;

            public AutofacSubScopeFactory(ILifetimeScope scope,
                Action<ContainerBuilder, TP0, TP1, TP2, TP3> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(
				TP0 param0,
				TP1 param1,
				TP2 param2,
				TP3 param3)
            {
                return _scope.ResolveFromSubScope<TP0, TP1, TP2, TP3, TInstance>(_subScopeInstaller,
					param0,
					param1,
					param2,
					param3);
            }
        }

        internal class AutofacSubScopeFactory<TP0, TP1, TP2, TP3, TP4, TInstance>
            : IFactory<TP0, TP1, TP2, TP3, TP4, TInstance>
            where TInstance : IDisposable
        {
            private readonly ILifetimeScope _scope;
            private readonly Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4> _subScopeInstaller;

            public AutofacSubScopeFactory(ILifetimeScope scope,
                Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(
				TP0 param0,
				TP1 param1,
				TP2 param2,
				TP3 param3,
				TP4 param4)
            {
                return _scope.ResolveFromSubScope<TP0, TP1, TP2, TP3, TP4, TInstance>(_subScopeInstaller,
					param0,
					param1,
					param2,
					param3,
					param4);
            }
        }

        internal class AutofacSubScopeFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>
            : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>
            where TInstance : IDisposable
        {
            private readonly ILifetimeScope _scope;
            private readonly Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5> _subScopeInstaller;

            public AutofacSubScopeFactory(ILifetimeScope scope,
                Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(
				TP0 param0,
				TP1 param1,
				TP2 param2,
				TP3 param3,
				TP4 param4,
				TP5 param5)
            {
                return _scope.ResolveFromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>(_subScopeInstaller,
					param0,
					param1,
					param2,
					param3,
					param4,
					param5);
            }
        }

        internal class AutofacSubScopeFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>
            : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>
            where TInstance : IDisposable
        {
            private readonly ILifetimeScope _scope;
            private readonly Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6> _subScopeInstaller;

            public AutofacSubScopeFactory(ILifetimeScope scope,
                Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(
				TP0 param0,
				TP1 param1,
				TP2 param2,
				TP3 param3,
				TP4 param4,
				TP5 param5,
				TP6 param6)
            {
                return _scope.ResolveFromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>(_subScopeInstaller,
					param0,
					param1,
					param2,
					param3,
					param4,
					param5,
					param6);
            }
        }

        internal class AutofacSubScopeFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>
            : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>
            where TInstance : IDisposable
        {
            private readonly ILifetimeScope _scope;
            private readonly Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7> _subScopeInstaller;

            public AutofacSubScopeFactory(ILifetimeScope scope,
                Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(
				TP0 param0,
				TP1 param1,
				TP2 param2,
				TP3 param3,
				TP4 param4,
				TP5 param5,
				TP6 param6,
				TP7 param7)
            {
                return _scope.ResolveFromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>(_subScopeInstaller,
					param0,
					param1,
					param2,
					param3,
					param4,
					param5,
					param6,
					param7);
            }
        }

        internal class AutofacSubScopeFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>
            : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>
            where TInstance : IDisposable
        {
            private readonly ILifetimeScope _scope;
            private readonly Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8> _subScopeInstaller;

            public AutofacSubScopeFactory(ILifetimeScope scope,
                Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(
				TP0 param0,
				TP1 param1,
				TP2 param2,
				TP3 param3,
				TP4 param4,
				TP5 param5,
				TP6 param6,
				TP7 param7,
				TP8 param8)
            {
                return _scope.ResolveFromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>(_subScopeInstaller,
					param0,
					param1,
					param2,
					param3,
					param4,
					param5,
					param6,
					param7,
					param8);
            }
        }

        internal class AutofacSubScopeFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>
            : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>
            where TInstance : IDisposable
        {
            private readonly ILifetimeScope _scope;
            private readonly Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9> _subScopeInstaller;

            public AutofacSubScopeFactory(ILifetimeScope scope,
                Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(
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
            {
                return _scope.ResolveFromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>(_subScopeInstaller,
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
            }
        }


        internal class AutofacSubScopeModuleFactory<TInstance, TModule>
            : IFactory<TInstance>
            where TInstance : IDisposable
            where TModule : class, IModule
        {
            private readonly ILifetimeScope _scope;
            [CanBeNull] private readonly Func<ILifetimeScope, TModule> _installerFactory;

            public AutofacSubScopeModuleFactory(ILifetimeScope scope,
                [CanBeNull]
                Func<ILifetimeScope, TModule> installerFactory = null)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _installerFactory = installerFactory;
            }

            public TInstance Create()
            {
                return _scope.ResolveFromModuleSubScope<TInstance, TModule>(
                    _installerFactory);
            }
        }

        internal class AutofacSubScopeModuleFactory<TP0, TInstance, TModule>
            : IFactory<TP0, TInstance>
            where TInstance : IDisposable
            where TModule : class, IModule
        {
            private readonly ILifetimeScope _scope;
            [CanBeNull] private readonly Func<ILifetimeScope, TP0, TModule> _installerFactory;

            public AutofacSubScopeModuleFactory(ILifetimeScope scope,
                [CanBeNull]
                Func<ILifetimeScope, TP0, TModule> installerFactory = null)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _installerFactory = installerFactory;
            }

            public TInstance Create(
				TP0 param0)
            {
                return _scope.ResolveFromModuleSubScope<TP0, TInstance, TModule>(
					param0, 
                    _installerFactory);
            }
        }

        internal class AutofacSubScopeModuleFactory<TP0, TP1, TInstance, TModule>
            : IFactory<TP0, TP1, TInstance>
            where TInstance : IDisposable
            where TModule : class, IModule
        {
            private readonly ILifetimeScope _scope;
            [CanBeNull] private readonly Func<ILifetimeScope, TP0, TP1, TModule> _installerFactory;

            public AutofacSubScopeModuleFactory(ILifetimeScope scope,
                [CanBeNull]
                Func<ILifetimeScope, TP0, TP1, TModule> installerFactory = null)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _installerFactory = installerFactory;
            }

            public TInstance Create(
				TP0 param0,
				TP1 param1)
            {
                return _scope.ResolveFromModuleSubScope<TP0, TP1, TInstance, TModule>(
					param0,
					param1, 
                    _installerFactory);
            }
        }

        internal class AutofacSubScopeModuleFactory<TP0, TP1, TP2, TInstance, TModule>
            : IFactory<TP0, TP1, TP2, TInstance>
            where TInstance : IDisposable
            where TModule : class, IModule
        {
            private readonly ILifetimeScope _scope;
            [CanBeNull] private readonly Func<ILifetimeScope, TP0, TP1, TP2, TModule> _installerFactory;

            public AutofacSubScopeModuleFactory(ILifetimeScope scope,
                [CanBeNull]
                Func<ILifetimeScope, TP0, TP1, TP2, TModule> installerFactory = null)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _installerFactory = installerFactory;
            }

            public TInstance Create(
				TP0 param0,
				TP1 param1,
				TP2 param2)
            {
                return _scope.ResolveFromModuleSubScope<TP0, TP1, TP2, TInstance, TModule>(
					param0,
					param1,
					param2, 
                    _installerFactory);
            }
        }

        internal class AutofacSubScopeModuleFactory<TP0, TP1, TP2, TP3, TInstance, TModule>
            : IFactory<TP0, TP1, TP2, TP3, TInstance>
            where TInstance : IDisposable
            where TModule : class, IModule
        {
            private readonly ILifetimeScope _scope;
            [CanBeNull] private readonly Func<ILifetimeScope, TP0, TP1, TP2, TP3, TModule> _installerFactory;

            public AutofacSubScopeModuleFactory(ILifetimeScope scope,
                [CanBeNull]
                Func<ILifetimeScope, TP0, TP1, TP2, TP3, TModule> installerFactory = null)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _installerFactory = installerFactory;
            }

            public TInstance Create(
				TP0 param0,
				TP1 param1,
				TP2 param2,
				TP3 param3)
            {
                return _scope.ResolveFromModuleSubScope<TP0, TP1, TP2, TP3, TInstance, TModule>(
					param0,
					param1,
					param2,
					param3, 
                    _installerFactory);
            }
        }

        internal class AutofacSubScopeModuleFactory<TP0, TP1, TP2, TP3, TP4, TInstance, TModule>
            : IFactory<TP0, TP1, TP2, TP3, TP4, TInstance>
            where TInstance : IDisposable
            where TModule : class, IModule
        {
            private readonly ILifetimeScope _scope;
            [CanBeNull] private readonly Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TModule> _installerFactory;

            public AutofacSubScopeModuleFactory(ILifetimeScope scope,
                [CanBeNull]
                Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TModule> installerFactory = null)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _installerFactory = installerFactory;
            }

            public TInstance Create(
				TP0 param0,
				TP1 param1,
				TP2 param2,
				TP3 param3,
				TP4 param4)
            {
                return _scope.ResolveFromModuleSubScope<TP0, TP1, TP2, TP3, TP4, TInstance, TModule>(
					param0,
					param1,
					param2,
					param3,
					param4, 
                    _installerFactory);
            }
        }

        internal class AutofacSubScopeModuleFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance, TModule>
            : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>
            where TInstance : IDisposable
            where TModule : class, IModule
        {
            private readonly ILifetimeScope _scope;
            [CanBeNull] private readonly Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TModule> _installerFactory;

            public AutofacSubScopeModuleFactory(ILifetimeScope scope,
                [CanBeNull]
                Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TModule> installerFactory = null)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _installerFactory = installerFactory;
            }

            public TInstance Create(
				TP0 param0,
				TP1 param1,
				TP2 param2,
				TP3 param3,
				TP4 param4,
				TP5 param5)
            {
                return _scope.ResolveFromModuleSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TInstance, TModule>(
					param0,
					param1,
					param2,
					param3,
					param4,
					param5, 
                    _installerFactory);
            }
        }

        internal class AutofacSubScopeModuleFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance, TModule>
            : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>
            where TInstance : IDisposable
            where TModule : class, IModule
        {
            private readonly ILifetimeScope _scope;
            [CanBeNull] private readonly Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TModule> _installerFactory;

            public AutofacSubScopeModuleFactory(ILifetimeScope scope,
                [CanBeNull]
                Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TModule> installerFactory = null)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _installerFactory = installerFactory;
            }

            public TInstance Create(
				TP0 param0,
				TP1 param1,
				TP2 param2,
				TP3 param3,
				TP4 param4,
				TP5 param5,
				TP6 param6)
            {
                return _scope.ResolveFromModuleSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance, TModule>(
					param0,
					param1,
					param2,
					param3,
					param4,
					param5,
					param6, 
                    _installerFactory);
            }
        }

        internal class AutofacSubScopeModuleFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance, TModule>
            : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>
            where TInstance : IDisposable
            where TModule : class, IModule
        {
            private readonly ILifetimeScope _scope;
            [CanBeNull] private readonly Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TModule> _installerFactory;

            public AutofacSubScopeModuleFactory(ILifetimeScope scope,
                [CanBeNull]
                Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TModule> installerFactory = null)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _installerFactory = installerFactory;
            }

            public TInstance Create(
				TP0 param0,
				TP1 param1,
				TP2 param2,
				TP3 param3,
				TP4 param4,
				TP5 param5,
				TP6 param6,
				TP7 param7)
            {
                return _scope.ResolveFromModuleSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance, TModule>(
					param0,
					param1,
					param2,
					param3,
					param4,
					param5,
					param6,
					param7, 
                    _installerFactory);
            }
        }

        internal class AutofacSubScopeModuleFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance, TModule>
            : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>
            where TInstance : IDisposable
            where TModule : class, IModule
        {
            private readonly ILifetimeScope _scope;
            [CanBeNull] private readonly Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TModule> _installerFactory;

            public AutofacSubScopeModuleFactory(ILifetimeScope scope,
                [CanBeNull]
                Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TModule> installerFactory = null)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _installerFactory = installerFactory;
            }

            public TInstance Create(
				TP0 param0,
				TP1 param1,
				TP2 param2,
				TP3 param3,
				TP4 param4,
				TP5 param5,
				TP6 param6,
				TP7 param7,
				TP8 param8)
            {
                return _scope.ResolveFromModuleSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance, TModule>(
					param0,
					param1,
					param2,
					param3,
					param4,
					param5,
					param6,
					param7,
					param8, 
                    _installerFactory);
            }
        }

        internal class AutofacSubScopeModuleFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance, TModule>
            : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>
            where TInstance : IDisposable
            where TModule : class, IModule
        {
            private readonly ILifetimeScope _scope;
            [CanBeNull] private readonly Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TModule> _installerFactory;

            public AutofacSubScopeModuleFactory(ILifetimeScope scope,
                [CanBeNull]
                Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TModule> installerFactory = null)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _installerFactory = installerFactory;
            }

            public TInstance Create(
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
            {
                return _scope.ResolveFromModuleSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance, TModule>(
					param0,
					param1,
					param2,
					param3,
					param4,
					param5,
					param6,
					param7,
					param8,
					param9, 
                    _installerFactory);
            }
        }

    }
}