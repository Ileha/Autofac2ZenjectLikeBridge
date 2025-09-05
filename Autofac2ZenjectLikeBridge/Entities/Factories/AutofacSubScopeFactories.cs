using System;
using Autofac;
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


        internal class AutofacSubScopeInstallerFactory<TInstance, TInstaller>
            : IFactory<TInstance>
            where TInstance : IDisposable
            where TInstaller : class, IInstaller
        {
            private readonly ILifetimeScope _scope;
            [CanBeNull] private readonly Func<ContainerBuilder, TInstaller> _installerFactory;

            public AutofacSubScopeInstallerFactory(ILifetimeScope scope,
                [CanBeNull]
                Func<ContainerBuilder, TInstaller> installerFactory = null)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _installerFactory = installerFactory;
            }

            public TInstance Create()
            {
                return _scope.ResolveFromSubScope<TInstance, TInstaller>(
                    _installerFactory);
            }
        }

        internal class AutofacSubScopeInstallerFactory<TP0, TInstance, TInstaller>
            : IFactory<TP0, TInstance>
            where TInstance : IDisposable
            where TInstaller : class, IInstaller
        {
            private readonly ILifetimeScope _scope;
            [CanBeNull] private readonly Func<ContainerBuilder, TP0, TInstaller> _installerFactory;

            public AutofacSubScopeInstallerFactory(ILifetimeScope scope,
                [CanBeNull]
                Func<ContainerBuilder, TP0, TInstaller> installerFactory = null)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _installerFactory = installerFactory;
            }

            public TInstance Create(
				TP0 param0)
            {
                return _scope.ResolveFromSubScope<TP0, TInstance, TInstaller>(
					param0, 
                    _installerFactory);
            }
        }

        internal class AutofacSubScopeInstallerFactory<TP0, TP1, TInstance, TInstaller>
            : IFactory<TP0, TP1, TInstance>
            where TInstance : IDisposable
            where TInstaller : class, IInstaller
        {
            private readonly ILifetimeScope _scope;
            [CanBeNull] private readonly Func<ContainerBuilder, TP0, TP1, TInstaller> _installerFactory;

            public AutofacSubScopeInstallerFactory(ILifetimeScope scope,
                [CanBeNull]
                Func<ContainerBuilder, TP0, TP1, TInstaller> installerFactory = null)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _installerFactory = installerFactory;
            }

            public TInstance Create(
				TP0 param0,
				TP1 param1)
            {
                return _scope.ResolveFromSubScope<TP0, TP1, TInstance, TInstaller>(
					param0,
					param1, 
                    _installerFactory);
            }
        }

        internal class AutofacSubScopeInstallerFactory<TP0, TP1, TP2, TInstance, TInstaller>
            : IFactory<TP0, TP1, TP2, TInstance>
            where TInstance : IDisposable
            where TInstaller : class, IInstaller
        {
            private readonly ILifetimeScope _scope;
            [CanBeNull] private readonly Func<ContainerBuilder, TP0, TP1, TP2, TInstaller> _installerFactory;

            public AutofacSubScopeInstallerFactory(ILifetimeScope scope,
                [CanBeNull]
                Func<ContainerBuilder, TP0, TP1, TP2, TInstaller> installerFactory = null)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _installerFactory = installerFactory;
            }

            public TInstance Create(
				TP0 param0,
				TP1 param1,
				TP2 param2)
            {
                return _scope.ResolveFromSubScope<TP0, TP1, TP2, TInstance, TInstaller>(
					param0,
					param1,
					param2, 
                    _installerFactory);
            }
        }

        internal class AutofacSubScopeInstallerFactory<TP0, TP1, TP2, TP3, TInstance, TInstaller>
            : IFactory<TP0, TP1, TP2, TP3, TInstance>
            where TInstance : IDisposable
            where TInstaller : class, IInstaller
        {
            private readonly ILifetimeScope _scope;
            [CanBeNull] private readonly Func<ContainerBuilder, TP0, TP1, TP2, TP3, TInstaller> _installerFactory;

            public AutofacSubScopeInstallerFactory(ILifetimeScope scope,
                [CanBeNull]
                Func<ContainerBuilder, TP0, TP1, TP2, TP3, TInstaller> installerFactory = null)
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
                return _scope.ResolveFromSubScope<TP0, TP1, TP2, TP3, TInstance, TInstaller>(
					param0,
					param1,
					param2,
					param3, 
                    _installerFactory);
            }
        }

        internal class AutofacSubScopeInstallerFactory<TP0, TP1, TP2, TP3, TP4, TInstance, TInstaller>
            : IFactory<TP0, TP1, TP2, TP3, TP4, TInstance>
            where TInstance : IDisposable
            where TInstaller : class, IInstaller
        {
            private readonly ILifetimeScope _scope;
            [CanBeNull] private readonly Func<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TInstaller> _installerFactory;

            public AutofacSubScopeInstallerFactory(ILifetimeScope scope,
                [CanBeNull]
                Func<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TInstaller> installerFactory = null)
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
                return _scope.ResolveFromSubScope<TP0, TP1, TP2, TP3, TP4, TInstance, TInstaller>(
					param0,
					param1,
					param2,
					param3,
					param4, 
                    _installerFactory);
            }
        }

        internal class AutofacSubScopeInstallerFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance, TInstaller>
            : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>
            where TInstance : IDisposable
            where TInstaller : class, IInstaller
        {
            private readonly ILifetimeScope _scope;
            [CanBeNull] private readonly Func<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TInstaller> _installerFactory;

            public AutofacSubScopeInstallerFactory(ILifetimeScope scope,
                [CanBeNull]
                Func<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TInstaller> installerFactory = null)
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
                return _scope.ResolveFromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TInstance, TInstaller>(
					param0,
					param1,
					param2,
					param3,
					param4,
					param5, 
                    _installerFactory);
            }
        }

        internal class AutofacSubScopeInstallerFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance, TInstaller>
            : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>
            where TInstance : IDisposable
            where TInstaller : class, IInstaller
        {
            private readonly ILifetimeScope _scope;
            [CanBeNull] private readonly Func<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstaller> _installerFactory;

            public AutofacSubScopeInstallerFactory(ILifetimeScope scope,
                [CanBeNull]
                Func<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstaller> installerFactory = null)
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
                return _scope.ResolveFromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance, TInstaller>(
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

        internal class AutofacSubScopeInstallerFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance, TInstaller>
            : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>
            where TInstance : IDisposable
            where TInstaller : class, IInstaller
        {
            private readonly ILifetimeScope _scope;
            [CanBeNull] private readonly Func<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstaller> _installerFactory;

            public AutofacSubScopeInstallerFactory(ILifetimeScope scope,
                [CanBeNull]
                Func<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstaller> installerFactory = null)
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
                return _scope.ResolveFromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance, TInstaller>(
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

        internal class AutofacSubScopeInstallerFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance, TInstaller>
            : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>
            where TInstance : IDisposable
            where TInstaller : class, IInstaller
        {
            private readonly ILifetimeScope _scope;
            [CanBeNull] private readonly Func<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstaller> _installerFactory;

            public AutofacSubScopeInstallerFactory(ILifetimeScope scope,
                [CanBeNull]
                Func<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstaller> installerFactory = null)
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
                return _scope.ResolveFromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance, TInstaller>(
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

        internal class AutofacSubScopeInstallerFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance, TInstaller>
            : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>
            where TInstance : IDisposable
            where TInstaller : class, IInstaller
        {
            private readonly ILifetimeScope _scope;
            [CanBeNull] private readonly Func<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstaller> _installerFactory;

            public AutofacSubScopeInstallerFactory(ILifetimeScope scope,
                [CanBeNull]
                Func<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstaller> installerFactory = null)
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
                return _scope.ResolveFromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance, TInstaller>(
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