using Autofac;
using Autofac.Builder;
using Autofac2ZenjectLikeBridge.Extensions;
using Autofac2ZenjectLikeBridge.Extensions.HarmonyPatcher;
using Autofac2ZenjectLikeBridge.Interfaces;

namespace Autofac2ZenjectLikeBridge
{
    public static partial class DIExtensions
    {
        //generated amount 10

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

                    var factory = subScope.Resolve<TFactory>();

                    return subScope.AddToHarmony(factory);
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
            where TInstance : class, IDisposable
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


                    var factory = subScope.Resolve<TFactory>();

                    return subScope.AddToHarmony(factory);
                });
        }

        public static IRegistrationBuilder<
            IFactory<TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromSubScope<TInstance>(
                this ContainerBuilder builder,
                Action<ContainerBuilder> subScopeInstaller
                )
            where TInstance : class, IDisposable
        {
            return builder
                .RegisterType<AutofacSubScopeFactory<TInstance>>()
                .WithParameter(TypedParameter.From(subScopeInstaller))
                .As<IFactory<TInstance>>();
        }

        private class AutofacSubScopeFactory<TInstance> : IFactory<TInstance>
            where TInstance : class, IDisposable
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
                    .AddToHarmony(instance);

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

                    var factory = subScope.Resolve<TFactory>();

                    return subScope.AddToHarmony(factory);
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
            SingleRegistrationStyle> RegisterFactoryFromFunction<TP0, TInstance, TFactory>(
            this ContainerBuilder builder,
            Func<ILifetimeScope, TP0, TInstance> func)
            where TInstance : class
            where TFactory : PlaceholderFactory<TP0, TInstance>, new()
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
                                        Nested = context.Resolve<IFactory<TP0, TInstance>>()
                                    })
                                .SingleInstance();
                        })
                        .AddTo(scope.Disposer);

                    var factory = subScope.Resolve<TFactory>();

                    return subScope.AddToHarmony(factory);
                });
        }

        public static IRegistrationBuilder<
            IFactory<TP0, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromFunction<TP0, TInstance>(
                this ContainerBuilder builder,
                Func<ILifetimeScope, TP0, TInstance> func)
            where TInstance : class
        {
            return builder
                .RegisterType<AutofacFunctionFactory<TP0, TInstance>>()
                .WithParameter(TypedParameter.From(func))
                .As<IFactory<TP0, TInstance>>();
        }

        private class AutofacFunctionFactory<TP0, TInstance> : IFactory<TP0, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;
            private readonly Func<ILifetimeScope, TP0, TInstance> _subScopeInstaller;

            public AutofacFunctionFactory(
                ILifetimeScope scope,
                Func<ILifetimeScope, TP0, TInstance> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(TP0 param0)
            {
                return _subScopeInstaller(_scope, param0);
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromSubScope<TP0, TInstance, TFactory>(
            this ContainerBuilder builder,
            Action<ContainerBuilder, TP0> subScopeInstaller
        )
            where TInstance : class, IDisposable
            where TFactory : PlaceholderFactory<TP0, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactoryFromSubScope<TP0, TInstance>(subScopeInstaller)
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<TP0, TInstance>>()
                                    })
                                .SingleInstance()
                                .ExternallyOwned();
                        })
                        .AddTo(scope.Disposer);


                    var factory = subScope.Resolve<TFactory>();

                    return subScope.AddToHarmony(factory);
                });
        }

        public static IRegistrationBuilder<
            IFactory<TP0, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromSubScope<TP0, TInstance>(
                this ContainerBuilder builder,
                Action<ContainerBuilder, TP0> subScopeInstaller
                )
            where TInstance : class, IDisposable
        {
            return builder
                .RegisterType<AutofacSubScopeFactory<TP0, TInstance>>()
                .WithParameter(TypedParameter.From(subScopeInstaller))
                .As<IFactory<TP0, TInstance>>();
        }

        private class AutofacSubScopeFactory<TP0, TInstance> : IFactory<TP0, TInstance>
            where TInstance : class, IDisposable
        {
            private readonly ILifetimeScope _scope;
            private readonly Action<ContainerBuilder, TP0> _subScopeInstaller;

            public AutofacSubScopeFactory(ILifetimeScope scope, Action<ContainerBuilder, TP0> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(TP0 param0)
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
                    .AddToHarmony(instance);

                return instance;
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterPlaceholderFactory<TP0, TInstance, TFactory>(this ContainerBuilder builder)
            where TInstance : class
            where TFactory : PlaceholderFactory<TP0, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactory<TP0, TInstance>()
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<TP0, TInstance>>()
                                    })
                                .SingleInstance();
                        })
                        .AddTo(scope.Disposer);

                    var factory = subScope.Resolve<TFactory>();

                    return subScope.AddToHarmony(factory);
                });
        }


        public static IRegistrationBuilder<
            IFactory<TP0, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactory<TP0, TInstance>(this ContainerBuilder typeSourceSelector)
            where TInstance : class
        {
            return typeSourceSelector
                .RegisterType<AutofacResolveFactory<TP0, TInstance>>()
                .As<IFactory<TP0, TInstance>>();
        }

        private class AutofacResolveFactory<TP0, TInstance> : IFactory<TP0, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;

            public AutofacResolveFactory(ILifetimeScope scope)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
            }

            public TInstance Create(TP0 param0)
            {
                return _scope.CreateInstance<TInstance>(parameters: [ param0 ]);
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromFunction<TP0, TP1, TInstance, TFactory>(
            this ContainerBuilder builder,
            Func<ILifetimeScope, TP0, TP1, TInstance> func)
            where TInstance : class
            where TFactory : PlaceholderFactory<TP0, TP1, TInstance>, new()
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
                                        Nested = context.Resolve<IFactory<TP0, TP1, TInstance>>()
                                    })
                                .SingleInstance();
                        })
                        .AddTo(scope.Disposer);

                    var factory = subScope.Resolve<TFactory>();

                    return subScope.AddToHarmony(factory);
                });
        }

        public static IRegistrationBuilder<
            IFactory<TP0, TP1, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromFunction<TP0, TP1, TInstance>(
                this ContainerBuilder builder,
                Func<ILifetimeScope, TP0, TP1, TInstance> func)
            where TInstance : class
        {
            return builder
                .RegisterType<AutofacFunctionFactory<TP0, TP1, TInstance>>()
                .WithParameter(TypedParameter.From(func))
                .As<IFactory<TP0, TP1, TInstance>>();
        }

        private class AutofacFunctionFactory<TP0, TP1, TInstance> : IFactory<TP0, TP1, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;
            private readonly Func<ILifetimeScope, TP0, TP1, TInstance> _subScopeInstaller;

            public AutofacFunctionFactory(
                ILifetimeScope scope,
                Func<ILifetimeScope, TP0, TP1, TInstance> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(TP0 param0, TP1 param1)
            {
                return _subScopeInstaller(_scope, param0, param1);
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromSubScope<TP0, TP1, TInstance, TFactory>(
            this ContainerBuilder builder,
            Action<ContainerBuilder, TP0, TP1> subScopeInstaller
        )
            where TInstance : class, IDisposable
            where TFactory : PlaceholderFactory<TP0, TP1, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactoryFromSubScope<TP0, TP1, TInstance>(subScopeInstaller)
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<TP0, TP1, TInstance>>()
                                    })
                                .SingleInstance()
                                .ExternallyOwned();
                        })
                        .AddTo(scope.Disposer);


                    var factory = subScope.Resolve<TFactory>();

                    return subScope.AddToHarmony(factory);
                });
        }

        public static IRegistrationBuilder<
            IFactory<TP0, TP1, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromSubScope<TP0, TP1, TInstance>(
                this ContainerBuilder builder,
                Action<ContainerBuilder, TP0, TP1> subScopeInstaller
                )
            where TInstance : class, IDisposable
        {
            return builder
                .RegisterType<AutofacSubScopeFactory<TP0, TP1, TInstance>>()
                .WithParameter(TypedParameter.From(subScopeInstaller))
                .As<IFactory<TP0, TP1, TInstance>>();
        }

        private class AutofacSubScopeFactory<TP0, TP1, TInstance> : IFactory<TP0, TP1, TInstance>
            where TInstance : class, IDisposable
        {
            private readonly ILifetimeScope _scope;
            private readonly Action<ContainerBuilder, TP0, TP1> _subScopeInstaller;

            public AutofacSubScopeFactory(ILifetimeScope scope, Action<ContainerBuilder, TP0, TP1> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(TP0 param0, TP1 param1)
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
                    .AddToHarmony(instance);

                return instance;
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterPlaceholderFactory<TP0, TP1, TInstance, TFactory>(this ContainerBuilder builder)
            where TInstance : class
            where TFactory : PlaceholderFactory<TP0, TP1, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactory<TP0, TP1, TInstance>()
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<TP0, TP1, TInstance>>()
                                    })
                                .SingleInstance();
                        })
                        .AddTo(scope.Disposer);

                    var factory = subScope.Resolve<TFactory>();

                    return subScope.AddToHarmony(factory);
                });
        }


        public static IRegistrationBuilder<
            IFactory<TP0, TP1, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactory<TP0, TP1, TInstance>(this ContainerBuilder typeSourceSelector)
            where TInstance : class
        {
            return typeSourceSelector
                .RegisterType<AutofacResolveFactory<TP0, TP1, TInstance>>()
                .As<IFactory<TP0, TP1, TInstance>>();
        }

        private class AutofacResolveFactory<TP0, TP1, TInstance> : IFactory<TP0, TP1, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;

            public AutofacResolveFactory(ILifetimeScope scope)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
            }

            public TInstance Create(TP0 param0, TP1 param1)
            {
                return _scope.CreateInstance<TInstance>(parameters: [ param0, param1 ]);
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromFunction<TP0, TP1, TP2, TInstance, TFactory>(
            this ContainerBuilder builder,
            Func<ILifetimeScope, TP0, TP1, TP2, TInstance> func)
            where TInstance : class
            where TFactory : PlaceholderFactory<TP0, TP1, TP2, TInstance>, new()
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
                                        Nested = context.Resolve<IFactory<TP0, TP1, TP2, TInstance>>()
                                    })
                                .SingleInstance();
                        })
                        .AddTo(scope.Disposer);

                    var factory = subScope.Resolve<TFactory>();

                    return subScope.AddToHarmony(factory);
                });
        }

        public static IRegistrationBuilder<
            IFactory<TP0, TP1, TP2, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromFunction<TP0, TP1, TP2, TInstance>(
                this ContainerBuilder builder,
                Func<ILifetimeScope, TP0, TP1, TP2, TInstance> func)
            where TInstance : class
        {
            return builder
                .RegisterType<AutofacFunctionFactory<TP0, TP1, TP2, TInstance>>()
                .WithParameter(TypedParameter.From(func))
                .As<IFactory<TP0, TP1, TP2, TInstance>>();
        }

        private class AutofacFunctionFactory<TP0, TP1, TP2, TInstance> : IFactory<TP0, TP1, TP2, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;
            private readonly Func<ILifetimeScope, TP0, TP1, TP2, TInstance> _subScopeInstaller;

            public AutofacFunctionFactory(
                ILifetimeScope scope,
                Func<ILifetimeScope, TP0, TP1, TP2, TInstance> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(TP0 param0, TP1 param1, TP2 param2)
            {
                return _subScopeInstaller(_scope, param0, param1, param2);
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromSubScope<TP0, TP1, TP2, TInstance, TFactory>(
            this ContainerBuilder builder,
            Action<ContainerBuilder, TP0, TP1, TP2> subScopeInstaller
        )
            where TInstance : class, IDisposable
            where TFactory : PlaceholderFactory<TP0, TP1, TP2, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactoryFromSubScope<TP0, TP1, TP2, TInstance>(subScopeInstaller)
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<TP0, TP1, TP2, TInstance>>()
                                    })
                                .SingleInstance()
                                .ExternallyOwned();
                        })
                        .AddTo(scope.Disposer);


                    var factory = subScope.Resolve<TFactory>();

                    return subScope.AddToHarmony(factory);
                });
        }

        public static IRegistrationBuilder<
            IFactory<TP0, TP1, TP2, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromSubScope<TP0, TP1, TP2, TInstance>(
                this ContainerBuilder builder,
                Action<ContainerBuilder, TP0, TP1, TP2> subScopeInstaller
                )
            where TInstance : class, IDisposable
        {
            return builder
                .RegisterType<AutofacSubScopeFactory<TP0, TP1, TP2, TInstance>>()
                .WithParameter(TypedParameter.From(subScopeInstaller))
                .As<IFactory<TP0, TP1, TP2, TInstance>>();
        }

        private class AutofacSubScopeFactory<TP0, TP1, TP2, TInstance> : IFactory<TP0, TP1, TP2, TInstance>
            where TInstance : class, IDisposable
        {
            private readonly ILifetimeScope _scope;
            private readonly Action<ContainerBuilder, TP0, TP1, TP2> _subScopeInstaller;

            public AutofacSubScopeFactory(ILifetimeScope scope, Action<ContainerBuilder, TP0, TP1, TP2> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(TP0 param0, TP1 param1, TP2 param2)
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
                    .AddToHarmony(instance);

                return instance;
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterPlaceholderFactory<TP0, TP1, TP2, TInstance, TFactory>(this ContainerBuilder builder)
            where TInstance : class
            where TFactory : PlaceholderFactory<TP0, TP1, TP2, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactory<TP0, TP1, TP2, TInstance>()
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<TP0, TP1, TP2, TInstance>>()
                                    })
                                .SingleInstance();
                        })
                        .AddTo(scope.Disposer);

                    var factory = subScope.Resolve<TFactory>();

                    return subScope.AddToHarmony(factory);
                });
        }


        public static IRegistrationBuilder<
            IFactory<TP0, TP1, TP2, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactory<TP0, TP1, TP2, TInstance>(this ContainerBuilder typeSourceSelector)
            where TInstance : class
        {
            return typeSourceSelector
                .RegisterType<AutofacResolveFactory<TP0, TP1, TP2, TInstance>>()
                .As<IFactory<TP0, TP1, TP2, TInstance>>();
        }

        private class AutofacResolveFactory<TP0, TP1, TP2, TInstance> : IFactory<TP0, TP1, TP2, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;

            public AutofacResolveFactory(ILifetimeScope scope)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
            }

            public TInstance Create(TP0 param0, TP1 param1, TP2 param2)
            {
                return _scope.CreateInstance<TInstance>(parameters: [ param0, param1, param2 ]);
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromFunction<TP0, TP1, TP2, TP3, TInstance, TFactory>(
            this ContainerBuilder builder,
            Func<ILifetimeScope, TP0, TP1, TP2, TP3, TInstance> func)
            where TInstance : class
            where TFactory : PlaceholderFactory<TP0, TP1, TP2, TP3, TInstance>, new()
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
                                        Nested = context.Resolve<IFactory<TP0, TP1, TP2, TP3, TInstance>>()
                                    })
                                .SingleInstance();
                        })
                        .AddTo(scope.Disposer);

                    var factory = subScope.Resolve<TFactory>();

                    return subScope.AddToHarmony(factory);
                });
        }

        public static IRegistrationBuilder<
            IFactory<TP0, TP1, TP2, TP3, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromFunction<TP0, TP1, TP2, TP3, TInstance>(
                this ContainerBuilder builder,
                Func<ILifetimeScope, TP0, TP1, TP2, TP3, TInstance> func)
            where TInstance : class
        {
            return builder
                .RegisterType<AutofacFunctionFactory<TP0, TP1, TP2, TP3, TInstance>>()
                .WithParameter(TypedParameter.From(func))
                .As<IFactory<TP0, TP1, TP2, TP3, TInstance>>();
        }

        private class AutofacFunctionFactory<TP0, TP1, TP2, TP3, TInstance> : IFactory<TP0, TP1, TP2, TP3, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;
            private readonly Func<ILifetimeScope, TP0, TP1, TP2, TP3, TInstance> _subScopeInstaller;

            public AutofacFunctionFactory(
                ILifetimeScope scope,
                Func<ILifetimeScope, TP0, TP1, TP2, TP3, TInstance> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(TP0 param0, TP1 param1, TP2 param2, TP3 param3)
            {
                return _subScopeInstaller(_scope, param0, param1, param2, param3);
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromSubScope<TP0, TP1, TP2, TP3, TInstance, TFactory>(
            this ContainerBuilder builder,
            Action<ContainerBuilder, TP0, TP1, TP2, TP3> subScopeInstaller
        )
            where TInstance : class, IDisposable
            where TFactory : PlaceholderFactory<TP0, TP1, TP2, TP3, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactoryFromSubScope<TP0, TP1, TP2, TP3, TInstance>(subScopeInstaller)
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<TP0, TP1, TP2, TP3, TInstance>>()
                                    })
                                .SingleInstance()
                                .ExternallyOwned();
                        })
                        .AddTo(scope.Disposer);


                    var factory = subScope.Resolve<TFactory>();

                    return subScope.AddToHarmony(factory);
                });
        }

        public static IRegistrationBuilder<
            IFactory<TP0, TP1, TP2, TP3, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromSubScope<TP0, TP1, TP2, TP3, TInstance>(
                this ContainerBuilder builder,
                Action<ContainerBuilder, TP0, TP1, TP2, TP3> subScopeInstaller
                )
            where TInstance : class, IDisposable
        {
            return builder
                .RegisterType<AutofacSubScopeFactory<TP0, TP1, TP2, TP3, TInstance>>()
                .WithParameter(TypedParameter.From(subScopeInstaller))
                .As<IFactory<TP0, TP1, TP2, TP3, TInstance>>();
        }

        private class AutofacSubScopeFactory<TP0, TP1, TP2, TP3, TInstance> : IFactory<TP0, TP1, TP2, TP3, TInstance>
            where TInstance : class, IDisposable
        {
            private readonly ILifetimeScope _scope;
            private readonly Action<ContainerBuilder, TP0, TP1, TP2, TP3> _subScopeInstaller;

            public AutofacSubScopeFactory(ILifetimeScope scope, Action<ContainerBuilder, TP0, TP1, TP2, TP3> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(TP0 param0, TP1 param1, TP2 param2, TP3 param3)
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
                    .AddToHarmony(instance);

                return instance;
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterPlaceholderFactory<TP0, TP1, TP2, TP3, TInstance, TFactory>(this ContainerBuilder builder)
            where TInstance : class
            where TFactory : PlaceholderFactory<TP0, TP1, TP2, TP3, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactory<TP0, TP1, TP2, TP3, TInstance>()
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<TP0, TP1, TP2, TP3, TInstance>>()
                                    })
                                .SingleInstance();
                        })
                        .AddTo(scope.Disposer);

                    var factory = subScope.Resolve<TFactory>();

                    return subScope.AddToHarmony(factory);
                });
        }


        public static IRegistrationBuilder<
            IFactory<TP0, TP1, TP2, TP3, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactory<TP0, TP1, TP2, TP3, TInstance>(this ContainerBuilder typeSourceSelector)
            where TInstance : class
        {
            return typeSourceSelector
                .RegisterType<AutofacResolveFactory<TP0, TP1, TP2, TP3, TInstance>>()
                .As<IFactory<TP0, TP1, TP2, TP3, TInstance>>();
        }

        private class AutofacResolveFactory<TP0, TP1, TP2, TP3, TInstance> : IFactory<TP0, TP1, TP2, TP3, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;

            public AutofacResolveFactory(ILifetimeScope scope)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
            }

            public TInstance Create(TP0 param0, TP1 param1, TP2 param2, TP3 param3)
            {
                return _scope.CreateInstance<TInstance>(parameters: [ param0, param1, param2, param3 ]);
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromFunction<TP0, TP1, TP2, TP3, TP4, TInstance, TFactory>(
            this ContainerBuilder builder,
            Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TInstance> func)
            where TInstance : class
            where TFactory : PlaceholderFactory<TP0, TP1, TP2, TP3, TP4, TInstance>, new()
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
                                        Nested = context.Resolve<IFactory<TP0, TP1, TP2, TP3, TP4, TInstance>>()
                                    })
                                .SingleInstance();
                        })
                        .AddTo(scope.Disposer);

                    var factory = subScope.Resolve<TFactory>();

                    return subScope.AddToHarmony(factory);
                });
        }

        public static IRegistrationBuilder<
            IFactory<TP0, TP1, TP2, TP3, TP4, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromFunction<TP0, TP1, TP2, TP3, TP4, TInstance>(
                this ContainerBuilder builder,
                Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TInstance> func)
            where TInstance : class
        {
            return builder
                .RegisterType<AutofacFunctionFactory<TP0, TP1, TP2, TP3, TP4, TInstance>>()
                .WithParameter(TypedParameter.From(func))
                .As<IFactory<TP0, TP1, TP2, TP3, TP4, TInstance>>();
        }

        private class AutofacFunctionFactory<TP0, TP1, TP2, TP3, TP4, TInstance> : IFactory<TP0, TP1, TP2, TP3, TP4, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;
            private readonly Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TInstance> _subScopeInstaller;

            public AutofacFunctionFactory(
                ILifetimeScope scope,
                Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TInstance> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(TP0 param0, TP1 param1, TP2 param2, TP3 param3, TP4 param4)
            {
                return _subScopeInstaller(_scope, param0, param1, param2, param3, param4);
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromSubScope<TP0, TP1, TP2, TP3, TP4, TInstance, TFactory>(
            this ContainerBuilder builder,
            Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4> subScopeInstaller
        )
            where TInstance : class, IDisposable
            where TFactory : PlaceholderFactory<TP0, TP1, TP2, TP3, TP4, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactoryFromSubScope<TP0, TP1, TP2, TP3, TP4, TInstance>(subScopeInstaller)
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<TP0, TP1, TP2, TP3, TP4, TInstance>>()
                                    })
                                .SingleInstance()
                                .ExternallyOwned();
                        })
                        .AddTo(scope.Disposer);


                    var factory = subScope.Resolve<TFactory>();

                    return subScope.AddToHarmony(factory);
                });
        }

        public static IRegistrationBuilder<
            IFactory<TP0, TP1, TP2, TP3, TP4, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromSubScope<TP0, TP1, TP2, TP3, TP4, TInstance>(
                this ContainerBuilder builder,
                Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4> subScopeInstaller
                )
            where TInstance : class, IDisposable
        {
            return builder
                .RegisterType<AutofacSubScopeFactory<TP0, TP1, TP2, TP3, TP4, TInstance>>()
                .WithParameter(TypedParameter.From(subScopeInstaller))
                .As<IFactory<TP0, TP1, TP2, TP3, TP4, TInstance>>();
        }

        private class AutofacSubScopeFactory<TP0, TP1, TP2, TP3, TP4, TInstance> : IFactory<TP0, TP1, TP2, TP3, TP4, TInstance>
            where TInstance : class, IDisposable
        {
            private readonly ILifetimeScope _scope;
            private readonly Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4> _subScopeInstaller;

            public AutofacSubScopeFactory(ILifetimeScope scope, Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(TP0 param0, TP1 param1, TP2 param2, TP3 param3, TP4 param4)
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
                    .AddToHarmony(instance);

                return instance;
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterPlaceholderFactory<TP0, TP1, TP2, TP3, TP4, TInstance, TFactory>(this ContainerBuilder builder)
            where TInstance : class
            where TFactory : PlaceholderFactory<TP0, TP1, TP2, TP3, TP4, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactory<TP0, TP1, TP2, TP3, TP4, TInstance>()
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<TP0, TP1, TP2, TP3, TP4, TInstance>>()
                                    })
                                .SingleInstance();
                        })
                        .AddTo(scope.Disposer);

                    var factory = subScope.Resolve<TFactory>();

                    return subScope.AddToHarmony(factory);
                });
        }


        public static IRegistrationBuilder<
            IFactory<TP0, TP1, TP2, TP3, TP4, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactory<TP0, TP1, TP2, TP3, TP4, TInstance>(this ContainerBuilder typeSourceSelector)
            where TInstance : class
        {
            return typeSourceSelector
                .RegisterType<AutofacResolveFactory<TP0, TP1, TP2, TP3, TP4, TInstance>>()
                .As<IFactory<TP0, TP1, TP2, TP3, TP4, TInstance>>();
        }

        private class AutofacResolveFactory<TP0, TP1, TP2, TP3, TP4, TInstance> : IFactory<TP0, TP1, TP2, TP3, TP4, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;

            public AutofacResolveFactory(ILifetimeScope scope)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
            }

            public TInstance Create(TP0 param0, TP1 param1, TP2 param2, TP3 param3, TP4 param4)
            {
                return _scope.CreateInstance<TInstance>(parameters: [ param0, param1, param2, param3, param4 ]);
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromFunction<TP0, TP1, TP2, TP3, TP4, TP5, TInstance, TFactory>(
            this ContainerBuilder builder,
            Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TInstance> func)
            where TInstance : class
            where TFactory : PlaceholderFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>, new()
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
                                        Nested = context.Resolve<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>>()
                                    })
                                .SingleInstance();
                        })
                        .AddTo(scope.Disposer);

                    var factory = subScope.Resolve<TFactory>();

                    return subScope.AddToHarmony(factory);
                });
        }

        public static IRegistrationBuilder<
            IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromFunction<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>(
                this ContainerBuilder builder,
                Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TInstance> func)
            where TInstance : class
        {
            return builder
                .RegisterType<AutofacFunctionFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>>()
                .WithParameter(TypedParameter.From(func))
                .As<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>>();
        }

        private class AutofacFunctionFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance> : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;
            private readonly Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TInstance> _subScopeInstaller;

            public AutofacFunctionFactory(
                ILifetimeScope scope,
                Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TInstance> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(TP0 param0, TP1 param1, TP2 param2, TP3 param3, TP4 param4, TP5 param5)
            {
                return _subScopeInstaller(_scope, param0, param1, param2, param3, param4, param5);
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TInstance, TFactory>(
            this ContainerBuilder builder,
            Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5> subScopeInstaller
        )
            where TInstance : class, IDisposable
            where TFactory : PlaceholderFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactoryFromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>(subScopeInstaller)
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>>()
                                    })
                                .SingleInstance()
                                .ExternallyOwned();
                        })
                        .AddTo(scope.Disposer);


                    var factory = subScope.Resolve<TFactory>();

                    return subScope.AddToHarmony(factory);
                });
        }

        public static IRegistrationBuilder<
            IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>(
                this ContainerBuilder builder,
                Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5> subScopeInstaller
                )
            where TInstance : class, IDisposable
        {
            return builder
                .RegisterType<AutofacSubScopeFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>>()
                .WithParameter(TypedParameter.From(subScopeInstaller))
                .As<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>>();
        }

        private class AutofacSubScopeFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance> : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>
            where TInstance : class, IDisposable
        {
            private readonly ILifetimeScope _scope;
            private readonly Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5> _subScopeInstaller;

            public AutofacSubScopeFactory(ILifetimeScope scope, Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(TP0 param0, TP1 param1, TP2 param2, TP3 param3, TP4 param4, TP5 param5)
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
                    .AddToHarmony(instance);

                return instance;
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterPlaceholderFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance, TFactory>(this ContainerBuilder builder)
            where TInstance : class
            where TFactory : PlaceholderFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>()
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>>()
                                    })
                                .SingleInstance();
                        })
                        .AddTo(scope.Disposer);

                    var factory = subScope.Resolve<TFactory>();

                    return subScope.AddToHarmony(factory);
                });
        }


        public static IRegistrationBuilder<
            IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>(this ContainerBuilder typeSourceSelector)
            where TInstance : class
        {
            return typeSourceSelector
                .RegisterType<AutofacResolveFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>>()
                .As<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>>();
        }

        private class AutofacResolveFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance> : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;

            public AutofacResolveFactory(ILifetimeScope scope)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
            }

            public TInstance Create(TP0 param0, TP1 param1, TP2 param2, TP3 param3, TP4 param4, TP5 param5)
            {
                return _scope.CreateInstance<TInstance>(parameters: [ param0, param1, param2, param3, param4, param5 ]);
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromFunction<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance, TFactory>(
            this ContainerBuilder builder,
            Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance> func)
            where TInstance : class
            where TFactory : PlaceholderFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>, new()
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
                                        Nested = context.Resolve<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>>()
                                    })
                                .SingleInstance();
                        })
                        .AddTo(scope.Disposer);

                    var factory = subScope.Resolve<TFactory>();

                    return subScope.AddToHarmony(factory);
                });
        }

        public static IRegistrationBuilder<
            IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromFunction<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>(
                this ContainerBuilder builder,
                Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance> func)
            where TInstance : class
        {
            return builder
                .RegisterType<AutofacFunctionFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>>()
                .WithParameter(TypedParameter.From(func))
                .As<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>>();
        }

        private class AutofacFunctionFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance> : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;
            private readonly Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance> _subScopeInstaller;

            public AutofacFunctionFactory(
                ILifetimeScope scope,
                Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(TP0 param0, TP1 param1, TP2 param2, TP3 param3, TP4 param4, TP5 param5, TP6 param6)
            {
                return _subScopeInstaller(_scope, param0, param1, param2, param3, param4, param5, param6);
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance, TFactory>(
            this ContainerBuilder builder,
            Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6> subScopeInstaller
        )
            where TInstance : class, IDisposable
            where TFactory : PlaceholderFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactoryFromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>(subScopeInstaller)
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>>()
                                    })
                                .SingleInstance()
                                .ExternallyOwned();
                        })
                        .AddTo(scope.Disposer);


                    var factory = subScope.Resolve<TFactory>();

                    return subScope.AddToHarmony(factory);
                });
        }

        public static IRegistrationBuilder<
            IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>(
                this ContainerBuilder builder,
                Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6> subScopeInstaller
                )
            where TInstance : class, IDisposable
        {
            return builder
                .RegisterType<AutofacSubScopeFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>>()
                .WithParameter(TypedParameter.From(subScopeInstaller))
                .As<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>>();
        }

        private class AutofacSubScopeFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance> : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>
            where TInstance : class, IDisposable
        {
            private readonly ILifetimeScope _scope;
            private readonly Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6> _subScopeInstaller;

            public AutofacSubScopeFactory(ILifetimeScope scope, Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(TP0 param0, TP1 param1, TP2 param2, TP3 param3, TP4 param4, TP5 param5, TP6 param6)
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
                    .AddToHarmony(instance);

                return instance;
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterPlaceholderFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance, TFactory>(this ContainerBuilder builder)
            where TInstance : class
            where TFactory : PlaceholderFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>()
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>>()
                                    })
                                .SingleInstance();
                        })
                        .AddTo(scope.Disposer);

                    var factory = subScope.Resolve<TFactory>();

                    return subScope.AddToHarmony(factory);
                });
        }


        public static IRegistrationBuilder<
            IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>(this ContainerBuilder typeSourceSelector)
            where TInstance : class
        {
            return typeSourceSelector
                .RegisterType<AutofacResolveFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>>()
                .As<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>>();
        }

        private class AutofacResolveFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance> : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;

            public AutofacResolveFactory(ILifetimeScope scope)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
            }

            public TInstance Create(TP0 param0, TP1 param1, TP2 param2, TP3 param3, TP4 param4, TP5 param5, TP6 param6)
            {
                return _scope.CreateInstance<TInstance>(parameters: [ param0, param1, param2, param3, param4, param5, param6 ]);
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromFunction<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance, TFactory>(
            this ContainerBuilder builder,
            Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance> func)
            where TInstance : class
            where TFactory : PlaceholderFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>, new()
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
                                        Nested = context.Resolve<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>>()
                                    })
                                .SingleInstance();
                        })
                        .AddTo(scope.Disposer);

                    var factory = subScope.Resolve<TFactory>();

                    return subScope.AddToHarmony(factory);
                });
        }

        public static IRegistrationBuilder<
            IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromFunction<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>(
                this ContainerBuilder builder,
                Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance> func)
            where TInstance : class
        {
            return builder
                .RegisterType<AutofacFunctionFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>>()
                .WithParameter(TypedParameter.From(func))
                .As<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>>();
        }

        private class AutofacFunctionFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance> : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;
            private readonly Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance> _subScopeInstaller;

            public AutofacFunctionFactory(
                ILifetimeScope scope,
                Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(TP0 param0, TP1 param1, TP2 param2, TP3 param3, TP4 param4, TP5 param5, TP6 param6, TP7 param7)
            {
                return _subScopeInstaller(_scope, param0, param1, param2, param3, param4, param5, param6, param7);
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance, TFactory>(
            this ContainerBuilder builder,
            Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7> subScopeInstaller
        )
            where TInstance : class, IDisposable
            where TFactory : PlaceholderFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactoryFromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>(subScopeInstaller)
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>>()
                                    })
                                .SingleInstance()
                                .ExternallyOwned();
                        })
                        .AddTo(scope.Disposer);


                    var factory = subScope.Resolve<TFactory>();

                    return subScope.AddToHarmony(factory);
                });
        }

        public static IRegistrationBuilder<
            IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>(
                this ContainerBuilder builder,
                Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7> subScopeInstaller
                )
            where TInstance : class, IDisposable
        {
            return builder
                .RegisterType<AutofacSubScopeFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>>()
                .WithParameter(TypedParameter.From(subScopeInstaller))
                .As<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>>();
        }

        private class AutofacSubScopeFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance> : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>
            where TInstance : class, IDisposable
        {
            private readonly ILifetimeScope _scope;
            private readonly Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7> _subScopeInstaller;

            public AutofacSubScopeFactory(ILifetimeScope scope, Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(TP0 param0, TP1 param1, TP2 param2, TP3 param3, TP4 param4, TP5 param5, TP6 param6, TP7 param7)
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
                    .AddToHarmony(instance);

                return instance;
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterPlaceholderFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance, TFactory>(this ContainerBuilder builder)
            where TInstance : class
            where TFactory : PlaceholderFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>()
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>>()
                                    })
                                .SingleInstance();
                        })
                        .AddTo(scope.Disposer);

                    var factory = subScope.Resolve<TFactory>();

                    return subScope.AddToHarmony(factory);
                });
        }


        public static IRegistrationBuilder<
            IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>(this ContainerBuilder typeSourceSelector)
            where TInstance : class
        {
            return typeSourceSelector
                .RegisterType<AutofacResolveFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>>()
                .As<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>>();
        }

        private class AutofacResolveFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance> : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;

            public AutofacResolveFactory(ILifetimeScope scope)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
            }

            public TInstance Create(TP0 param0, TP1 param1, TP2 param2, TP3 param3, TP4 param4, TP5 param5, TP6 param6, TP7 param7)
            {
                return _scope.CreateInstance<TInstance>(parameters: [ param0, param1, param2, param3, param4, param5, param6, param7 ]);
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromFunction<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance, TFactory>(
            this ContainerBuilder builder,
            Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance> func)
            where TInstance : class
            where TFactory : PlaceholderFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>, new()
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
                                        Nested = context.Resolve<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>>()
                                    })
                                .SingleInstance();
                        })
                        .AddTo(scope.Disposer);

                    var factory = subScope.Resolve<TFactory>();

                    return subScope.AddToHarmony(factory);
                });
        }

        public static IRegistrationBuilder<
            IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromFunction<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>(
                this ContainerBuilder builder,
                Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance> func)
            where TInstance : class
        {
            return builder
                .RegisterType<AutofacFunctionFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>>()
                .WithParameter(TypedParameter.From(func))
                .As<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>>();
        }

        private class AutofacFunctionFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance> : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;
            private readonly Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance> _subScopeInstaller;

            public AutofacFunctionFactory(
                ILifetimeScope scope,
                Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(TP0 param0, TP1 param1, TP2 param2, TP3 param3, TP4 param4, TP5 param5, TP6 param6, TP7 param7, TP8 param8)
            {
                return _subScopeInstaller(_scope, param0, param1, param2, param3, param4, param5, param6, param7, param8);
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance, TFactory>(
            this ContainerBuilder builder,
            Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8> subScopeInstaller
        )
            where TInstance : class, IDisposable
            where TFactory : PlaceholderFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactoryFromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>(subScopeInstaller)
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>>()
                                    })
                                .SingleInstance()
                                .ExternallyOwned();
                        })
                        .AddTo(scope.Disposer);


                    var factory = subScope.Resolve<TFactory>();

                    return subScope.AddToHarmony(factory);
                });
        }

        public static IRegistrationBuilder<
            IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>(
                this ContainerBuilder builder,
                Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8> subScopeInstaller
                )
            where TInstance : class, IDisposable
        {
            return builder
                .RegisterType<AutofacSubScopeFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>>()
                .WithParameter(TypedParameter.From(subScopeInstaller))
                .As<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>>();
        }

        private class AutofacSubScopeFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance> : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>
            where TInstance : class, IDisposable
        {
            private readonly ILifetimeScope _scope;
            private readonly Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8> _subScopeInstaller;

            public AutofacSubScopeFactory(ILifetimeScope scope, Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(TP0 param0, TP1 param1, TP2 param2, TP3 param3, TP4 param4, TP5 param5, TP6 param6, TP7 param7, TP8 param8)
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
                    .AddToHarmony(instance);

                return instance;
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterPlaceholderFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance, TFactory>(this ContainerBuilder builder)
            where TInstance : class
            where TFactory : PlaceholderFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>()
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>>()
                                    })
                                .SingleInstance();
                        })
                        .AddTo(scope.Disposer);

                    var factory = subScope.Resolve<TFactory>();

                    return subScope.AddToHarmony(factory);
                });
        }


        public static IRegistrationBuilder<
            IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>(this ContainerBuilder typeSourceSelector)
            where TInstance : class
        {
            return typeSourceSelector
                .RegisterType<AutofacResolveFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>>()
                .As<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>>();
        }

        private class AutofacResolveFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance> : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;

            public AutofacResolveFactory(ILifetimeScope scope)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
            }

            public TInstance Create(TP0 param0, TP1 param1, TP2 param2, TP3 param3, TP4 param4, TP5 param5, TP6 param6, TP7 param7, TP8 param8)
            {
                return _scope.CreateInstance<TInstance>(parameters: [ param0, param1, param2, param3, param4, param5, param6, param7, param8 ]);
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromFunction<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance, TFactory>(
            this ContainerBuilder builder,
            Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance> func)
            where TInstance : class
            where TFactory : PlaceholderFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>, new()
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
                                        Nested = context.Resolve<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>>()
                                    })
                                .SingleInstance();
                        })
                        .AddTo(scope.Disposer);

                    var factory = subScope.Resolve<TFactory>();

                    return subScope.AddToHarmony(factory);
                });
        }

        public static IRegistrationBuilder<
            IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromFunction<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>(
                this ContainerBuilder builder,
                Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance> func)
            where TInstance : class
        {
            return builder
                .RegisterType<AutofacFunctionFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>>()
                .WithParameter(TypedParameter.From(func))
                .As<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>>();
        }

        private class AutofacFunctionFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance> : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;
            private readonly Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance> _subScopeInstaller;

            public AutofacFunctionFactory(
                ILifetimeScope scope,
                Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(TP0 param0, TP1 param1, TP2 param2, TP3 param3, TP4 param4, TP5 param5, TP6 param6, TP7 param7, TP8 param8, TP9 param9)
            {
                return _subScopeInstaller(_scope, param0, param1, param2, param3, param4, param5, param6, param7, param8, param9);
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance, TFactory>(
            this ContainerBuilder builder,
            Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9> subScopeInstaller
        )
            where TInstance : class, IDisposable
            where TFactory : PlaceholderFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactoryFromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>(subScopeInstaller)
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>>()
                                    })
                                .SingleInstance()
                                .ExternallyOwned();
                        })
                        .AddTo(scope.Disposer);


                    var factory = subScope.Resolve<TFactory>();

                    return subScope.AddToHarmony(factory);
                });
        }

        public static IRegistrationBuilder<
            IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactoryFromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>(
                this ContainerBuilder builder,
                Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9> subScopeInstaller
                )
            where TInstance : class, IDisposable
        {
            return builder
                .RegisterType<AutofacSubScopeFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>>()
                .WithParameter(TypedParameter.From(subScopeInstaller))
                .As<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>>();
        }

        private class AutofacSubScopeFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance> : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>
            where TInstance : class, IDisposable
        {
            private readonly ILifetimeScope _scope;
            private readonly Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9> _subScopeInstaller;

            public AutofacSubScopeFactory(ILifetimeScope scope, Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9> subScopeInstaller)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeInstaller = subScopeInstaller ?? throw new ArgumentNullException(nameof(subScopeInstaller));
            }

            public TInstance Create(TP0 param0, TP1 param1, TP2 param2, TP3 param3, TP4 param4, TP5 param5, TP6 param6, TP7 param7, TP8 param8, TP9 param9)
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
                    .AddToHarmony(instance);

                return instance;
            }
        }

        public static IRegistrationBuilder<
            TFactory,
            SimpleActivatorData,
            SingleRegistrationStyle> RegisterPlaceholderFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance, TFactory>(this ContainerBuilder builder)
            where TInstance : class
            where TFactory : PlaceholderFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>, new()
        {
            return builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>()
                                .SingleInstance();

                            subScopeBuilder
                                .Register(context
                                    => new TFactory
                                    {
                                        Nested = context.Resolve<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>>()
                                    })
                                .SingleInstance();
                        })
                        .AddTo(scope.Disposer);

                    var factory = subScope.Resolve<TFactory>();

                    return subScope.AddToHarmony(factory);
                });
        }


        public static IRegistrationBuilder<
            IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>,
            ConcreteReflectionActivatorData,
            SingleRegistrationStyle> RegisterFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>(this ContainerBuilder typeSourceSelector)
            where TInstance : class
        {
            return typeSourceSelector
                .RegisterType<AutofacResolveFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>>()
                .As<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>>();
        }

        private class AutofacResolveFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance> : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;

            public AutofacResolveFactory(ILifetimeScope scope)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
            }

            public TInstance Create(TP0 param0, TP1 param1, TP2 param2, TP3 param3, TP4 param4, TP5 param5, TP6 param6, TP7 param7, TP8 param8, TP9 param9)
            {
                return _scope.CreateInstance<TInstance>(parameters: [ param0, param1, param2, param3, param4, param5, param6, param7, param8, param9 ]);
            }
        }

    }
}