using System;
using Autofac;
using Autofac.Builder;
using ZenAutofac.Entities.Factories;
using ZenAutofac.Extensions.HarmonyPatcher;
using ZenAutofac.Interfaces;
using ZenAutofac.Interfaces.Builders.Factory;

namespace ZenAutofac.Builders.Factory
{
    //generated amount 10

    public class ExtendedPlaceholderFactoryBuilder<TInstance, TPlaceholderFactory>
        : IExtendedFactoryBuilder<TInstance, TPlaceholderFactory, SimpleActivatorData>
        where TPlaceholderFactory : PlaceholderFactory<TInstance>
        where TInstance : class
    {
        public ContainerBuilder Builder { get; }

        public ExtendedPlaceholderFactoryBuilder(ContainerBuilder builder)
        {
            Builder = builder;
        }

        public IRegistrationBuilder<TPlaceholderFactory, SimpleActivatorData, SingleRegistrationStyle> FromNewInstance()
        {
            return Builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterIFactoryExtended<TInstance>()
                                .FromNewInstance()
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

        public IRegistrationBuilder<TPlaceholderFactory, SimpleActivatorData, SingleRegistrationStyle> FromFunction(Func<ILifetimeScope, TInstance> func)
        {
            return Builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterIFactoryExtended<TInstance>()
                                .FromFunction(func)
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

    public class ExtendedPlaceholderFactoryBuilder<TP0, TInstance, TPlaceholderFactory>
        : IExtendedFactoryBuilder<TP0, TInstance, TPlaceholderFactory, SimpleActivatorData>
        where TPlaceholderFactory : PlaceholderFactory<TP0, TInstance>
        where TInstance : class
    {
        public ContainerBuilder Builder { get; }

        public ExtendedPlaceholderFactoryBuilder(ContainerBuilder builder)
        {
            Builder = builder;
        }

        public IRegistrationBuilder<TPlaceholderFactory, SimpleActivatorData, SingleRegistrationStyle> FromNewInstance()
        {
            return Builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterIFactoryExtended<TP0, TInstance>()
                                .FromNewInstance()
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

        public IRegistrationBuilder<TPlaceholderFactory, SimpleActivatorData, SingleRegistrationStyle> FromFunction(Func<ILifetimeScope, TP0, TInstance> func)
        {
            return Builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterIFactoryExtended<TP0, TInstance>()
                                .FromFunction(func)
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

    public class ExtendedPlaceholderFactoryBuilder<TP0, TP1, TInstance, TPlaceholderFactory>
        : IExtendedFactoryBuilder<TP0, TP1, TInstance, TPlaceholderFactory, SimpleActivatorData>
        where TPlaceholderFactory : PlaceholderFactory<TP0, TP1, TInstance>
        where TInstance : class
    {
        public ContainerBuilder Builder { get; }

        public ExtendedPlaceholderFactoryBuilder(ContainerBuilder builder)
        {
            Builder = builder;
        }

        public IRegistrationBuilder<TPlaceholderFactory, SimpleActivatorData, SingleRegistrationStyle> FromNewInstance()
        {
            return Builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterIFactoryExtended<TP0, TP1, TInstance>()
                                .FromNewInstance()
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

        public IRegistrationBuilder<TPlaceholderFactory, SimpleActivatorData, SingleRegistrationStyle> FromFunction(Func<ILifetimeScope, TP0, TP1, TInstance> func)
        {
            return Builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterIFactoryExtended<TP0, TP1, TInstance>()
                                .FromFunction(func)
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

    public class ExtendedPlaceholderFactoryBuilder<TP0, TP1, TP2, TInstance, TPlaceholderFactory>
        : IExtendedFactoryBuilder<TP0, TP1, TP2, TInstance, TPlaceholderFactory, SimpleActivatorData>
        where TPlaceholderFactory : PlaceholderFactory<TP0, TP1, TP2, TInstance>
        where TInstance : class
    {
        public ContainerBuilder Builder { get; }

        public ExtendedPlaceholderFactoryBuilder(ContainerBuilder builder)
        {
            Builder = builder;
        }

        public IRegistrationBuilder<TPlaceholderFactory, SimpleActivatorData, SingleRegistrationStyle> FromNewInstance()
        {
            return Builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterIFactoryExtended<TP0, TP1, TP2, TInstance>()
                                .FromNewInstance()
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

        public IRegistrationBuilder<TPlaceholderFactory, SimpleActivatorData, SingleRegistrationStyle> FromFunction(Func<ILifetimeScope, TP0, TP1, TP2, TInstance> func)
        {
            return Builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterIFactoryExtended<TP0, TP1, TP2, TInstance>()
                                .FromFunction(func)
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

    public class ExtendedPlaceholderFactoryBuilder<TP0, TP1, TP2, TP3, TInstance, TPlaceholderFactory>
        : IExtendedFactoryBuilder<TP0, TP1, TP2, TP3, TInstance, TPlaceholderFactory, SimpleActivatorData>
        where TPlaceholderFactory : PlaceholderFactory<TP0, TP1, TP2, TP3, TInstance>
        where TInstance : class
    {
        public ContainerBuilder Builder { get; }

        public ExtendedPlaceholderFactoryBuilder(ContainerBuilder builder)
        {
            Builder = builder;
        }

        public IRegistrationBuilder<TPlaceholderFactory, SimpleActivatorData, SingleRegistrationStyle> FromNewInstance()
        {
            return Builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterIFactoryExtended<TP0, TP1, TP2, TP3, TInstance>()
                                .FromNewInstance()
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

        public IRegistrationBuilder<TPlaceholderFactory, SimpleActivatorData, SingleRegistrationStyle> FromFunction(Func<ILifetimeScope, TP0, TP1, TP2, TP3, TInstance> func)
        {
            return Builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterIFactoryExtended<TP0, TP1, TP2, TP3, TInstance>()
                                .FromFunction(func)
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

    public class ExtendedPlaceholderFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TInstance, TPlaceholderFactory>
        : IExtendedFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TInstance, TPlaceholderFactory, SimpleActivatorData>
        where TPlaceholderFactory : PlaceholderFactory<TP0, TP1, TP2, TP3, TP4, TInstance>
        where TInstance : class
    {
        public ContainerBuilder Builder { get; }

        public ExtendedPlaceholderFactoryBuilder(ContainerBuilder builder)
        {
            Builder = builder;
        }

        public IRegistrationBuilder<TPlaceholderFactory, SimpleActivatorData, SingleRegistrationStyle> FromNewInstance()
        {
            return Builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterIFactoryExtended<TP0, TP1, TP2, TP3, TP4, TInstance>()
                                .FromNewInstance()
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

        public IRegistrationBuilder<TPlaceholderFactory, SimpleActivatorData, SingleRegistrationStyle> FromFunction(Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TInstance> func)
        {
            return Builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterIFactoryExtended<TP0, TP1, TP2, TP3, TP4, TInstance>()
                                .FromFunction(func)
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

    public class ExtendedPlaceholderFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TInstance, TPlaceholderFactory>
        : IExtendedFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TInstance, TPlaceholderFactory, SimpleActivatorData>
        where TPlaceholderFactory : PlaceholderFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>
        where TInstance : class
    {
        public ContainerBuilder Builder { get; }

        public ExtendedPlaceholderFactoryBuilder(ContainerBuilder builder)
        {
            Builder = builder;
        }

        public IRegistrationBuilder<TPlaceholderFactory, SimpleActivatorData, SingleRegistrationStyle> FromNewInstance()
        {
            return Builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterIFactoryExtended<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>()
                                .FromNewInstance()
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

        public IRegistrationBuilder<TPlaceholderFactory, SimpleActivatorData, SingleRegistrationStyle> FromFunction(Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TInstance> func)
        {
            return Builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterIFactoryExtended<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>()
                                .FromFunction(func)
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

    public class ExtendedPlaceholderFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance, TPlaceholderFactory>
        : IExtendedFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance, TPlaceholderFactory, SimpleActivatorData>
        where TPlaceholderFactory : PlaceholderFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>
        where TInstance : class
    {
        public ContainerBuilder Builder { get; }

        public ExtendedPlaceholderFactoryBuilder(ContainerBuilder builder)
        {
            Builder = builder;
        }

        public IRegistrationBuilder<TPlaceholderFactory, SimpleActivatorData, SingleRegistrationStyle> FromNewInstance()
        {
            return Builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterIFactoryExtended<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>()
                                .FromNewInstance()
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

        public IRegistrationBuilder<TPlaceholderFactory, SimpleActivatorData, SingleRegistrationStyle> FromFunction(Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance> func)
        {
            return Builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterIFactoryExtended<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>()
                                .FromFunction(func)
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

    public class ExtendedPlaceholderFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance, TPlaceholderFactory>
        : IExtendedFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance, TPlaceholderFactory, SimpleActivatorData>
        where TPlaceholderFactory : PlaceholderFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>
        where TInstance : class
    {
        public ContainerBuilder Builder { get; }

        public ExtendedPlaceholderFactoryBuilder(ContainerBuilder builder)
        {
            Builder = builder;
        }

        public IRegistrationBuilder<TPlaceholderFactory, SimpleActivatorData, SingleRegistrationStyle> FromNewInstance()
        {
            return Builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterIFactoryExtended<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>()
                                .FromNewInstance()
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

        public IRegistrationBuilder<TPlaceholderFactory, SimpleActivatorData, SingleRegistrationStyle> FromFunction(Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance> func)
        {
            return Builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterIFactoryExtended<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>()
                                .FromFunction(func)
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

    public class ExtendedPlaceholderFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance, TPlaceholderFactory>
        : IExtendedFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance, TPlaceholderFactory, SimpleActivatorData>
        where TPlaceholderFactory : PlaceholderFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>
        where TInstance : class
    {
        public ContainerBuilder Builder { get; }

        public ExtendedPlaceholderFactoryBuilder(ContainerBuilder builder)
        {
            Builder = builder;
        }

        public IRegistrationBuilder<TPlaceholderFactory, SimpleActivatorData, SingleRegistrationStyle> FromNewInstance()
        {
            return Builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterIFactoryExtended<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>()
                                .FromNewInstance()
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

        public IRegistrationBuilder<TPlaceholderFactory, SimpleActivatorData, SingleRegistrationStyle> FromFunction(Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance> func)
        {
            return Builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterIFactoryExtended<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>()
                                .FromFunction(func)
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

    public class ExtendedPlaceholderFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance, TPlaceholderFactory>
        : IExtendedFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance, TPlaceholderFactory, SimpleActivatorData>
        where TPlaceholderFactory : PlaceholderFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>
        where TInstance : class
    {
        public ContainerBuilder Builder { get; }

        public ExtendedPlaceholderFactoryBuilder(ContainerBuilder builder)
        {
            Builder = builder;
        }

        public IRegistrationBuilder<TPlaceholderFactory, SimpleActivatorData, SingleRegistrationStyle> FromNewInstance()
        {
            return Builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterIFactoryExtended<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>()
                                .FromNewInstance()
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

        public IRegistrationBuilder<TPlaceholderFactory, SimpleActivatorData, SingleRegistrationStyle> FromFunction(Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance> func)
        {
            return Builder
                .Register((IComponentContext _, ILifetimeScope scope) =>
                {
                    var subScope = scope
                        .BeginLifetimeScope(subScopeBuilder =>
                        {
                            subScopeBuilder
                                .RegisterIFactoryExtended<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>()
                                .FromFunction(func)
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