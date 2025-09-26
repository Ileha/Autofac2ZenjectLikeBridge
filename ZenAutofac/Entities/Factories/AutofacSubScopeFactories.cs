using System;
using Autofac;
using Autofac.Core;
using JetBrains.Annotations;
using ZenAutofac.Interfaces;

namespace ZenAutofac.Entities.Factories
{
    public static partial class DIExtensions
    {
        //generated amount 10

        internal class AutofacSubScopeFactory<TInstance>
            : IFactory<TInstance>
            where TInstance : IDisposable
        {
            private readonly ILifetimeScope _scope;
            private readonly Action<ContainerBuilder> _subScopeLoader;

            public AutofacSubScopeFactory(ILifetimeScope scope,
                Action<ContainerBuilder> subScopeLoader)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeLoader = subScopeLoader ?? throw new ArgumentNullException(nameof(subScopeLoader));
            }

            public TInstance Create()
            {
                return _scope.ResolveFromSubScope<TInstance>(_subScopeLoader);
            }
        }

        internal class AutofacSubScopeFactory<TP0, TInstance>
            : IFactory<TP0, TInstance>
            where TInstance : IDisposable
        {
            private readonly ILifetimeScope _scope;
            private readonly Action<ContainerBuilder, TP0> _subScopeLoader;

            public AutofacSubScopeFactory(ILifetimeScope scope,
                Action<ContainerBuilder, TP0> subScopeLoader)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeLoader = subScopeLoader ?? throw new ArgumentNullException(nameof(subScopeLoader));
            }

            public TInstance Create(
				TP0 param0)
            {
                return _scope.ResolveFromSubScope<TP0, TInstance>(_subScopeLoader,
					param0);
            }
        }

        internal class AutofacSubScopeFactory<TP0, TP1, TInstance>
            : IFactory<TP0, TP1, TInstance>
            where TInstance : IDisposable
        {
            private readonly ILifetimeScope _scope;
            private readonly Action<ContainerBuilder, TP0, TP1> _subScopeLoader;

            public AutofacSubScopeFactory(ILifetimeScope scope,
                Action<ContainerBuilder, TP0, TP1> subScopeLoader)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeLoader = subScopeLoader ?? throw new ArgumentNullException(nameof(subScopeLoader));
            }

            public TInstance Create(
				TP0 param0,
				TP1 param1)
            {
                return _scope.ResolveFromSubScope<TP0, TP1, TInstance>(_subScopeLoader,
					param0,
					param1);
            }
        }

        internal class AutofacSubScopeFactory<TP0, TP1, TP2, TInstance>
            : IFactory<TP0, TP1, TP2, TInstance>
            where TInstance : IDisposable
        {
            private readonly ILifetimeScope _scope;
            private readonly Action<ContainerBuilder, TP0, TP1, TP2> _subScopeLoader;

            public AutofacSubScopeFactory(ILifetimeScope scope,
                Action<ContainerBuilder, TP0, TP1, TP2> subScopeLoader)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeLoader = subScopeLoader ?? throw new ArgumentNullException(nameof(subScopeLoader));
            }

            public TInstance Create(
				TP0 param0,
				TP1 param1,
				TP2 param2)
            {
                return _scope.ResolveFromSubScope<TP0, TP1, TP2, TInstance>(_subScopeLoader,
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
            private readonly Action<ContainerBuilder, TP0, TP1, TP2, TP3> _subScopeLoader;

            public AutofacSubScopeFactory(ILifetimeScope scope,
                Action<ContainerBuilder, TP0, TP1, TP2, TP3> subScopeLoader)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeLoader = subScopeLoader ?? throw new ArgumentNullException(nameof(subScopeLoader));
            }

            public TInstance Create(
				TP0 param0,
				TP1 param1,
				TP2 param2,
				TP3 param3)
            {
                return _scope.ResolveFromSubScope<TP0, TP1, TP2, TP3, TInstance>(_subScopeLoader,
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
            private readonly Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4> _subScopeLoader;

            public AutofacSubScopeFactory(ILifetimeScope scope,
                Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4> subScopeLoader)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeLoader = subScopeLoader ?? throw new ArgumentNullException(nameof(subScopeLoader));
            }

            public TInstance Create(
				TP0 param0,
				TP1 param1,
				TP2 param2,
				TP3 param3,
				TP4 param4)
            {
                return _scope.ResolveFromSubScope<TP0, TP1, TP2, TP3, TP4, TInstance>(_subScopeLoader,
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
            private readonly Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5> _subScopeLoader;

            public AutofacSubScopeFactory(ILifetimeScope scope,
                Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5> subScopeLoader)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeLoader = subScopeLoader ?? throw new ArgumentNullException(nameof(subScopeLoader));
            }

            public TInstance Create(
				TP0 param0,
				TP1 param1,
				TP2 param2,
				TP3 param3,
				TP4 param4,
				TP5 param5)
            {
                return _scope.ResolveFromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>(_subScopeLoader,
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
            private readonly Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6> _subScopeLoader;

            public AutofacSubScopeFactory(ILifetimeScope scope,
                Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6> subScopeLoader)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeLoader = subScopeLoader ?? throw new ArgumentNullException(nameof(subScopeLoader));
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
                return _scope.ResolveFromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>(_subScopeLoader,
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
            private readonly Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7> _subScopeLoader;

            public AutofacSubScopeFactory(ILifetimeScope scope,
                Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7> subScopeLoader)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeLoader = subScopeLoader ?? throw new ArgumentNullException(nameof(subScopeLoader));
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
                return _scope.ResolveFromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>(_subScopeLoader,
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
            private readonly Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8> _subScopeLoader;

            public AutofacSubScopeFactory(ILifetimeScope scope,
                Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8> subScopeLoader)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeLoader = subScopeLoader ?? throw new ArgumentNullException(nameof(subScopeLoader));
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
                return _scope.ResolveFromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>(_subScopeLoader,
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
            private readonly Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9> _subScopeLoader;

            public AutofacSubScopeFactory(ILifetimeScope scope,
                Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9> subScopeLoader)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeLoader = subScopeLoader ?? throw new ArgumentNullException(nameof(subScopeLoader));
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
                return _scope.ResolveFromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>(_subScopeLoader,
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
            [CanBeNull] private readonly Func<ILifetimeScope, TModule> _moduleFactory;

            public AutofacSubScopeModuleFactory(ILifetimeScope scope,
                [CanBeNull]
                Func<ILifetimeScope, TModule> moduleFactory = null)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _moduleFactory = moduleFactory;
            }

            public TInstance Create()
            {
                return _scope.ResolveFromSubScope<TInstance, TModule>(
                    _moduleFactory);
            }
        }

        internal class AutofacSubScopeModuleFactory<TP0, TInstance, TModule>
            : IFactory<TP0, TInstance>
            where TInstance : IDisposable
            where TModule : class, IModule
        {
            private readonly ILifetimeScope _scope;
            [CanBeNull] private readonly Func<ILifetimeScope, TP0, TModule> _moduleFactory;

            public AutofacSubScopeModuleFactory(ILifetimeScope scope,
                [CanBeNull]
                Func<ILifetimeScope, TP0, TModule> moduleFactory = null)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _moduleFactory = moduleFactory;
            }

            public TInstance Create(
				TP0 param0)
            {
                return _scope.ResolveFromSubScope<TP0, TInstance, TModule>(
					param0, 
                    _moduleFactory);
            }
        }

        internal class AutofacSubScopeModuleFactory<TP0, TP1, TInstance, TModule>
            : IFactory<TP0, TP1, TInstance>
            where TInstance : IDisposable
            where TModule : class, IModule
        {
            private readonly ILifetimeScope _scope;
            [CanBeNull] private readonly Func<ILifetimeScope, TP0, TP1, TModule> _moduleFactory;

            public AutofacSubScopeModuleFactory(ILifetimeScope scope,
                [CanBeNull]
                Func<ILifetimeScope, TP0, TP1, TModule> moduleFactory = null)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _moduleFactory = moduleFactory;
            }

            public TInstance Create(
				TP0 param0,
				TP1 param1)
            {
                return _scope.ResolveFromSubScope<TP0, TP1, TInstance, TModule>(
					param0,
					param1, 
                    _moduleFactory);
            }
        }

        internal class AutofacSubScopeModuleFactory<TP0, TP1, TP2, TInstance, TModule>
            : IFactory<TP0, TP1, TP2, TInstance>
            where TInstance : IDisposable
            where TModule : class, IModule
        {
            private readonly ILifetimeScope _scope;
            [CanBeNull] private readonly Func<ILifetimeScope, TP0, TP1, TP2, TModule> _moduleFactory;

            public AutofacSubScopeModuleFactory(ILifetimeScope scope,
                [CanBeNull]
                Func<ILifetimeScope, TP0, TP1, TP2, TModule> moduleFactory = null)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _moduleFactory = moduleFactory;
            }

            public TInstance Create(
				TP0 param0,
				TP1 param1,
				TP2 param2)
            {
                return _scope.ResolveFromSubScope<TP0, TP1, TP2, TInstance, TModule>(
					param0,
					param1,
					param2, 
                    _moduleFactory);
            }
        }

        internal class AutofacSubScopeModuleFactory<TP0, TP1, TP2, TP3, TInstance, TModule>
            : IFactory<TP0, TP1, TP2, TP3, TInstance>
            where TInstance : IDisposable
            where TModule : class, IModule
        {
            private readonly ILifetimeScope _scope;
            [CanBeNull] private readonly Func<ILifetimeScope, TP0, TP1, TP2, TP3, TModule> _moduleFactory;

            public AutofacSubScopeModuleFactory(ILifetimeScope scope,
                [CanBeNull]
                Func<ILifetimeScope, TP0, TP1, TP2, TP3, TModule> moduleFactory = null)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _moduleFactory = moduleFactory;
            }

            public TInstance Create(
				TP0 param0,
				TP1 param1,
				TP2 param2,
				TP3 param3)
            {
                return _scope.ResolveFromSubScope<TP0, TP1, TP2, TP3, TInstance, TModule>(
					param0,
					param1,
					param2,
					param3, 
                    _moduleFactory);
            }
        }

        internal class AutofacSubScopeModuleFactory<TP0, TP1, TP2, TP3, TP4, TInstance, TModule>
            : IFactory<TP0, TP1, TP2, TP3, TP4, TInstance>
            where TInstance : IDisposable
            where TModule : class, IModule
        {
            private readonly ILifetimeScope _scope;
            [CanBeNull] private readonly Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TModule> _moduleFactory;

            public AutofacSubScopeModuleFactory(ILifetimeScope scope,
                [CanBeNull]
                Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TModule> moduleFactory = null)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _moduleFactory = moduleFactory;
            }

            public TInstance Create(
				TP0 param0,
				TP1 param1,
				TP2 param2,
				TP3 param3,
				TP4 param4)
            {
                return _scope.ResolveFromSubScope<TP0, TP1, TP2, TP3, TP4, TInstance, TModule>(
					param0,
					param1,
					param2,
					param3,
					param4, 
                    _moduleFactory);
            }
        }

        internal class AutofacSubScopeModuleFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance, TModule>
            : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>
            where TInstance : IDisposable
            where TModule : class, IModule
        {
            private readonly ILifetimeScope _scope;
            [CanBeNull] private readonly Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TModule> _moduleFactory;

            public AutofacSubScopeModuleFactory(ILifetimeScope scope,
                [CanBeNull]
                Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TModule> moduleFactory = null)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _moduleFactory = moduleFactory;
            }

            public TInstance Create(
				TP0 param0,
				TP1 param1,
				TP2 param2,
				TP3 param3,
				TP4 param4,
				TP5 param5)
            {
                return _scope.ResolveFromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TInstance, TModule>(
					param0,
					param1,
					param2,
					param3,
					param4,
					param5, 
                    _moduleFactory);
            }
        }

        internal class AutofacSubScopeModuleFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance, TModule>
            : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>
            where TInstance : IDisposable
            where TModule : class, IModule
        {
            private readonly ILifetimeScope _scope;
            [CanBeNull] private readonly Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TModule> _moduleFactory;

            public AutofacSubScopeModuleFactory(ILifetimeScope scope,
                [CanBeNull]
                Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TModule> moduleFactory = null)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _moduleFactory = moduleFactory;
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
                return _scope.ResolveFromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance, TModule>(
					param0,
					param1,
					param2,
					param3,
					param4,
					param5,
					param6, 
                    _moduleFactory);
            }
        }

        internal class AutofacSubScopeModuleFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance, TModule>
            : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>
            where TInstance : IDisposable
            where TModule : class, IModule
        {
            private readonly ILifetimeScope _scope;
            [CanBeNull] private readonly Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TModule> _moduleFactory;

            public AutofacSubScopeModuleFactory(ILifetimeScope scope,
                [CanBeNull]
                Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TModule> moduleFactory = null)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _moduleFactory = moduleFactory;
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
                return _scope.ResolveFromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance, TModule>(
					param0,
					param1,
					param2,
					param3,
					param4,
					param5,
					param6,
					param7, 
                    _moduleFactory);
            }
        }

        internal class AutofacSubScopeModuleFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance, TModule>
            : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>
            where TInstance : IDisposable
            where TModule : class, IModule
        {
            private readonly ILifetimeScope _scope;
            [CanBeNull] private readonly Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TModule> _moduleFactory;

            public AutofacSubScopeModuleFactory(ILifetimeScope scope,
                [CanBeNull]
                Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TModule> moduleFactory = null)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _moduleFactory = moduleFactory;
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
                return _scope.ResolveFromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance, TModule>(
					param0,
					param1,
					param2,
					param3,
					param4,
					param5,
					param6,
					param7,
					param8, 
                    _moduleFactory);
            }
        }

        internal class AutofacSubScopeModuleFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance, TModule>
            : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>
            where TInstance : IDisposable
            where TModule : class, IModule
        {
            private readonly ILifetimeScope _scope;
            [CanBeNull] private readonly Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TModule> _moduleFactory;

            public AutofacSubScopeModuleFactory(ILifetimeScope scope,
                [CanBeNull]
                Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TModule> moduleFactory = null)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _moduleFactory = moduleFactory;
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
                return _scope.ResolveFromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance, TModule>(
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
                    _moduleFactory);
            }
        }

    }
}