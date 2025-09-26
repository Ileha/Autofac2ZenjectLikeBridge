using System;
using Autofac;
using Autofac.Builder;
using Autofac.Core;
using ZenAutofac.Entities.Factories;
using ZenAutofac.Extensions.HarmonyPatcher;
using ZenAutofac.Interfaces;
using ZenAutofac.Interfaces.Builders.Factory;

namespace ZenAutofac.Builders.Factory
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
            ByFunction(Action<ContainerBuilder> subScopeLoader)
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
                                .ByFunction(subScopeLoader)
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
            ByModule<TModule>(
                Func<ILifetimeScope, TModule> moduleFactory = null)
            where TModule : class, IModule
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
                                .ByModule(moduleFactory)
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
            ByFunction(Action<ContainerBuilder, TP0> subScopeLoader)
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
                                .ByFunction(subScopeLoader)
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
            ByModule<TModule>(
                Func<ILifetimeScope, TP0, TModule> moduleFactory = null)
            where TModule : class, IModule
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
                                .ByModule(moduleFactory)
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
            ByFunction(Action<ContainerBuilder, TP0, TP1> subScopeLoader)
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
                                .ByFunction(subScopeLoader)
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
            ByModule<TModule>(
                Func<ILifetimeScope, TP0, TP1, TModule> moduleFactory = null)
            where TModule : class, IModule
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
                                .ByModule(moduleFactory)
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
            ByFunction(Action<ContainerBuilder, TP0, TP1, TP2> subScopeLoader)
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
                                .ByFunction(subScopeLoader)
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
            ByModule<TModule>(
                Func<ILifetimeScope, TP0, TP1, TP2, TModule> moduleFactory = null)
            where TModule : class, IModule
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
                                .ByModule(moduleFactory)
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
            ByFunction(Action<ContainerBuilder, TP0, TP1, TP2, TP3> subScopeLoader)
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
                                .ByFunction(subScopeLoader)
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
            ByModule<TModule>(
                Func<ILifetimeScope, TP0, TP1, TP2, TP3, TModule> moduleFactory = null)
            where TModule : class, IModule
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
                                .ByModule(moduleFactory)
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
            ByFunction(Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4> subScopeLoader)
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
                                .ByFunction(subScopeLoader)
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
            ByModule<TModule>(
                Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TModule> moduleFactory = null)
            where TModule : class, IModule
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
                                .ByModule(moduleFactory)
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
            ByFunction(Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5> subScopeLoader)
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
                                .ByFunction(subScopeLoader)
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
            ByModule<TModule>(
                Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TModule> moduleFactory = null)
            where TModule : class, IModule
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
                                .ByModule(moduleFactory)
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
            ByFunction(Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6> subScopeLoader)
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
                                .ByFunction(subScopeLoader)
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
            ByModule<TModule>(
                Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TModule> moduleFactory = null)
            where TModule : class, IModule
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
                                .ByModule(moduleFactory)
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
            ByFunction(Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7> subScopeLoader)
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
                                .ByFunction(subScopeLoader)
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
            ByModule<TModule>(
                Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TModule> moduleFactory = null)
            where TModule : class, IModule
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
                                .ByModule(moduleFactory)
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
            ByFunction(Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8> subScopeLoader)
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
                                .ByFunction(subScopeLoader)
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
            ByModule<TModule>(
                Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TModule> moduleFactory = null)
            where TModule : class, IModule
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
                                .ByModule(moduleFactory)
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
            ByFunction(Action<ContainerBuilder, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9> subScopeLoader)
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
                                .ByFunction(subScopeLoader)
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
            ByModule<TModule>(
                Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TModule> moduleFactory = null)
            where TModule : class, IModule
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
                                .ByModule(moduleFactory)
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