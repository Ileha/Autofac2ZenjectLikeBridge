using Autofac;
using Autofac.Builder;
using Autofac2ZenjectLikeBridge.Extensions;
using Autofac2ZenjectLikeBridge.Interfaces;

namespace Autofac2ZenjectLikeBridge
{
    public static partial class DIExtensions
    {
        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromFunction<TInstance, TFactory>(
            this ContainerBuilder builder,
            Func<ILifetimeScope, TInstance> func)
            where TInstance : class
            where TFactory : PlaceholderFactory<TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactoryFromFunction(func)
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<TInstance>>()
                                    })
                                .SingleInstance();
                        })
                        .AddTo(scope.Disposer);

                    return subScope.Resolve<TFactory>();
                });
        }

        public static IRegistrationBuilder<
            IFactory<TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromFunction<TInstance>(
                this ContainerBuilder builder,
                Func<ILifetimeScope, TInstance> func)
            where TInstance : class
        {
            return builder
                .RegisterType<AutofacFunctionFactory<TInstance>>()
                .WithParameter(TypedParameter.From(func))
                .As<IFactory<TInstance>>();
        }

        private class AutofacFunctionFactory<TInstance> : IFactory<TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;
            private readonly Func<ILifetimeScope, TInstance> _subScopeInstaller;

            public AutofacFunctionFactory(
                ILifetimeScope scope,
                Func<ILifetimeScope, TInstance> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create()
            {
                return _subScopeInstaller(_scope);
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromSubScope<TInstance, TFactory>(
            this ContainerBuilder builder,
            Action<ContainerBuilder> subScopeInstaller
        )
            where TInstance : class, ICollection<IDisposable>, IDisposable
            where TFactory : PlaceholderFactory<TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactoryFromSubScope<TInstance>(subScopeInstaller)
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<TInstance>>()
                                    })
                                .SingleInstance()
                                .ExternallyOwned();
                        })
                        .AddTo(scope.Disposer);

                    return subScope.Resolve<TFactory>();
                });
        }

        public static IRegistrationBuilder<
            IFactory<TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromSubScope<TInstance>(
                this ContainerBuilder builder,
                Action<ContainerBuilder> subScopeInstaller
                )
            where TInstance : class, ICollection<IDisposable>, IDisposable
        {
            return builder
                .RegisterType<AutofacSubScopeFactory<TInstance>>()
                .WithParameter(TypedParameter.From(subScopeInstaller))
                .As<IFactory<TInstance>>();
        }

        private class AutofacSubScopeFactory<TInstance> : IFactory<TInstance>
            where TInstance : class, ICollection<IDisposable>, IDisposable
        {
            private readonly ILifetimeScope _scope;
            private readonly Action<ContainerBuilder> _subScopeInstaller;

            public AutofacSubScopeFactory(ILifetimeScope scope, Action<ContainerBuilder> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create()
            {
                var guid = Guid.NewGuid();

                var subScope = _scope
                    .BeginLifetimeScope(guid, subScopeBuilder =>
                    {
                        subScopeBuilder.OverrideExternallyOwnedInScope<TInstance>(guid);
                        _subScopeInstaller(subScopeBuilder);
                    });

                var instance = subScope.Resolve<TInstance>();

                subScope
                    .AddTo(instance);

                return instance;
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterPlaceholderFactory<TInstance, TFactory>(this ContainerBuilder builder)
            where TInstance : class
            where TFactory : PlaceholderFactory<TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactory<TInstance>()
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<TInstance>>()
                                    })
                                .SingleInstance();
                        })
                        .AddTo(scope.Disposer);

                    return subScope.Resolve<TFactory>();
                });
        }


        public static IRegistrationBuilder<
            IFactory<TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactory<TInstance>(this ContainerBuilder typeSourceSelector)
            where TInstance : class
        {
            return typeSourceSelector
                .RegisterType<AutofacResolveFactory<TInstance>>()
                .As<IFactory<TInstance>>();
        }

        private class AutofacResolveFactory<TInstance> : IFactory<TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;

            public AutofacResolveFactory(ILifetimeScope scope)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
            }

            public TInstance Create()
            {
                return _scope.CreateInstance<TInstance>();
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromFunction<P0, TInstance, TFactory>(
            this ContainerBuilder builder,
            Func<ILifetimeScope, P0, TInstance> func)
            where TInstance : class
            where TFactory : PlaceholderFactory<P0, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactoryFromFunction(func)
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<P0, TInstance>>()
                                    })
                                .SingleInstance();
                        })
                        .AddTo(scope.Disposer);

                    return subScope.Resolve<TFactory>();
                });
        }

        public static IRegistrationBuilder<
            IFactory<P0, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromFunction<P0, TInstance>(
                this ContainerBuilder builder,
                Func<ILifetimeScope, P0, TInstance> func)
            where TInstance : class
        {
            return builder
                .RegisterType<AutofacFunctionFactory<P0, TInstance>>()
                .WithParameter(TypedParameter.From(func))
                .As<IFactory<P0, TInstance>>();
        }

        private class AutofacFunctionFactory<P0, TInstance> : IFactory<P0, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;
            private readonly Func<ILifetimeScope, P0, TInstance> _subScopeInstaller;

            public AutofacFunctionFactory(
                ILifetimeScope scope,
                Func<ILifetimeScope, P0, TInstance> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(P0 param0)
            {
                return _subScopeInstaller(_scope, param0);
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromSubScope<P0, TInstance, TFactory>(
            this ContainerBuilder builder,
            Action<ContainerBuilder, P0> subScopeInstaller
        )
            where TInstance : class, ICollection<IDisposable>, IDisposable
            where TFactory : PlaceholderFactory<P0, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactoryFromSubScope<P0, TInstance>(subScopeInstaller)
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<P0, TInstance>>()
                                    })
                                .SingleInstance()
                                .ExternallyOwned();
                        })
                        .AddTo(scope.Disposer);

                    return subScope.Resolve<TFactory>();
                });
        }

        public static IRegistrationBuilder<
            IFactory<P0, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromSubScope<P0, TInstance>(
                this ContainerBuilder builder,
                Action<ContainerBuilder, P0> subScopeInstaller
                )
            where TInstance : class, ICollection<IDisposable>, IDisposable
        {
            return builder
                .RegisterType<AutofacSubScopeFactory<P0, TInstance>>()
                .WithParameter(TypedParameter.From(subScopeInstaller))
                .As<IFactory<P0, TInstance>>();
        }

        private class AutofacSubScopeFactory<P0, TInstance> : IFactory<P0, TInstance>
            where TInstance : class, ICollection<IDisposable>, IDisposable
        {
            private readonly ILifetimeScope _scope;
            private readonly Action<ContainerBuilder, P0> _subScopeInstaller;

            public AutofacSubScopeFactory(ILifetimeScope scope, Action<ContainerBuilder, P0> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(P0 param0)
            {
                var guid = Guid.NewGuid();

                var subScope = _scope
                    .BeginLifetimeScope(guid, subScopeBuilder =>
                    {
                        subScopeBuilder.OverrideExternallyOwnedInScope<TInstance>(guid);
                        _subScopeInstaller(subScopeBuilder, param0);
                    });

                var instance = subScope.Resolve<TInstance>();

                subScope
                    .AddTo(instance);

                return instance;
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterPlaceholderFactory<P0, TInstance, TFactory>(this ContainerBuilder builder)
            where TInstance : class
            where TFactory : PlaceholderFactory<P0, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactory<P0, TInstance>()
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<P0, TInstance>>()
                                    })
                                .SingleInstance();
                        })
                        .AddTo(scope.Disposer);

                    return subScope.Resolve<TFactory>();
                });
        }


        public static IRegistrationBuilder<
            IFactory<P0, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactory<P0, TInstance>(this ContainerBuilder typeSourceSelector)
            where TInstance : class
        {
            return typeSourceSelector
                .RegisterType<AutofacResolveFactory<P0, TInstance>>()
                .As<IFactory<P0, TInstance>>();
        }

        private class AutofacResolveFactory<P0, TInstance> : IFactory<P0, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;

            public AutofacResolveFactory(ILifetimeScope scope)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
            }

            public TInstance Create(P0 param0)
            {
                return _scope.CreateInstance<TInstance>(parameters: [ param0 ]);
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromFunction<P0, P1, TInstance, TFactory>(
            this ContainerBuilder builder,
            Func<ILifetimeScope, P0, P1, TInstance> func)
            where TInstance : class
            where TFactory : PlaceholderFactory<P0, P1, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactoryFromFunction(func)
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<P0, P1, TInstance>>()
                                    })
                                .SingleInstance();
                        })
                        .AddTo(scope.Disposer);

                    return subScope.Resolve<TFactory>();
                });
        }

        public static IRegistrationBuilder<
            IFactory<P0, P1, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromFunction<P0, P1, TInstance>(
                this ContainerBuilder builder,
                Func<ILifetimeScope, P0, P1, TInstance> func)
            where TInstance : class
        {
            return builder
                .RegisterType<AutofacFunctionFactory<P0, P1, TInstance>>()
                .WithParameter(TypedParameter.From(func))
                .As<IFactory<P0, P1, TInstance>>();
        }

        private class AutofacFunctionFactory<P0, P1, TInstance> : IFactory<P0, P1, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;
            private readonly Func<ILifetimeScope, P0, P1, TInstance> _subScopeInstaller;

            public AutofacFunctionFactory(
                ILifetimeScope scope,
                Func<ILifetimeScope, P0, P1, TInstance> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(P0 param0, P1 param1)
            {
                return _subScopeInstaller(_scope, param0, param1);
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromSubScope<P0, P1, TInstance, TFactory>(
            this ContainerBuilder builder,
            Action<ContainerBuilder, P0, P1> subScopeInstaller
        )
            where TInstance : class, ICollection<IDisposable>, IDisposable
            where TFactory : PlaceholderFactory<P0, P1, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactoryFromSubScope<P0, P1, TInstance>(subScopeInstaller)
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<P0, P1, TInstance>>()
                                    })
                                .SingleInstance()
                                .ExternallyOwned();
                        })
                        .AddTo(scope.Disposer);

                    return subScope.Resolve<TFactory>();
                });
        }

        public static IRegistrationBuilder<
            IFactory<P0, P1, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromSubScope<P0, P1, TInstance>(
                this ContainerBuilder builder,
                Action<ContainerBuilder, P0, P1> subScopeInstaller
                )
            where TInstance : class, ICollection<IDisposable>, IDisposable
        {
            return builder
                .RegisterType<AutofacSubScopeFactory<P0, P1, TInstance>>()
                .WithParameter(TypedParameter.From(subScopeInstaller))
                .As<IFactory<P0, P1, TInstance>>();
        }

        private class AutofacSubScopeFactory<P0, P1, TInstance> : IFactory<P0, P1, TInstance>
            where TInstance : class, ICollection<IDisposable>, IDisposable
        {
            private readonly ILifetimeScope _scope;
            private readonly Action<ContainerBuilder, P0, P1> _subScopeInstaller;

            public AutofacSubScopeFactory(ILifetimeScope scope, Action<ContainerBuilder, P0, P1> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(P0 param0, P1 param1)
            {
                var guid = Guid.NewGuid();

                var subScope = _scope
                    .BeginLifetimeScope(guid, subScopeBuilder =>
                    {
                        subScopeBuilder.OverrideExternallyOwnedInScope<TInstance>(guid);
                        _subScopeInstaller(subScopeBuilder, param0, param1);
                    });

                var instance = subScope.Resolve<TInstance>();

                subScope
                    .AddTo(instance);

                return instance;
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterPlaceholderFactory<P0, P1, TInstance, TFactory>(this ContainerBuilder builder)
            where TInstance : class
            where TFactory : PlaceholderFactory<P0, P1, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactory<P0, P1, TInstance>()
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<P0, P1, TInstance>>()
                                    })
                                .SingleInstance();
                        })
                        .AddTo(scope.Disposer);

                    return subScope.Resolve<TFactory>();
                });
        }


        public static IRegistrationBuilder<
            IFactory<P0, P1, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactory<P0, P1, TInstance>(this ContainerBuilder typeSourceSelector)
            where TInstance : class
        {
            return typeSourceSelector
                .RegisterType<AutofacResolveFactory<P0, P1, TInstance>>()
                .As<IFactory<P0, P1, TInstance>>();
        }

        private class AutofacResolveFactory<P0, P1, TInstance> : IFactory<P0, P1, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;

            public AutofacResolveFactory(ILifetimeScope scope)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
            }

            public TInstance Create(P0 param0, P1 param1)
            {
                return _scope.CreateInstance<TInstance>(parameters: [ param0, param1 ]);
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromFunction<P0, P1, P2, TInstance, TFactory>(
            this ContainerBuilder builder,
            Func<ILifetimeScope, P0, P1, P2, TInstance> func)
            where TInstance : class
            where TFactory : PlaceholderFactory<P0, P1, P2, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactoryFromFunction(func)
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<P0, P1, P2, TInstance>>()
                                    })
                                .SingleInstance();
                        })
                        .AddTo(scope.Disposer);

                    return subScope.Resolve<TFactory>();
                });
        }

        public static IRegistrationBuilder<
            IFactory<P0, P1, P2, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromFunction<P0, P1, P2, TInstance>(
                this ContainerBuilder builder,
                Func<ILifetimeScope, P0, P1, P2, TInstance> func)
            where TInstance : class
        {
            return builder
                .RegisterType<AutofacFunctionFactory<P0, P1, P2, TInstance>>()
                .WithParameter(TypedParameter.From(func))
                .As<IFactory<P0, P1, P2, TInstance>>();
        }

        private class AutofacFunctionFactory<P0, P1, P2, TInstance> : IFactory<P0, P1, P2, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;
            private readonly Func<ILifetimeScope, P0, P1, P2, TInstance> _subScopeInstaller;

            public AutofacFunctionFactory(
                ILifetimeScope scope,
                Func<ILifetimeScope, P0, P1, P2, TInstance> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(P0 param0, P1 param1, P2 param2)
            {
                return _subScopeInstaller(_scope, param0, param1, param2);
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromSubScope<P0, P1, P2, TInstance, TFactory>(
            this ContainerBuilder builder,
            Action<ContainerBuilder, P0, P1, P2> subScopeInstaller
        )
            where TInstance : class, ICollection<IDisposable>, IDisposable
            where TFactory : PlaceholderFactory<P0, P1, P2, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactoryFromSubScope<P0, P1, P2, TInstance>(subScopeInstaller)
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<P0, P1, P2, TInstance>>()
                                    })
                                .SingleInstance()
                                .ExternallyOwned();
                        })
                        .AddTo(scope.Disposer);

                    return subScope.Resolve<TFactory>();
                });
        }

        public static IRegistrationBuilder<
            IFactory<P0, P1, P2, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromSubScope<P0, P1, P2, TInstance>(
                this ContainerBuilder builder,
                Action<ContainerBuilder, P0, P1, P2> subScopeInstaller
                )
            where TInstance : class, ICollection<IDisposable>, IDisposable
        {
            return builder
                .RegisterType<AutofacSubScopeFactory<P0, P1, P2, TInstance>>()
                .WithParameter(TypedParameter.From(subScopeInstaller))
                .As<IFactory<P0, P1, P2, TInstance>>();
        }

        private class AutofacSubScopeFactory<P0, P1, P2, TInstance> : IFactory<P0, P1, P2, TInstance>
            where TInstance : class, ICollection<IDisposable>, IDisposable
        {
            private readonly ILifetimeScope _scope;
            private readonly Action<ContainerBuilder, P0, P1, P2> _subScopeInstaller;

            public AutofacSubScopeFactory(ILifetimeScope scope, Action<ContainerBuilder, P0, P1, P2> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(P0 param0, P1 param1, P2 param2)
            {
                var guid = Guid.NewGuid();

                var subScope = _scope
                    .BeginLifetimeScope(guid, subScopeBuilder =>
                    {
                        subScopeBuilder.OverrideExternallyOwnedInScope<TInstance>(guid);
                        _subScopeInstaller(subScopeBuilder, param0, param1, param2);
                    });

                var instance = subScope.Resolve<TInstance>();

                subScope
                    .AddTo(instance);

                return instance;
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterPlaceholderFactory<P0, P1, P2, TInstance, TFactory>(this ContainerBuilder builder)
            where TInstance : class
            where TFactory : PlaceholderFactory<P0, P1, P2, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactory<P0, P1, P2, TInstance>()
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<P0, P1, P2, TInstance>>()
                                    })
                                .SingleInstance();
                        })
                        .AddTo(scope.Disposer);

                    return subScope.Resolve<TFactory>();
                });
        }


        public static IRegistrationBuilder<
            IFactory<P0, P1, P2, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactory<P0, P1, P2, TInstance>(this ContainerBuilder typeSourceSelector)
            where TInstance : class
        {
            return typeSourceSelector
                .RegisterType<AutofacResolveFactory<P0, P1, P2, TInstance>>()
                .As<IFactory<P0, P1, P2, TInstance>>();
        }

        private class AutofacResolveFactory<P0, P1, P2, TInstance> : IFactory<P0, P1, P2, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;

            public AutofacResolveFactory(ILifetimeScope scope)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
            }

            public TInstance Create(P0 param0, P1 param1, P2 param2)
            {
                return _scope.CreateInstance<TInstance>(parameters: [ param0, param1, param2 ]);
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromFunction<P0, P1, P2, P3, TInstance, TFactory>(
            this ContainerBuilder builder,
            Func<ILifetimeScope, P0, P1, P2, P3, TInstance> func)
            where TInstance : class
            where TFactory : PlaceholderFactory<P0, P1, P2, P3, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactoryFromFunction(func)
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<P0, P1, P2, P3, TInstance>>()
                                    })
                                .SingleInstance();
                        })
                        .AddTo(scope.Disposer);

                    return subScope.Resolve<TFactory>();
                });
        }

        public static IRegistrationBuilder<
            IFactory<P0, P1, P2, P3, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromFunction<P0, P1, P2, P3, TInstance>(
                this ContainerBuilder builder,
                Func<ILifetimeScope, P0, P1, P2, P3, TInstance> func)
            where TInstance : class
        {
            return builder
                .RegisterType<AutofacFunctionFactory<P0, P1, P2, P3, TInstance>>()
                .WithParameter(TypedParameter.From(func))
                .As<IFactory<P0, P1, P2, P3, TInstance>>();
        }

        private class AutofacFunctionFactory<P0, P1, P2, P3, TInstance> : IFactory<P0, P1, P2, P3, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;
            private readonly Func<ILifetimeScope, P0, P1, P2, P3, TInstance> _subScopeInstaller;

            public AutofacFunctionFactory(
                ILifetimeScope scope,
                Func<ILifetimeScope, P0, P1, P2, P3, TInstance> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(P0 param0, P1 param1, P2 param2, P3 param3)
            {
                return _subScopeInstaller(_scope, param0, param1, param2, param3);
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromSubScope<P0, P1, P2, P3, TInstance, TFactory>(
            this ContainerBuilder builder,
            Action<ContainerBuilder, P0, P1, P2, P3> subScopeInstaller
        )
            where TInstance : class, ICollection<IDisposable>, IDisposable
            where TFactory : PlaceholderFactory<P0, P1, P2, P3, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactoryFromSubScope<P0, P1, P2, P3, TInstance>(subScopeInstaller)
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<P0, P1, P2, P3, TInstance>>()
                                    })
                                .SingleInstance()
                                .ExternallyOwned();
                        })
                        .AddTo(scope.Disposer);

                    return subScope.Resolve<TFactory>();
                });
        }

        public static IRegistrationBuilder<
            IFactory<P0, P1, P2, P3, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromSubScope<P0, P1, P2, P3, TInstance>(
                this ContainerBuilder builder,
                Action<ContainerBuilder, P0, P1, P2, P3> subScopeInstaller
                )
            where TInstance : class, ICollection<IDisposable>, IDisposable
        {
            return builder
                .RegisterType<AutofacSubScopeFactory<P0, P1, P2, P3, TInstance>>()
                .WithParameter(TypedParameter.From(subScopeInstaller))
                .As<IFactory<P0, P1, P2, P3, TInstance>>();
        }

        private class AutofacSubScopeFactory<P0, P1, P2, P3, TInstance> : IFactory<P0, P1, P2, P3, TInstance>
            where TInstance : class, ICollection<IDisposable>, IDisposable
        {
            private readonly ILifetimeScope _scope;
            private readonly Action<ContainerBuilder, P0, P1, P2, P3> _subScopeInstaller;

            public AutofacSubScopeFactory(ILifetimeScope scope, Action<ContainerBuilder, P0, P1, P2, P3> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(P0 param0, P1 param1, P2 param2, P3 param3)
            {
                var guid = Guid.NewGuid();

                var subScope = _scope
                    .BeginLifetimeScope(guid, subScopeBuilder =>
                    {
                        subScopeBuilder.OverrideExternallyOwnedInScope<TInstance>(guid);
                        _subScopeInstaller(subScopeBuilder, param0, param1, param2, param3);
                    });

                var instance = subScope.Resolve<TInstance>();

                subScope
                    .AddTo(instance);

                return instance;
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterPlaceholderFactory<P0, P1, P2, P3, TInstance, TFactory>(this ContainerBuilder builder)
            where TInstance : class
            where TFactory : PlaceholderFactory<P0, P1, P2, P3, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactory<P0, P1, P2, P3, TInstance>()
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<P0, P1, P2, P3, TInstance>>()
                                    })
                                .SingleInstance();
                        })
                        .AddTo(scope.Disposer);

                    return subScope.Resolve<TFactory>();
                });
        }


        public static IRegistrationBuilder<
            IFactory<P0, P1, P2, P3, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactory<P0, P1, P2, P3, TInstance>(this ContainerBuilder typeSourceSelector)
            where TInstance : class
        {
            return typeSourceSelector
                .RegisterType<AutofacResolveFactory<P0, P1, P2, P3, TInstance>>()
                .As<IFactory<P0, P1, P2, P3, TInstance>>();
        }

        private class AutofacResolveFactory<P0, P1, P2, P3, TInstance> : IFactory<P0, P1, P2, P3, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;

            public AutofacResolveFactory(ILifetimeScope scope)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
            }

            public TInstance Create(P0 param0, P1 param1, P2 param2, P3 param3)
            {
                return _scope.CreateInstance<TInstance>(parameters: [ param0, param1, param2, param3 ]);
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromFunction<P0, P1, P2, P3, P4, TInstance, TFactory>(
            this ContainerBuilder builder,
            Func<ILifetimeScope, P0, P1, P2, P3, P4, TInstance> func)
            where TInstance : class
            where TFactory : PlaceholderFactory<P0, P1, P2, P3, P4, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactoryFromFunction(func)
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<P0, P1, P2, P3, P4, TInstance>>()
                                    })
                                .SingleInstance();
                        })
                        .AddTo(scope.Disposer);

                    return subScope.Resolve<TFactory>();
                });
        }

        public static IRegistrationBuilder<
            IFactory<P0, P1, P2, P3, P4, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromFunction<P0, P1, P2, P3, P4, TInstance>(
                this ContainerBuilder builder,
                Func<ILifetimeScope, P0, P1, P2, P3, P4, TInstance> func)
            where TInstance : class
        {
            return builder
                .RegisterType<AutofacFunctionFactory<P0, P1, P2, P3, P4, TInstance>>()
                .WithParameter(TypedParameter.From(func))
                .As<IFactory<P0, P1, P2, P3, P4, TInstance>>();
        }

        private class AutofacFunctionFactory<P0, P1, P2, P3, P4, TInstance> : IFactory<P0, P1, P2, P3, P4, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;
            private readonly Func<ILifetimeScope, P0, P1, P2, P3, P4, TInstance> _subScopeInstaller;

            public AutofacFunctionFactory(
                ILifetimeScope scope,
                Func<ILifetimeScope, P0, P1, P2, P3, P4, TInstance> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(P0 param0, P1 param1, P2 param2, P3 param3, P4 param4)
            {
                return _subScopeInstaller(_scope, param0, param1, param2, param3, param4);
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromSubScope<P0, P1, P2, P3, P4, TInstance, TFactory>(
            this ContainerBuilder builder,
            Action<ContainerBuilder, P0, P1, P2, P3, P4> subScopeInstaller
        )
            where TInstance : class, ICollection<IDisposable>, IDisposable
            where TFactory : PlaceholderFactory<P0, P1, P2, P3, P4, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactoryFromSubScope<P0, P1, P2, P3, P4, TInstance>(subScopeInstaller)
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<P0, P1, P2, P3, P4, TInstance>>()
                                    })
                                .SingleInstance()
                                .ExternallyOwned();
                        })
                        .AddTo(scope.Disposer);

                    return subScope.Resolve<TFactory>();
                });
        }

        public static IRegistrationBuilder<
            IFactory<P0, P1, P2, P3, P4, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromSubScope<P0, P1, P2, P3, P4, TInstance>(
                this ContainerBuilder builder,
                Action<ContainerBuilder, P0, P1, P2, P3, P4> subScopeInstaller
                )
            where TInstance : class, ICollection<IDisposable>, IDisposable
        {
            return builder
                .RegisterType<AutofacSubScopeFactory<P0, P1, P2, P3, P4, TInstance>>()
                .WithParameter(TypedParameter.From(subScopeInstaller))
                .As<IFactory<P0, P1, P2, P3, P4, TInstance>>();
        }

        private class AutofacSubScopeFactory<P0, P1, P2, P3, P4, TInstance> : IFactory<P0, P1, P2, P3, P4, TInstance>
            where TInstance : class, ICollection<IDisposable>, IDisposable
        {
            private readonly ILifetimeScope _scope;
            private readonly Action<ContainerBuilder, P0, P1, P2, P3, P4> _subScopeInstaller;

            public AutofacSubScopeFactory(ILifetimeScope scope, Action<ContainerBuilder, P0, P1, P2, P3, P4> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(P0 param0, P1 param1, P2 param2, P3 param3, P4 param4)
            {
                var guid = Guid.NewGuid();

                var subScope = _scope
                    .BeginLifetimeScope(guid, subScopeBuilder =>
                    {
                        subScopeBuilder.OverrideExternallyOwnedInScope<TInstance>(guid);
                        _subScopeInstaller(subScopeBuilder, param0, param1, param2, param3, param4);
                    });

                var instance = subScope.Resolve<TInstance>();

                subScope
                    .AddTo(instance);

                return instance;
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterPlaceholderFactory<P0, P1, P2, P3, P4, TInstance, TFactory>(this ContainerBuilder builder)
            where TInstance : class
            where TFactory : PlaceholderFactory<P0, P1, P2, P3, P4, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactory<P0, P1, P2, P3, P4, TInstance>()
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<P0, P1, P2, P3, P4, TInstance>>()
                                    })
                                .SingleInstance();
                        })
                        .AddTo(scope.Disposer);

                    return subScope.Resolve<TFactory>();
                });
        }


        public static IRegistrationBuilder<
            IFactory<P0, P1, P2, P3, P4, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactory<P0, P1, P2, P3, P4, TInstance>(this ContainerBuilder typeSourceSelector)
            where TInstance : class
        {
            return typeSourceSelector
                .RegisterType<AutofacResolveFactory<P0, P1, P2, P3, P4, TInstance>>()
                .As<IFactory<P0, P1, P2, P3, P4, TInstance>>();
        }

        private class AutofacResolveFactory<P0, P1, P2, P3, P4, TInstance> : IFactory<P0, P1, P2, P3, P4, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;

            public AutofacResolveFactory(ILifetimeScope scope)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
            }

            public TInstance Create(P0 param0, P1 param1, P2 param2, P3 param3, P4 param4)
            {
                return _scope.CreateInstance<TInstance>(parameters: [ param0, param1, param2, param3, param4 ]);
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromFunction<P0, P1, P2, P3, P4, P5, TInstance, TFactory>(
            this ContainerBuilder builder,
            Func<ILifetimeScope, P0, P1, P2, P3, P4, P5, TInstance> func)
            where TInstance : class
            where TFactory : PlaceholderFactory<P0, P1, P2, P3, P4, P5, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactoryFromFunction(func)
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<P0, P1, P2, P3, P4, P5, TInstance>>()
                                    })
                                .SingleInstance();
                        })
                        .AddTo(scope.Disposer);

                    return subScope.Resolve<TFactory>();
                });
        }

        public static IRegistrationBuilder<
            IFactory<P0, P1, P2, P3, P4, P5, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromFunction<P0, P1, P2, P3, P4, P5, TInstance>(
                this ContainerBuilder builder,
                Func<ILifetimeScope, P0, P1, P2, P3, P4, P5, TInstance> func)
            where TInstance : class
        {
            return builder
                .RegisterType<AutofacFunctionFactory<P0, P1, P2, P3, P4, P5, TInstance>>()
                .WithParameter(TypedParameter.From(func))
                .As<IFactory<P0, P1, P2, P3, P4, P5, TInstance>>();
        }

        private class AutofacFunctionFactory<P0, P1, P2, P3, P4, P5, TInstance> : IFactory<P0, P1, P2, P3, P4, P5, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;
            private readonly Func<ILifetimeScope, P0, P1, P2, P3, P4, P5, TInstance> _subScopeInstaller;

            public AutofacFunctionFactory(
                ILifetimeScope scope,
                Func<ILifetimeScope, P0, P1, P2, P3, P4, P5, TInstance> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(P0 param0, P1 param1, P2 param2, P3 param3, P4 param4, P5 param5)
            {
                return _subScopeInstaller(_scope, param0, param1, param2, param3, param4, param5);
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromSubScope<P0, P1, P2, P3, P4, P5, TInstance, TFactory>(
            this ContainerBuilder builder,
            Action<ContainerBuilder, P0, P1, P2, P3, P4, P5> subScopeInstaller
        )
            where TInstance : class, ICollection<IDisposable>, IDisposable
            where TFactory : PlaceholderFactory<P0, P1, P2, P3, P4, P5, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactoryFromSubScope<P0, P1, P2, P3, P4, P5, TInstance>(subScopeInstaller)
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<P0, P1, P2, P3, P4, P5, TInstance>>()
                                    })
                                .SingleInstance()
                                .ExternallyOwned();
                        })
                        .AddTo(scope.Disposer);

                    return subScope.Resolve<TFactory>();
                });
        }

        public static IRegistrationBuilder<
            IFactory<P0, P1, P2, P3, P4, P5, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromSubScope<P0, P1, P2, P3, P4, P5, TInstance>(
                this ContainerBuilder builder,
                Action<ContainerBuilder, P0, P1, P2, P3, P4, P5> subScopeInstaller
                )
            where TInstance : class, ICollection<IDisposable>, IDisposable
        {
            return builder
                .RegisterType<AutofacSubScopeFactory<P0, P1, P2, P3, P4, P5, TInstance>>()
                .WithParameter(TypedParameter.From(subScopeInstaller))
                .As<IFactory<P0, P1, P2, P3, P4, P5, TInstance>>();
        }

        private class AutofacSubScopeFactory<P0, P1, P2, P3, P4, P5, TInstance> : IFactory<P0, P1, P2, P3, P4, P5, TInstance>
            where TInstance : class, ICollection<IDisposable>, IDisposable
        {
            private readonly ILifetimeScope _scope;
            private readonly Action<ContainerBuilder, P0, P1, P2, P3, P4, P5> _subScopeInstaller;

            public AutofacSubScopeFactory(ILifetimeScope scope, Action<ContainerBuilder, P0, P1, P2, P3, P4, P5> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(P0 param0, P1 param1, P2 param2, P3 param3, P4 param4, P5 param5)
            {
                var guid = Guid.NewGuid();

                var subScope = _scope
                    .BeginLifetimeScope(guid, subScopeBuilder =>
                    {
                        subScopeBuilder.OverrideExternallyOwnedInScope<TInstance>(guid);
                        _subScopeInstaller(subScopeBuilder, param0, param1, param2, param3, param4, param5);
                    });

                var instance = subScope.Resolve<TInstance>();

                subScope
                    .AddTo(instance);

                return instance;
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterPlaceholderFactory<P0, P1, P2, P3, P4, P5, TInstance, TFactory>(this ContainerBuilder builder)
            where TInstance : class
            where TFactory : PlaceholderFactory<P0, P1, P2, P3, P4, P5, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactory<P0, P1, P2, P3, P4, P5, TInstance>()
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<P0, P1, P2, P3, P4, P5, TInstance>>()
                                    })
                                .SingleInstance();
                        })
                        .AddTo(scope.Disposer);

                    return subScope.Resolve<TFactory>();
                });
        }


        public static IRegistrationBuilder<
            IFactory<P0, P1, P2, P3, P4, P5, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactory<P0, P1, P2, P3, P4, P5, TInstance>(this ContainerBuilder typeSourceSelector)
            where TInstance : class
        {
            return typeSourceSelector
                .RegisterType<AutofacResolveFactory<P0, P1, P2, P3, P4, P5, TInstance>>()
                .As<IFactory<P0, P1, P2, P3, P4, P5, TInstance>>();
        }

        private class AutofacResolveFactory<P0, P1, P2, P3, P4, P5, TInstance> : IFactory<P0, P1, P2, P3, P4, P5, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;

            public AutofacResolveFactory(ILifetimeScope scope)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
            }

            public TInstance Create(P0 param0, P1 param1, P2 param2, P3 param3, P4 param4, P5 param5)
            {
                return _scope.CreateInstance<TInstance>(parameters: [ param0, param1, param2, param3, param4, param5 ]);
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromFunction<P0, P1, P2, P3, P4, P5, P6, TInstance, TFactory>(
            this ContainerBuilder builder,
            Func<ILifetimeScope, P0, P1, P2, P3, P4, P5, P6, TInstance> func)
            where TInstance : class
            where TFactory : PlaceholderFactory<P0, P1, P2, P3, P4, P5, P6, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactoryFromFunction(func)
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<P0, P1, P2, P3, P4, P5, P6, TInstance>>()
                                    })
                                .SingleInstance();
                        })
                        .AddTo(scope.Disposer);

                    return subScope.Resolve<TFactory>();
                });
        }

        public static IRegistrationBuilder<
            IFactory<P0, P1, P2, P3, P4, P5, P6, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromFunction<P0, P1, P2, P3, P4, P5, P6, TInstance>(
                this ContainerBuilder builder,
                Func<ILifetimeScope, P0, P1, P2, P3, P4, P5, P6, TInstance> func)
            where TInstance : class
        {
            return builder
                .RegisterType<AutofacFunctionFactory<P0, P1, P2, P3, P4, P5, P6, TInstance>>()
                .WithParameter(TypedParameter.From(func))
                .As<IFactory<P0, P1, P2, P3, P4, P5, P6, TInstance>>();
        }

        private class AutofacFunctionFactory<P0, P1, P2, P3, P4, P5, P6, TInstance> : IFactory<P0, P1, P2, P3, P4, P5, P6, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;
            private readonly Func<ILifetimeScope, P0, P1, P2, P3, P4, P5, P6, TInstance> _subScopeInstaller;

            public AutofacFunctionFactory(
                ILifetimeScope scope,
                Func<ILifetimeScope, P0, P1, P2, P3, P4, P5, P6, TInstance> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(P0 param0, P1 param1, P2 param2, P3 param3, P4 param4, P5 param5, P6 param6)
            {
                return _subScopeInstaller(_scope, param0, param1, param2, param3, param4, param5, param6);
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromSubScope<P0, P1, P2, P3, P4, P5, P6, TInstance, TFactory>(
            this ContainerBuilder builder,
            Action<ContainerBuilder, P0, P1, P2, P3, P4, P5, P6> subScopeInstaller
        )
            where TInstance : class, ICollection<IDisposable>, IDisposable
            where TFactory : PlaceholderFactory<P0, P1, P2, P3, P4, P5, P6, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactoryFromSubScope<P0, P1, P2, P3, P4, P5, P6, TInstance>(subScopeInstaller)
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<P0, P1, P2, P3, P4, P5, P6, TInstance>>()
                                    })
                                .SingleInstance()
                                .ExternallyOwned();
                        })
                        .AddTo(scope.Disposer);

                    return subScope.Resolve<TFactory>();
                });
        }

        public static IRegistrationBuilder<
            IFactory<P0, P1, P2, P3, P4, P5, P6, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromSubScope<P0, P1, P2, P3, P4, P5, P6, TInstance>(
                this ContainerBuilder builder,
                Action<ContainerBuilder, P0, P1, P2, P3, P4, P5, P6> subScopeInstaller
                )
            where TInstance : class, ICollection<IDisposable>, IDisposable
        {
            return builder
                .RegisterType<AutofacSubScopeFactory<P0, P1, P2, P3, P4, P5, P6, TInstance>>()
                .WithParameter(TypedParameter.From(subScopeInstaller))
                .As<IFactory<P0, P1, P2, P3, P4, P5, P6, TInstance>>();
        }

        private class AutofacSubScopeFactory<P0, P1, P2, P3, P4, P5, P6, TInstance> : IFactory<P0, P1, P2, P3, P4, P5, P6, TInstance>
            where TInstance : class, ICollection<IDisposable>, IDisposable
        {
            private readonly ILifetimeScope _scope;
            private readonly Action<ContainerBuilder, P0, P1, P2, P3, P4, P5, P6> _subScopeInstaller;

            public AutofacSubScopeFactory(ILifetimeScope scope, Action<ContainerBuilder, P0, P1, P2, P3, P4, P5, P6> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(P0 param0, P1 param1, P2 param2, P3 param3, P4 param4, P5 param5, P6 param6)
            {
                var guid = Guid.NewGuid();

                var subScope = _scope
                    .BeginLifetimeScope(guid, subScopeBuilder =>
                    {
                        subScopeBuilder.OverrideExternallyOwnedInScope<TInstance>(guid);
                        _subScopeInstaller(subScopeBuilder, param0, param1, param2, param3, param4, param5, param6);
                    });

                var instance = subScope.Resolve<TInstance>();

                subScope
                    .AddTo(instance);

                return instance;
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterPlaceholderFactory<P0, P1, P2, P3, P4, P5, P6, TInstance, TFactory>(this ContainerBuilder builder)
            where TInstance : class
            where TFactory : PlaceholderFactory<P0, P1, P2, P3, P4, P5, P6, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactory<P0, P1, P2, P3, P4, P5, P6, TInstance>()
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<P0, P1, P2, P3, P4, P5, P6, TInstance>>()
                                    })
                                .SingleInstance();
                        })
                        .AddTo(scope.Disposer);

                    return subScope.Resolve<TFactory>();
                });
        }


        public static IRegistrationBuilder<
            IFactory<P0, P1, P2, P3, P4, P5, P6, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactory<P0, P1, P2, P3, P4, P5, P6, TInstance>(this ContainerBuilder typeSourceSelector)
            where TInstance : class
        {
            return typeSourceSelector
                .RegisterType<AutofacResolveFactory<P0, P1, P2, P3, P4, P5, P6, TInstance>>()
                .As<IFactory<P0, P1, P2, P3, P4, P5, P6, TInstance>>();
        }

        private class AutofacResolveFactory<P0, P1, P2, P3, P4, P5, P6, TInstance> : IFactory<P0, P1, P2, P3, P4, P5, P6, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;

            public AutofacResolveFactory(ILifetimeScope scope)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
            }

            public TInstance Create(P0 param0, P1 param1, P2 param2, P3 param3, P4 param4, P5 param5, P6 param6)
            {
                return _scope.CreateInstance<TInstance>(parameters: [ param0, param1, param2, param3, param4, param5, param6 ]);
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromFunction<P0, P1, P2, P3, P4, P5, P6, P7, TInstance, TFactory>(
            this ContainerBuilder builder,
            Func<ILifetimeScope, P0, P1, P2, P3, P4, P5, P6, P7, TInstance> func)
            where TInstance : class
            where TFactory : PlaceholderFactory<P0, P1, P2, P3, P4, P5, P6, P7, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactoryFromFunction(func)
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<P0, P1, P2, P3, P4, P5, P6, P7, TInstance>>()
                                    })
                                .SingleInstance();
                        })
                        .AddTo(scope.Disposer);

                    return subScope.Resolve<TFactory>();
                });
        }

        public static IRegistrationBuilder<
            IFactory<P0, P1, P2, P3, P4, P5, P6, P7, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromFunction<P0, P1, P2, P3, P4, P5, P6, P7, TInstance>(
                this ContainerBuilder builder,
                Func<ILifetimeScope, P0, P1, P2, P3, P4, P5, P6, P7, TInstance> func)
            where TInstance : class
        {
            return builder
                .RegisterType<AutofacFunctionFactory<P0, P1, P2, P3, P4, P5, P6, P7, TInstance>>()
                .WithParameter(TypedParameter.From(func))
                .As<IFactory<P0, P1, P2, P3, P4, P5, P6, P7, TInstance>>();
        }

        private class AutofacFunctionFactory<P0, P1, P2, P3, P4, P5, P6, P7, TInstance> : IFactory<P0, P1, P2, P3, P4, P5, P6, P7, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;
            private readonly Func<ILifetimeScope, P0, P1, P2, P3, P4, P5, P6, P7, TInstance> _subScopeInstaller;

            public AutofacFunctionFactory(
                ILifetimeScope scope,
                Func<ILifetimeScope, P0, P1, P2, P3, P4, P5, P6, P7, TInstance> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(P0 param0, P1 param1, P2 param2, P3 param3, P4 param4, P5 param5, P6 param6, P7 param7)
            {
                return _subScopeInstaller(_scope, param0, param1, param2, param3, param4, param5, param6, param7);
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromSubScope<P0, P1, P2, P3, P4, P5, P6, P7, TInstance, TFactory>(
            this ContainerBuilder builder,
            Action<ContainerBuilder, P0, P1, P2, P3, P4, P5, P6, P7> subScopeInstaller
        )
            where TInstance : class, ICollection<IDisposable>, IDisposable
            where TFactory : PlaceholderFactory<P0, P1, P2, P3, P4, P5, P6, P7, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactoryFromSubScope<P0, P1, P2, P3, P4, P5, P6, P7, TInstance>(subScopeInstaller)
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<P0, P1, P2, P3, P4, P5, P6, P7, TInstance>>()
                                    })
                                .SingleInstance()
                                .ExternallyOwned();
                        })
                        .AddTo(scope.Disposer);

                    return subScope.Resolve<TFactory>();
                });
        }

        public static IRegistrationBuilder<
            IFactory<P0, P1, P2, P3, P4, P5, P6, P7, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromSubScope<P0, P1, P2, P3, P4, P5, P6, P7, TInstance>(
                this ContainerBuilder builder,
                Action<ContainerBuilder, P0, P1, P2, P3, P4, P5, P6, P7> subScopeInstaller
                )
            where TInstance : class, ICollection<IDisposable>, IDisposable
        {
            return builder
                .RegisterType<AutofacSubScopeFactory<P0, P1, P2, P3, P4, P5, P6, P7, TInstance>>()
                .WithParameter(TypedParameter.From(subScopeInstaller))
                .As<IFactory<P0, P1, P2, P3, P4, P5, P6, P7, TInstance>>();
        }

        private class AutofacSubScopeFactory<P0, P1, P2, P3, P4, P5, P6, P7, TInstance> : IFactory<P0, P1, P2, P3, P4, P5, P6, P7, TInstance>
            where TInstance : class, ICollection<IDisposable>, IDisposable
        {
            private readonly ILifetimeScope _scope;
            private readonly Action<ContainerBuilder, P0, P1, P2, P3, P4, P5, P6, P7> _subScopeInstaller;

            public AutofacSubScopeFactory(ILifetimeScope scope, Action<ContainerBuilder, P0, P1, P2, P3, P4, P5, P6, P7> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(P0 param0, P1 param1, P2 param2, P3 param3, P4 param4, P5 param5, P6 param6, P7 param7)
            {
                var guid = Guid.NewGuid();

                var subScope = _scope
                    .BeginLifetimeScope(guid, subScopeBuilder =>
                    {
                        subScopeBuilder.OverrideExternallyOwnedInScope<TInstance>(guid);
                        _subScopeInstaller(subScopeBuilder, param0, param1, param2, param3, param4, param5, param6, param7);
                    });

                var instance = subScope.Resolve<TInstance>();

                subScope
                    .AddTo(instance);

                return instance;
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterPlaceholderFactory<P0, P1, P2, P3, P4, P5, P6, P7, TInstance, TFactory>(this ContainerBuilder builder)
            where TInstance : class
            where TFactory : PlaceholderFactory<P0, P1, P2, P3, P4, P5, P6, P7, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactory<P0, P1, P2, P3, P4, P5, P6, P7, TInstance>()
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<P0, P1, P2, P3, P4, P5, P6, P7, TInstance>>()
                                    })
                                .SingleInstance();
                        })
                        .AddTo(scope.Disposer);

                    return subScope.Resolve<TFactory>();
                });
        }


        public static IRegistrationBuilder<
            IFactory<P0, P1, P2, P3, P4, P5, P6, P7, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactory<P0, P1, P2, P3, P4, P5, P6, P7, TInstance>(this ContainerBuilder typeSourceSelector)
            where TInstance : class
        {
            return typeSourceSelector
                .RegisterType<AutofacResolveFactory<P0, P1, P2, P3, P4, P5, P6, P7, TInstance>>()
                .As<IFactory<P0, P1, P2, P3, P4, P5, P6, P7, TInstance>>();
        }

        private class AutofacResolveFactory<P0, P1, P2, P3, P4, P5, P6, P7, TInstance> : IFactory<P0, P1, P2, P3, P4, P5, P6, P7, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;

            public AutofacResolveFactory(ILifetimeScope scope)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
            }

            public TInstance Create(P0 param0, P1 param1, P2 param2, P3 param3, P4 param4, P5 param5, P6 param6, P7 param7)
            {
                return _scope.CreateInstance<TInstance>(parameters: [ param0, param1, param2, param3, param4, param5, param6, param7 ]);
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromFunction<P0, P1, P2, P3, P4, P5, P6, P7, P8, TInstance, TFactory>(
            this ContainerBuilder builder,
            Func<ILifetimeScope, P0, P1, P2, P3, P4, P5, P6, P7, P8, TInstance> func)
            where TInstance : class
            where TFactory : PlaceholderFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactoryFromFunction(func)
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, TInstance>>()
                                    })
                                .SingleInstance();
                        })
                        .AddTo(scope.Disposer);

                    return subScope.Resolve<TFactory>();
                });
        }

        public static IRegistrationBuilder<
            IFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromFunction<P0, P1, P2, P3, P4, P5, P6, P7, P8, TInstance>(
                this ContainerBuilder builder,
                Func<ILifetimeScope, P0, P1, P2, P3, P4, P5, P6, P7, P8, TInstance> func)
            where TInstance : class
        {
            return builder
                .RegisterType<AutofacFunctionFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, TInstance>>()
                .WithParameter(TypedParameter.From(func))
                .As<IFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, TInstance>>();
        }

        private class AutofacFunctionFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, TInstance> : IFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;
            private readonly Func<ILifetimeScope, P0, P1, P2, P3, P4, P5, P6, P7, P8, TInstance> _subScopeInstaller;

            public AutofacFunctionFactory(
                ILifetimeScope scope,
                Func<ILifetimeScope, P0, P1, P2, P3, P4, P5, P6, P7, P8, TInstance> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(P0 param0, P1 param1, P2 param2, P3 param3, P4 param4, P5 param5, P6 param6, P7 param7, P8 param8)
            {
                return _subScopeInstaller(_scope, param0, param1, param2, param3, param4, param5, param6, param7, param8);
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromSubScope<P0, P1, P2, P3, P4, P5, P6, P7, P8, TInstance, TFactory>(
            this ContainerBuilder builder,
            Action<ContainerBuilder, P0, P1, P2, P3, P4, P5, P6, P7, P8> subScopeInstaller
        )
            where TInstance : class, ICollection<IDisposable>, IDisposable
            where TFactory : PlaceholderFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactoryFromSubScope<P0, P1, P2, P3, P4, P5, P6, P7, P8, TInstance>(subScopeInstaller)
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, TInstance>>()
                                    })
                                .SingleInstance()
                                .ExternallyOwned();
                        })
                        .AddTo(scope.Disposer);

                    return subScope.Resolve<TFactory>();
                });
        }

        public static IRegistrationBuilder<
            IFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromSubScope<P0, P1, P2, P3, P4, P5, P6, P7, P8, TInstance>(
                this ContainerBuilder builder,
                Action<ContainerBuilder, P0, P1, P2, P3, P4, P5, P6, P7, P8> subScopeInstaller
                )
            where TInstance : class, ICollection<IDisposable>, IDisposable
        {
            return builder
                .RegisterType<AutofacSubScopeFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, TInstance>>()
                .WithParameter(TypedParameter.From(subScopeInstaller))
                .As<IFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, TInstance>>();
        }

        private class AutofacSubScopeFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, TInstance> : IFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, TInstance>
            where TInstance : class, ICollection<IDisposable>, IDisposable
        {
            private readonly ILifetimeScope _scope;
            private readonly Action<ContainerBuilder, P0, P1, P2, P3, P4, P5, P6, P7, P8> _subScopeInstaller;

            public AutofacSubScopeFactory(ILifetimeScope scope, Action<ContainerBuilder, P0, P1, P2, P3, P4, P5, P6, P7, P8> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(P0 param0, P1 param1, P2 param2, P3 param3, P4 param4, P5 param5, P6 param6, P7 param7, P8 param8)
            {
                var guid = Guid.NewGuid();

                var subScope = _scope
                    .BeginLifetimeScope(guid, subScopeBuilder =>
                    {
                        subScopeBuilder.OverrideExternallyOwnedInScope<TInstance>(guid);
                        _subScopeInstaller(subScopeBuilder, param0, param1, param2, param3, param4, param5, param6, param7, param8);
                    });

                var instance = subScope.Resolve<TInstance>();

                subScope
                    .AddTo(instance);

                return instance;
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterPlaceholderFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, TInstance, TFactory>(this ContainerBuilder builder)
            where TInstance : class
            where TFactory : PlaceholderFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, TInstance>()
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, TInstance>>()
                                    })
                                .SingleInstance();
                        })
                        .AddTo(scope.Disposer);

                    return subScope.Resolve<TFactory>();
                });
        }


        public static IRegistrationBuilder<
            IFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, TInstance>(this ContainerBuilder typeSourceSelector)
            where TInstance : class
        {
            return typeSourceSelector
                .RegisterType<AutofacResolveFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, TInstance>>()
                .As<IFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, TInstance>>();
        }

        private class AutofacResolveFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, TInstance> : IFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;

            public AutofacResolveFactory(ILifetimeScope scope)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
            }

            public TInstance Create(P0 param0, P1 param1, P2 param2, P3 param3, P4 param4, P5 param5, P6 param6, P7 param7, P8 param8)
            {
                return _scope.CreateInstance<TInstance>(parameters: [ param0, param1, param2, param3, param4, param5, param6, param7, param8 ]);
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromFunction<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, TInstance, TFactory>(
            this ContainerBuilder builder,
            Func<ILifetimeScope, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, TInstance> func)
            where TInstance : class
            where TFactory : PlaceholderFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactoryFromFunction(func)
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, TInstance>>()
                                    })
                                .SingleInstance();
                        })
                        .AddTo(scope.Disposer);

                    return subScope.Resolve<TFactory>();
                });
        }

        public static IRegistrationBuilder<
            IFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromFunction<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, TInstance>(
                this ContainerBuilder builder,
                Func<ILifetimeScope, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, TInstance> func)
            where TInstance : class
        {
            return builder
                .RegisterType<AutofacFunctionFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, TInstance>>()
                .WithParameter(TypedParameter.From(func))
                .As<IFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, TInstance>>();
        }

        private class AutofacFunctionFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, TInstance> : IFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;
            private readonly Func<ILifetimeScope, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, TInstance> _subScopeInstaller;

            public AutofacFunctionFactory(
                ILifetimeScope scope,
                Func<ILifetimeScope, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, TInstance> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(P0 param0, P1 param1, P2 param2, P3 param3, P4 param4, P5 param5, P6 param6, P7 param7, P8 param8, P9 param9)
            {
                return _subScopeInstaller(_scope, param0, param1, param2, param3, param4, param5, param6, param7, param8, param9);
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromSubScope<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, TInstance, TFactory>(
            this ContainerBuilder builder,
            Action<ContainerBuilder, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9> subScopeInstaller
        )
            where TInstance : class, ICollection<IDisposable>, IDisposable
            where TFactory : PlaceholderFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactoryFromSubScope<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, TInstance>(subScopeInstaller)
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, TInstance>>()
                                    })
                                .SingleInstance()
                                .ExternallyOwned();
                        })
                        .AddTo(scope.Disposer);

                    return subScope.Resolve<TFactory>();
                });
        }

        public static IRegistrationBuilder<
            IFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromSubScope<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, TInstance>(
                this ContainerBuilder builder,
                Action<ContainerBuilder, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9> subScopeInstaller
                )
            where TInstance : class, ICollection<IDisposable>, IDisposable
        {
            return builder
                .RegisterType<AutofacSubScopeFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, TInstance>>()
                .WithParameter(TypedParameter.From(subScopeInstaller))
                .As<IFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, TInstance>>();
        }

        private class AutofacSubScopeFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, TInstance> : IFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, TInstance>
            where TInstance : class, ICollection<IDisposable>, IDisposable
        {
            private readonly ILifetimeScope _scope;
            private readonly Action<ContainerBuilder, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9> _subScopeInstaller;

            public AutofacSubScopeFactory(ILifetimeScope scope, Action<ContainerBuilder, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(P0 param0, P1 param1, P2 param2, P3 param3, P4 param4, P5 param5, P6 param6, P7 param7, P8 param8, P9 param9)
            {
                var guid = Guid.NewGuid();

                var subScope = _scope
                    .BeginLifetimeScope(guid, subScopeBuilder =>
                    {
                        subScopeBuilder.OverrideExternallyOwnedInScope<TInstance>(guid);
                        _subScopeInstaller(subScopeBuilder, param0, param1, param2, param3, param4, param5, param6, param7, param8, param9);
                    });

                var instance = subScope.Resolve<TInstance>();

                subScope
                    .AddTo(instance);

                return instance;
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterPlaceholderFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, TInstance, TFactory>(this ContainerBuilder builder)
            where TInstance : class
            where TFactory : PlaceholderFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, TInstance>()
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, TInstance>>()
                                    })
                                .SingleInstance();
                        })
                        .AddTo(scope.Disposer);

                    return subScope.Resolve<TFactory>();
                });
        }


        public static IRegistrationBuilder<
            IFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, TInstance>(this ContainerBuilder typeSourceSelector)
            where TInstance : class
        {
            return typeSourceSelector
                .RegisterType<AutofacResolveFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, TInstance>>()
                .As<IFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, TInstance>>();
        }

        private class AutofacResolveFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, TInstance> : IFactory<P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;

            public AutofacResolveFactory(ILifetimeScope scope)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
            }

            public TInstance Create(P0 param0, P1 param1, P2 param2, P3 param3, P4 param4, P5 param5, P6 param6, P7 param7, P8 param8, P9 param9)
            {
                return _scope.CreateInstance<TInstance>(parameters: [ param0, param1, param2, param3, param4, param5, param6, param7, param8, param9 ]);
            }
        }

    }
}