using System;
using Autofac;
using Autofac2ZenjectLikeBridge.Interfaces;

namespace Autofac2ZenjectLikeBridge.Entities.Factories
{
    public static partial class DIExtensions
    {
        //generated amount 10

        private class AutofacSubScopeFactory<TInstance>
            : IFactory<TInstance>
            where TInstance : class, IDisposable
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

        private class AutofacSubScopeFactory<TP0, TInstance>
            : IFactory<TP0, TInstance>
            where TInstance : class, IDisposable
        {
            private readonly ILifetimeScope _scope;
            private readonly Action<ContainerBuilder, TP0> _subScopeInstaller;

            public AutofacSubScopeFactory(ILifetimeScope scope,
                Action<ContainerBuilder, TP0> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(TP0 param0)
            {
                return _scope.ResolveFromSubScope<TP0, TInstance>(_subScopeInstaller,
					param0);
            }
        }

        private class AutofacSubScopeFactory<TP0, TP1, TInstance>
            : IFactory<TP0, TP1, TInstance>
            where TInstance : class, IDisposable
        {
            private readonly ILifetimeScope _scope;
            private readonly Action<ContainerBuilder, TP0, TP1> _subScopeInstaller;

            public AutofacSubScopeFactory(ILifetimeScope scope,
                Action<ContainerBuilder, TP0, TP1> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(TP0 param0,
				TP1 param1)
            {
                return _scope.ResolveFromSubScope<TP0, TP1, TInstance>(_subScopeInstaller,
					param0,
					param1);
            }
        }

        private class AutofacSubScopeFactory<TP0, TP1, TP2, TInstance>
            : IFactory<TP0, TP1, TP2, TInstance>
            where TInstance : class, IDisposable
        {
            private readonly ILifetimeScope _scope;
            private readonly Action<ContainerBuilder, TP0, TP1, TP2> _subScopeInstaller;

            public AutofacSubScopeFactory(ILifetimeScope scope,
                Action<ContainerBuilder, TP0, TP1, TP2> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(TP0 param0,
				TP1 param1,
				TP2 param2)
            {
                return _scope.ResolveFromSubScope<TP0, TP1, TP2, TInstance>(_subScopeInstaller,
					param0,
					param1,
					param2);
            }
        }

        private class AutofacSubScopeFactory<TP0, TP1, TP2, TP3, TInstance>
            : IFactory<TP0, TP1, TP2, TP3, TInstance>
            where TInstance : class, IDisposable
        {
            private readonly ILifetimeScope _scope;
            private readonly Action<ContainerBuilder, TP0, TP1, TP2, TP3> _subScopeInstaller;

            public AutofacSubScopeFactory(ILifetimeScope scope,
                Action<ContainerBuilder, TP0, TP1, TP2, TP3> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(TP0 param0,
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

        private class AutofacSubScopeFactory<TP0, TP1, TP2, TP3, TP4, TInstance>
            : IFactory<TP0, TP1, TP2, TP3, TP4, TInstance>
            where TInstance : class, IDisposable
        {
            private readonly ILifetimeScope _scope;
            private readonly Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4> _subScopeInstaller;

            public AutofacSubScopeFactory(ILifetimeScope scope,
                Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(TP0 param0,
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

        private class AutofacSubScopeFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>
            : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>
            where TInstance : class, IDisposable
        {
            private readonly ILifetimeScope _scope;
            private readonly Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5> _subScopeInstaller;

            public AutofacSubScopeFactory(ILifetimeScope scope,
                Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(TP0 param0,
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

        private class AutofacSubScopeFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>
            : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>
            where TInstance : class, IDisposable
        {
            private readonly ILifetimeScope _scope;
            private readonly Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6> _subScopeInstaller;

            public AutofacSubScopeFactory(ILifetimeScope scope,
                Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(TP0 param0,
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

        private class AutofacSubScopeFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>
            : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>
            where TInstance : class, IDisposable
        {
            private readonly ILifetimeScope _scope;
            private readonly Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7> _subScopeInstaller;

            public AutofacSubScopeFactory(ILifetimeScope scope,
                Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(TP0 param0,
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

        private class AutofacSubScopeFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>
            : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>
            where TInstance : class, IDisposable
        {
            private readonly ILifetimeScope _scope;
            private readonly Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8> _subScopeInstaller;

            public AutofacSubScopeFactory(ILifetimeScope scope,
                Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(TP0 param0,
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

        private class AutofacSubScopeFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>
            : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>
            where TInstance : class, IDisposable
        {
            private readonly ILifetimeScope _scope;
            private readonly Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9> _subScopeInstaller;

            public AutofacSubScopeFactory(ILifetimeScope scope,
                Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(TP0 param0,
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

    }
}