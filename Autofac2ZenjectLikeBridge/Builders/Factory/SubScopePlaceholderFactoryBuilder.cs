using System;
using Autofac;
using Autofac.Builder;
using Autofac2ZenjectLikeBridge.Entities.Factories;
using Autofac2ZenjectLikeBridge.Extensions.HarmonyPatcher;
using Autofac2ZenjectLikeBridge.Interfaces;
using Autofac2ZenjectLikeBridge.Interfaces.Builders.Factory;

namespace Autofac2ZenjectLikeBridge.Builders.Factory
{
    //generated amount 10

    public class SubScopePlaceholderFactoryBuilder<TInstance, TPlaceholderFactory>
        : ISubScopeFactoryBuilder<TInstance, TPlaceholderFactory, SimpleActivatorData>
        where TInstance : class, IDisposable
        where TPlaceholderFactory : PlaceholderFactory<TInstance>
    {
        public ContainerBuilder Builder { get; }

        public SubScopePlaceholderFactoryBuilder(ContainerBuilder builder)
        {
            Builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public IRegistrationBuilder<TPlaceholderFactory, SimpleActivatorData, SingleRegistrationStyle>
            ByFunction(Action<ContainerBuilder> subScopeInstaller)
        {
            return Builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterIFactoryExtended<TInstance>()
                                .FromSubScope()
                                .ByFunction(subScopeInstaller)
                                .SingleInstance();

                            subScopeBuilder
                                .RegisterType<TPlaceholderFactory>()
                                .SingleInstance()
                                .ExternallyOwned();
                        });

                    var placeholderFactory = subScope.Resolve<TPlaceholderFactory>();
                    var factory = subScope.Resolve<IFactory<TInstance>>();
                    placeholderFactory.Nested = factory;

                    subScope
                        .AddToHarmony(placeholderFactory);

                    return placeholderFactory;
                });
        }

        public IRegistrationBuilder<TPlaceholderFactory, SimpleActivatorData, SingleRegistrationStyle>
            ByInstaller<TInstaller>()
            where TInstaller : class, IInstaller
        {
            return Builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterIFactoryExtended<TInstance>()
                                .FromSubScope()
                                .ByInstaller<TInstaller>()
                                .SingleInstance();

                            subScopeBuilder
                                .RegisterType<TPlaceholderFactory>()
                                .SingleInstance()
                                .ExternallyOwned();
                        });

                    var placeholderFactory = subScope.Resolve<TPlaceholderFactory>();
                    var factory = subScope.Resolve<IFactory<TInstance>>();
                    placeholderFactory.Nested = factory;

                    subScope
                        .AddToHarmony(placeholderFactory);

                    return placeholderFactory;
                });
        }
    }

    public class SubScopePlaceholderFactoryBuilder<TP0, TInstance, TPlaceholderFactory>
        : ISubScopeFactoryBuilder<TP0, TInstance, TPlaceholderFactory, SimpleActivatorData>
        where TInstance : class, IDisposable
        where TPlaceholderFactory : PlaceholderFactory<TP0, TInstance>
    {
        public ContainerBuilder Builder { get; }

        public SubScopePlaceholderFactoryBuilder(ContainerBuilder builder)
        {
            Builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public IRegistrationBuilder<TPlaceholderFactory, SimpleActivatorData, SingleRegistrationStyle>
            ByFunction(Action<ContainerBuilder, TP0> subScopeInstaller)
        {
            return Builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterIFactoryExtended<TP0, TInstance>()
                                .FromSubScope()
                                .ByFunction(subScopeInstaller)
                                .SingleInstance();

                            subScopeBuilder
                                .RegisterType<TPlaceholderFactory>()
                                .SingleInstance()
                                .ExternallyOwned();
                        });

                    var placeholderFactory = subScope.Resolve<TPlaceholderFactory>();
                    var factory = subScope.Resolve<IFactory<TP0, TInstance>>();
                    placeholderFactory.Nested = factory;

                    subScope
                        .AddToHarmony(placeholderFactory);

                    return placeholderFactory;
                });
        }

        public IRegistrationBuilder<TPlaceholderFactory, SimpleActivatorData, SingleRegistrationStyle>
            ByInstaller<TInstaller>()
            where TInstaller : class, IInstaller
        {
            return Builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterIFactoryExtended<TP0, TInstance>()
                                .FromSubScope()
                                .ByInstaller<TInstaller>()
                                .SingleInstance();

                            subScopeBuilder
                                .RegisterType<TPlaceholderFactory>()
                                .SingleInstance()
                                .ExternallyOwned();
                        });

                    var placeholderFactory = subScope.Resolve<TPlaceholderFactory>();
                    var factory = subScope.Resolve<IFactory<TP0, TInstance>>();
                    placeholderFactory.Nested = factory;

                    subScope
                        .AddToHarmony(placeholderFactory);

                    return placeholderFactory;
                });
        }
    }

    public class SubScopePlaceholderFactoryBuilder<TP0, TP1, TInstance, TPlaceholderFactory>
        : ISubScopeFactoryBuilder<TP0, TP1, TInstance, TPlaceholderFactory, SimpleActivatorData>
        where TInstance : class, IDisposable
        where TPlaceholderFactory : PlaceholderFactory<TP0, TP1, TInstance>
    {
        public ContainerBuilder Builder { get; }

        public SubScopePlaceholderFactoryBuilder(ContainerBuilder builder)
        {
            Builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public IRegistrationBuilder<TPlaceholderFactory, SimpleActivatorData, SingleRegistrationStyle>
            ByFunction(Action<ContainerBuilder, TP0, TP1> subScopeInstaller)
        {
            return Builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterIFactoryExtended<TP0, TP1, TInstance>()
                                .FromSubScope()
                                .ByFunction(subScopeInstaller)
                                .SingleInstance();

                            subScopeBuilder
                                .RegisterType<TPlaceholderFactory>()
                                .SingleInstance()
                                .ExternallyOwned();
                        });

                    var placeholderFactory = subScope.Resolve<TPlaceholderFactory>();
                    var factory = subScope.Resolve<IFactory<TP0, TP1, TInstance>>();
                    placeholderFactory.Nested = factory;

                    subScope
                        .AddToHarmony(placeholderFactory);

                    return placeholderFactory;
                });
        }

        public IRegistrationBuilder<TPlaceholderFactory, SimpleActivatorData, SingleRegistrationStyle>
            ByInstaller<TInstaller>()
            where TInstaller : class, IInstaller
        {
            return Builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterIFactoryExtended<TP0, TP1, TInstance>()
                                .FromSubScope()
                                .ByInstaller<TInstaller>()
                                .SingleInstance();

                            subScopeBuilder
                                .RegisterType<TPlaceholderFactory>()
                                .SingleInstance()
                                .ExternallyOwned();
                        });

                    var placeholderFactory = subScope.Resolve<TPlaceholderFactory>();
                    var factory = subScope.Resolve<IFactory<TP0, TP1, TInstance>>();
                    placeholderFactory.Nested = factory;

                    subScope
                        .AddToHarmony(placeholderFactory);

                    return placeholderFactory;
                });
        }
    }

    public class SubScopePlaceholderFactoryBuilder<TP0, TP1, TP2, TInstance, TPlaceholderFactory>
        : ISubScopeFactoryBuilder<TP0, TP1, TP2, TInstance, TPlaceholderFactory, SimpleActivatorData>
        where TInstance : class, IDisposable
        where TPlaceholderFactory : PlaceholderFactory<TP0, TP1, TP2, TInstance>
    {
        public ContainerBuilder Builder { get; }

        public SubScopePlaceholderFactoryBuilder(ContainerBuilder builder)
        {
            Builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public IRegistrationBuilder<TPlaceholderFactory, SimpleActivatorData, SingleRegistrationStyle>
            ByFunction(Action<ContainerBuilder, TP0, TP1, TP2> subScopeInstaller)
        {
            return Builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterIFactoryExtended<TP0, TP1, TP2, TInstance>()
                                .FromSubScope()
                                .ByFunction(subScopeInstaller)
                                .SingleInstance();

                            subScopeBuilder
                                .RegisterType<TPlaceholderFactory>()
                                .SingleInstance()
                                .ExternallyOwned();
                        });

                    var placeholderFactory = subScope.Resolve<TPlaceholderFactory>();
                    var factory = subScope.Resolve<IFactory<TP0, TP1, TP2, TInstance>>();
                    placeholderFactory.Nested = factory;

                    subScope
                        .AddToHarmony(placeholderFactory);

                    return placeholderFactory;
                });
        }

        public IRegistrationBuilder<TPlaceholderFactory, SimpleActivatorData, SingleRegistrationStyle>
            ByInstaller<TInstaller>()
            where TInstaller : class, IInstaller
        {
            return Builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterIFactoryExtended<TP0, TP1, TP2, TInstance>()
                                .FromSubScope()
                                .ByInstaller<TInstaller>()
                                .SingleInstance();

                            subScopeBuilder
                                .RegisterType<TPlaceholderFactory>()
                                .SingleInstance()
                                .ExternallyOwned();
                        });

                    var placeholderFactory = subScope.Resolve<TPlaceholderFactory>();
                    var factory = subScope.Resolve<IFactory<TP0, TP1, TP2, TInstance>>();
                    placeholderFactory.Nested = factory;

                    subScope
                        .AddToHarmony(placeholderFactory);

                    return placeholderFactory;
                });
        }
    }

    public class SubScopePlaceholderFactoryBuilder<TP0, TP1, TP2, TP3, TInstance, TPlaceholderFactory>
        : ISubScopeFactoryBuilder<TP0, TP1, TP2, TP3, TInstance, TPlaceholderFactory, SimpleActivatorData>
        where TInstance : class, IDisposable
        where TPlaceholderFactory : PlaceholderFactory<TP0, TP1, TP2, TP3, TInstance>
    {
        public ContainerBuilder Builder { get; }

        public SubScopePlaceholderFactoryBuilder(ContainerBuilder builder)
        {
            Builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public IRegistrationBuilder<TPlaceholderFactory, SimpleActivatorData, SingleRegistrationStyle>
            ByFunction(Action<ContainerBuilder, TP0, TP1, TP2, TP3> subScopeInstaller)
        {
            return Builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterIFactoryExtended<TP0, TP1, TP2, TP3, TInstance>()
                                .FromSubScope()
                                .ByFunction(subScopeInstaller)
                                .SingleInstance();

                            subScopeBuilder
                                .RegisterType<TPlaceholderFactory>()
                                .SingleInstance()
                                .ExternallyOwned();
                        });

                    var placeholderFactory = subScope.Resolve<TPlaceholderFactory>();
                    var factory = subScope.Resolve<IFactory<TP0, TP1, TP2, TP3, TInstance>>();
                    placeholderFactory.Nested = factory;

                    subScope
                        .AddToHarmony(placeholderFactory);

                    return placeholderFactory;
                });
        }

        public IRegistrationBuilder<TPlaceholderFactory, SimpleActivatorData, SingleRegistrationStyle>
            ByInstaller<TInstaller>()
            where TInstaller : class, IInstaller
        {
            return Builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterIFactoryExtended<TP0, TP1, TP2, TP3, TInstance>()
                                .FromSubScope()
                                .ByInstaller<TInstaller>()
                                .SingleInstance();

                            subScopeBuilder
                                .RegisterType<TPlaceholderFactory>()
                                .SingleInstance()
                                .ExternallyOwned();
                        });

                    var placeholderFactory = subScope.Resolve<TPlaceholderFactory>();
                    var factory = subScope.Resolve<IFactory<TP0, TP1, TP2, TP3, TInstance>>();
                    placeholderFactory.Nested = factory;

                    subScope
                        .AddToHarmony(placeholderFactory);

                    return placeholderFactory;
                });
        }
    }

    public class SubScopePlaceholderFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TInstance, TPlaceholderFactory>
        : ISubScopeFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TInstance, TPlaceholderFactory, SimpleActivatorData>
        where TInstance : class, IDisposable
        where TPlaceholderFactory : PlaceholderFactory<TP0, TP1, TP2, TP3, TP4, TInstance>
    {
        public ContainerBuilder Builder { get; }

        public SubScopePlaceholderFactoryBuilder(ContainerBuilder builder)
        {
            Builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public IRegistrationBuilder<TPlaceholderFactory, SimpleActivatorData, SingleRegistrationStyle>
            ByFunction(Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4> subScopeInstaller)
        {
            return Builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterIFactoryExtended<TP0, TP1, TP2, TP3, TP4, TInstance>()
                                .FromSubScope()
                                .ByFunction(subScopeInstaller)
                                .SingleInstance();

                            subScopeBuilder
                                .RegisterType<TPlaceholderFactory>()
                                .SingleInstance()
                                .ExternallyOwned();
                        });

                    var placeholderFactory = subScope.Resolve<TPlaceholderFactory>();
                    var factory = subScope.Resolve<IFactory<TP0, TP1, TP2, TP3, TP4, TInstance>>();
                    placeholderFactory.Nested = factory;

                    subScope
                        .AddToHarmony(placeholderFactory);

                    return placeholderFactory;
                });
        }

        public IRegistrationBuilder<TPlaceholderFactory, SimpleActivatorData, SingleRegistrationStyle>
            ByInstaller<TInstaller>()
            where TInstaller : class, IInstaller
        {
            return Builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterIFactoryExtended<TP0, TP1, TP2, TP3, TP4, TInstance>()
                                .FromSubScope()
                                .ByInstaller<TInstaller>()
                                .SingleInstance();

                            subScopeBuilder
                                .RegisterType<TPlaceholderFactory>()
                                .SingleInstance()
                                .ExternallyOwned();
                        });

                    var placeholderFactory = subScope.Resolve<TPlaceholderFactory>();
                    var factory = subScope.Resolve<IFactory<TP0, TP1, TP2, TP3, TP4, TInstance>>();
                    placeholderFactory.Nested = factory;

                    subScope
                        .AddToHarmony(placeholderFactory);

                    return placeholderFactory;
                });
        }
    }

    public class SubScopePlaceholderFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TInstance, TPlaceholderFactory>
        : ISubScopeFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TInstance, TPlaceholderFactory, SimpleActivatorData>
        where TInstance : class, IDisposable
        where TPlaceholderFactory : PlaceholderFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>
    {
        public ContainerBuilder Builder { get; }

        public SubScopePlaceholderFactoryBuilder(ContainerBuilder builder)
        {
            Builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public IRegistrationBuilder<TPlaceholderFactory, SimpleActivatorData, SingleRegistrationStyle>
            ByFunction(Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5> subScopeInstaller)
        {
            return Builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterIFactoryExtended<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>()
                                .FromSubScope()
                                .ByFunction(subScopeInstaller)
                                .SingleInstance();

                            subScopeBuilder
                                .RegisterType<TPlaceholderFactory>()
                                .SingleInstance()
                                .ExternallyOwned();
                        });

                    var placeholderFactory = subScope.Resolve<TPlaceholderFactory>();
                    var factory = subScope.Resolve<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>>();
                    placeholderFactory.Nested = factory;

                    subScope
                        .AddToHarmony(placeholderFactory);

                    return placeholderFactory;
                });
        }

        public IRegistrationBuilder<TPlaceholderFactory, SimpleActivatorData, SingleRegistrationStyle>
            ByInstaller<TInstaller>()
            where TInstaller : class, IInstaller
        {
            return Builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterIFactoryExtended<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>()
                                .FromSubScope()
                                .ByInstaller<TInstaller>()
                                .SingleInstance();

                            subScopeBuilder
                                .RegisterType<TPlaceholderFactory>()
                                .SingleInstance()
                                .ExternallyOwned();
                        });

                    var placeholderFactory = subScope.Resolve<TPlaceholderFactory>();
                    var factory = subScope.Resolve<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>>();
                    placeholderFactory.Nested = factory;

                    subScope
                        .AddToHarmony(placeholderFactory);

                    return placeholderFactory;
                });
        }
    }

    public class SubScopePlaceholderFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance, TPlaceholderFactory>
        : ISubScopeFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance, TPlaceholderFactory, SimpleActivatorData>
        where TInstance : class, IDisposable
        where TPlaceholderFactory : PlaceholderFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>
    {
        public ContainerBuilder Builder { get; }

        public SubScopePlaceholderFactoryBuilder(ContainerBuilder builder)
        {
            Builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public IRegistrationBuilder<TPlaceholderFactory, SimpleActivatorData, SingleRegistrationStyle>
            ByFunction(Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6> subScopeInstaller)
        {
            return Builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterIFactoryExtended<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>()
                                .FromSubScope()
                                .ByFunction(subScopeInstaller)
                                .SingleInstance();

                            subScopeBuilder
                                .RegisterType<TPlaceholderFactory>()
                                .SingleInstance()
                                .ExternallyOwned();
                        });

                    var placeholderFactory = subScope.Resolve<TPlaceholderFactory>();
                    var factory = subScope.Resolve<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>>();
                    placeholderFactory.Nested = factory;

                    subScope
                        .AddToHarmony(placeholderFactory);

                    return placeholderFactory;
                });
        }

        public IRegistrationBuilder<TPlaceholderFactory, SimpleActivatorData, SingleRegistrationStyle>
            ByInstaller<TInstaller>()
            where TInstaller : class, IInstaller
        {
            return Builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterIFactoryExtended<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>()
                                .FromSubScope()
                                .ByInstaller<TInstaller>()
                                .SingleInstance();

                            subScopeBuilder
                                .RegisterType<TPlaceholderFactory>()
                                .SingleInstance()
                                .ExternallyOwned();
                        });

                    var placeholderFactory = subScope.Resolve<TPlaceholderFactory>();
                    var factory = subScope.Resolve<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>>();
                    placeholderFactory.Nested = factory;

                    subScope
                        .AddToHarmony(placeholderFactory);

                    return placeholderFactory;
                });
        }
    }

    public class SubScopePlaceholderFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance, TPlaceholderFactory>
        : ISubScopeFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance, TPlaceholderFactory, SimpleActivatorData>
        where TInstance : class, IDisposable
        where TPlaceholderFactory : PlaceholderFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>
    {
        public ContainerBuilder Builder { get; }

        public SubScopePlaceholderFactoryBuilder(ContainerBuilder builder)
        {
            Builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public IRegistrationBuilder<TPlaceholderFactory, SimpleActivatorData, SingleRegistrationStyle>
            ByFunction(Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7> subScopeInstaller)
        {
            return Builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterIFactoryExtended<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>()
                                .FromSubScope()
                                .ByFunction(subScopeInstaller)
                                .SingleInstance();

                            subScopeBuilder
                                .RegisterType<TPlaceholderFactory>()
                                .SingleInstance()
                                .ExternallyOwned();
                        });

                    var placeholderFactory = subScope.Resolve<TPlaceholderFactory>();
                    var factory = subScope.Resolve<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>>();
                    placeholderFactory.Nested = factory;

                    subScope
                        .AddToHarmony(placeholderFactory);

                    return placeholderFactory;
                });
        }

        public IRegistrationBuilder<TPlaceholderFactory, SimpleActivatorData, SingleRegistrationStyle>
            ByInstaller<TInstaller>()
            where TInstaller : class, IInstaller
        {
            return Builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterIFactoryExtended<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>()
                                .FromSubScope()
                                .ByInstaller<TInstaller>()
                                .SingleInstance();

                            subScopeBuilder
                                .RegisterType<TPlaceholderFactory>()
                                .SingleInstance()
                                .ExternallyOwned();
                        });

                    var placeholderFactory = subScope.Resolve<TPlaceholderFactory>();
                    var factory = subScope.Resolve<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>>();
                    placeholderFactory.Nested = factory;

                    subScope
                        .AddToHarmony(placeholderFactory);

                    return placeholderFactory;
                });
        }
    }

    public class SubScopePlaceholderFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance, TPlaceholderFactory>
        : ISubScopeFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance, TPlaceholderFactory, SimpleActivatorData>
        where TInstance : class, IDisposable
        where TPlaceholderFactory : PlaceholderFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>
    {
        public ContainerBuilder Builder { get; }

        public SubScopePlaceholderFactoryBuilder(ContainerBuilder builder)
        {
            Builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public IRegistrationBuilder<TPlaceholderFactory, SimpleActivatorData, SingleRegistrationStyle>
            ByFunction(Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8> subScopeInstaller)
        {
            return Builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterIFactoryExtended<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>()
                                .FromSubScope()
                                .ByFunction(subScopeInstaller)
                                .SingleInstance();

                            subScopeBuilder
                                .RegisterType<TPlaceholderFactory>()
                                .SingleInstance()
                                .ExternallyOwned();
                        });

                    var placeholderFactory = subScope.Resolve<TPlaceholderFactory>();
                    var factory = subScope.Resolve<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>>();
                    placeholderFactory.Nested = factory;

                    subScope
                        .AddToHarmony(placeholderFactory);

                    return placeholderFactory;
                });
        }

        public IRegistrationBuilder<TPlaceholderFactory, SimpleActivatorData, SingleRegistrationStyle>
            ByInstaller<TInstaller>()
            where TInstaller : class, IInstaller
        {
            return Builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterIFactoryExtended<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>()
                                .FromSubScope()
                                .ByInstaller<TInstaller>()
                                .SingleInstance();

                            subScopeBuilder
                                .RegisterType<TPlaceholderFactory>()
                                .SingleInstance()
                                .ExternallyOwned();
                        });

                    var placeholderFactory = subScope.Resolve<TPlaceholderFactory>();
                    var factory = subScope.Resolve<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>>();
                    placeholderFactory.Nested = factory;

                    subScope
                        .AddToHarmony(placeholderFactory);

                    return placeholderFactory;
                });
        }
    }

    public class SubScopePlaceholderFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance, TPlaceholderFactory>
        : ISubScopeFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance, TPlaceholderFactory, SimpleActivatorData>
        where TInstance : class, IDisposable
        where TPlaceholderFactory : PlaceholderFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>
    {
        public ContainerBuilder Builder { get; }

        public SubScopePlaceholderFactoryBuilder(ContainerBuilder builder)
        {
            Builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public IRegistrationBuilder<TPlaceholderFactory, SimpleActivatorData, SingleRegistrationStyle>
            ByFunction(Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9> subScopeInstaller)
        {
            return Builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterIFactoryExtended<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>()
                                .FromSubScope()
                                .ByFunction(subScopeInstaller)
                                .SingleInstance();

                            subScopeBuilder
                                .RegisterType<TPlaceholderFactory>()
                                .SingleInstance()
                                .ExternallyOwned();
                        });

                    var placeholderFactory = subScope.Resolve<TPlaceholderFactory>();
                    var factory = subScope.Resolve<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>>();
                    placeholderFactory.Nested = factory;

                    subScope
                        .AddToHarmony(placeholderFactory);

                    return placeholderFactory;
                });
        }

        public IRegistrationBuilder<TPlaceholderFactory, SimpleActivatorData, SingleRegistrationStyle>
            ByInstaller<TInstaller>()
            where TInstaller : class, IInstaller
        {
            return Builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterIFactoryExtended<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>()
                                .FromSubScope()
                                .ByInstaller<TInstaller>()
                                .SingleInstance();

                            subScopeBuilder
                                .RegisterType<TPlaceholderFactory>()
                                .SingleInstance()
                                .ExternallyOwned();
                        });

                    var placeholderFactory = subScope.Resolve<TPlaceholderFactory>();
                    var factory = subScope.Resolve<IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>>();
                    placeholderFactory.Nested = factory;

                    subScope
                        .AddToHarmony(placeholderFactory);

                    return placeholderFactory;
                });
        }
    }

}