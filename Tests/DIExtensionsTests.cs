using Autofac;
using Autofac2ZenjectLikeBridge;
using Autofac2ZenjectLikeBridge.Entities.Factories;
using Autofac2ZenjectLikeBridge.Interfaces;
using NSubstitute;

namespace Tests;

[TestFixture]
public class DIExtensionsTests
{
    private class Factory<T> : PlaceholderFactory<T>
    {
    }

    private class Factory<TParam, T> : PlaceholderFactory<TParam, T>
    {
    }

    [Test]
    public void WithParameters_WhenCalled_PassesParametersToRegistration()
    {
        // Arrange
        var builder = new ContainerBuilder();
        const string expectedParameter = "test_parameter";
        builder.RegisterType<ServiceWithParameter>()
            .WithParameters(new NamedParameter("data", expectedParameter));

        using var container = builder.Build();

        // Act
        var instance = container.Resolve<ServiceWithParameter>();

        // Assert
        Assert.That(instance.Data, Is.EqualTo(expectedParameter));
    }

    [Test]
    public void CreateInstance_ForServiceProvider_CreatesInstanceCorrectly()
    {
        // Arrange
        var builder = new ContainerBuilder();
        builder
            .RegisterType<SimpleService>()
            .SingleInstance();

        using var container = builder.Build();
        var serviceProvider = container.AsServiceProvider();

        // Act
        var instance = serviceProvider.CreateInstance<ServiceWithDependency>();

        // Assert
        Assert.IsNotNull(instance);
        Assert.IsNotNull(instance.Dependency);
        Assert.That(instance.Dependency, Is.EqualTo(container.Resolve<SimpleService>()));
    }

    [Test]
    public void CreateInstance_ForComponentContext_CreatesInstanceCorrectly()
    {
        // Arrange
        var builder = new ContainerBuilder();
        builder
            .RegisterType<SimpleService>()
            .SingleInstance();

        using var container = builder.Build();

        // Act
        var instance = container.CreateInstance<ServiceWithDependency>();

        // Assert
        Assert.IsNotNull(instance);
        Assert.IsNotNull(instance.Dependency);
        Assert.That(instance.Dependency, Is.EqualTo(container.Resolve<SimpleService>()));
    }

    [Test]
    public void AsServiceProvider_WhenCalled_ResolvesServices()
    {
        // Arrange
        var builder = new ContainerBuilder();
        builder.RegisterType<SimpleService>().As<IService>();
        using var container = builder.Build();
        var serviceProvider = container.AsServiceProvider();

        // Act
        var service = serviceProvider.GetService(typeof(IService));

        // Assert
        Assert.IsNotNull(service);
        Assert.IsInstanceOf<SimpleService>(service);
    }

    #region RegisterExtended

    [Test]
    public void RegisterFromSubScope_GotDependencyFromSubScope()
    {
        // Arrange
        var builder = new ContainerBuilder();

        var externalInstance = new SimpleService();
        var subScopeInstance = new SimpleService();

        builder
            .RegisterInstance(externalInstance)
            .As<SimpleService>()
            .SingleInstance();

        builder
            .RegisterExtended<ServiceWithDependencyDisposable>()
            .FromSubScope()
            .ByFunction(
                subContainerBuilder =>
                {
                    subContainerBuilder
                        .RegisterType<ServiceWithDependencyDisposable>()
                        .SingleInstance();

                    subContainerBuilder
                        .RegisterInstance(subScopeInstance)
                        .As<SimpleService>()
                        .SingleInstance();
                })
            .SingleInstance();

        using var container = builder.Build();

        // Act
        var instance = container.Resolve<ServiceWithDependencyDisposable>();

        // Assert
        Assert.That(instance.Dependency, Is.EqualTo(subScopeInstance));
    }

    [Test]
    public void RegisterFromSubScope_SubContainerDisposedWithInstance()
    {
        // Arrange
        var builder = new ContainerBuilder();

        var mockSubContainerDisposable = Substitute.For<IDisposable>();
        var mockExternalDisposable = Substitute.For<IDisposable>();

        builder
            .RegisterInstance(mockExternalDisposable)
            .As<IDisposable>()
            .SingleInstance();

        builder
            .RegisterExtended<ServiceWithDependencyDisposable>()
            .FromSubScope()
            .ByFunction(
                subContainerBuilder =>
                {
                    subContainerBuilder
                        .RegisterType<ServiceWithDependencyDisposable>()
                        .SingleInstance();

                    subContainerBuilder
                        .RegisterType<SimpleService>()
                        .SingleInstance();

                    subContainerBuilder
                        .RegisterInstance(mockSubContainerDisposable)
                        .As<IDisposable>()
                        .SingleInstance();
                })
            .SingleInstance()
            .ExternallyOwned();

        using var container = builder.Build();

        // Act
        using (var _ = container.Resolve<ServiceWithDependencyDisposable>())
        {
        }

        // Assert
        mockSubContainerDisposable.Received(1).Dispose();
        mockExternalDisposable.Received(0).Dispose();
    }

    internal class ServiceWithDependencyInstaller : AutofacInstallerBase
    {
        internal static SimpleService Service = null!;

        public ServiceWithDependencyInstaller(ContainerBuilder builder)
            : base(builder)
        {
        }

        public override void Install()
        {
            Builder
                .RegisterType<ServiceWithDependencyDisposable>()
                .SingleInstance();

            Builder
                .RegisterInstance(Service)
                .As<SimpleService>()
                .SingleInstance();
        }
    }

    [Test]
    public void Register_FromSubScope_ByInstaller()
    {
        // Arrange
        var builder = new ContainerBuilder();

        var externalInstance = new SimpleService();
        ServiceWithDependencyInstaller.Service = new SimpleService();

        builder
            .RegisterInstance(externalInstance)
            .As<SimpleService>()
            .SingleInstance();

        builder
            .RegisterExtended<ServiceWithDependencyDisposable>()
            .FromSubScope()
            .ByInstaller<ServiceWithDependencyInstaller>()
            .SingleInstance();

        using var container = builder.Build();

        // Act
        var instance = container.Resolve<ServiceWithDependencyDisposable>();

        // Assert
        Assert.That(instance.Dependency, Is.EqualTo(ServiceWithDependencyInstaller.Service));
    }

    internal class ServiceWithDependencyInstallerWithExternalDependencies : AutofacInstallerBase
    {
        private readonly SimpleService _service;

        public ServiceWithDependencyInstallerWithExternalDependencies(
            SimpleService service,
            ContainerBuilder builder)
            : base(builder)
        {
            _service = service;
        }

        public override void Install()
        {
            Builder
                .RegisterType<ServiceWithDependencyDisposable>()
                .SingleInstance();

            Builder
                .RegisterInstance(_service)
                .As<SimpleService>()
                .SingleInstance();
        }
    }

    [Test]
    public void Register_FromSubScope_ByInstaller_WhenExternalDependencies()
    {
        // Arrange
        var builder = new ContainerBuilder();

        var externalInstance = new SimpleService();

        builder
            .RegisterInstance(externalInstance)
            .As<SimpleService>()
            .SingleInstance();

        builder
            .RegisterExtended<ServiceWithDependencyDisposable>()
            .FromSubScope()
            .ByInstaller<ServiceWithDependencyInstallerWithExternalDependencies>()
            .SingleInstance();

        using var container = builder.Build();

        // Act
        var instance = container.Resolve<ServiceWithDependencyDisposable>();

        // Assert
        Assert.That(instance.Dependency, Is.EqualTo(externalInstance));
    }

    #endregion

    #region RegisterDecoratorExtended

    [Test]
    public void RegisterDecoratorFromFunction_WhenRegistered_AppliesDecorator()
    {
        // Arrange
        var builder = new ContainerBuilder();
        builder.RegisterType<SimpleService>().As<IService>();

        builder
            .RegisterDecoratorExtended<ServiceDecorator, IService>()
            .FromFunction((_, baseService) => new ServiceDecorator(baseService));

        using var container = builder.Build();

        // Act
        var instance = container.Resolve<IService>();

        // Assert
        Assert.IsInstanceOf<ServiceDecorator>(instance);
    }

    [Test]
    public void RegisterDecoratorFromSubScope_GotDependencyFromSubScope()
    {
        // Arrange
        var builder = new ContainerBuilder();

        var externalInstance = Guid.NewGuid().ToString("N");
        var subScopeInstance = Guid.NewGuid().ToString("N");

        builder
            .RegisterInstance(externalInstance)
            .As<string>()
            .SingleInstance();

        builder
            .RegisterType<SimpleService>()
            .As<IService>()
            .SingleInstance();

        builder
            .RegisterDecoratorExtended<ServiceDecoratorDisposable, IService>()
            .FromSubScope()
            .ByFunction(
                (subContainerBuilder, service) =>
                {
                    subContainerBuilder
                        .RegisterType<ServiceDecoratorDisposable>()
                        .WithParameters(TypedParameter.From(service))
                        .SingleInstance();

                    subContainerBuilder
                        .RegisterInstance(subScopeInstance)
                        .As<string>()
                        .SingleInstance();
                });

        using var container = builder.Build();

        // Act
        var instance = container.Resolve<IService>();

        // Assert
        Assert.That(instance.GetData(), Is.EqualTo($"{nameof(SimpleService)}.{subScopeInstance}"));
    }

    [Test]
    public void RegisterDecoratorFromSubScope_SubContainerDisposedWithInstance()
    {
        // Arrange
        var builder = new ContainerBuilder();

        var mockSubContainerDisposable = Substitute.For<IDisposable>();
        var mockExternalDisposable = Substitute.For<IDisposable>();

        builder
            .RegisterType<SimpleService>()
            .As<IService>()
            .SingleInstance();

        builder
            .RegisterInstance(mockExternalDisposable)
            .As<IDisposable>()
            .SingleInstance();

        builder
            .RegisterDecoratorExtended<ServiceDecoratorDisposable, IService>()
            .FromSubScope()
            .ByFunction(
                (subContainerBuilder, service) =>
                {
                    subContainerBuilder
                        .RegisterType<ServiceDecoratorDisposable>()
                        .WithParameters(TypedParameter.From(service))
                        .SingleInstance();

                    subContainerBuilder
                        .RegisterInstance(Guid.NewGuid().ToString("N"))
                        .As<string>()
                        .SingleInstance();

                    subContainerBuilder
                        .RegisterInstance(mockSubContainerDisposable)
                        .As<IDisposable>()
                        .SingleInstance();
                });

        using (var container = builder.Build())
        {
            // Act
            var _ = container.Resolve<IService>();
        }

        // Assert
        mockSubContainerDisposable.Received(1).Dispose();
        mockExternalDisposable.Received(1).Dispose();
    }

    #endregion

    #region Factories

    #region IFactories

    [Test]
    public void RegisterFactory_WhenCalled_ResolvesInstanceWithParameter()
    {
        // Arrange
        var builder = new ContainerBuilder();
        const string expectedParameter = "test_parameter";

        builder
            .RegisterIFactoryExtended<string, ServiceWithParameter>()
            .FromNewInstance()
            .SingleInstance();

        using var container = builder.Build();
        var factory = container.Resolve<IFactory<string, ServiceWithParameter>>();

        // Act
        var instance = factory.Create(expectedParameter);

        // Assert
        Assert.That(instance.Data, Is.EqualTo(expectedParameter));
    }

    [Test]
    public void RegisterFactoryFromFunction_WhenCalled_ResolvesInstanceWithParameter()
    {
        // Arrange
        var builder = new ContainerBuilder();
        const string expectedParameter = "test_parameter";

        builder
            .RegisterIFactoryExtended<string, ServiceWithParameter>()
            .FromFunction((_, param) => new ServiceWithParameter(param))
            .SingleInstance();

        using var container = builder.Build();
        var factory = container.Resolve<IFactory<string, ServiceWithParameter>>();

        // Act
        var instance = factory.Create(expectedParameter);

        // Assert
        Assert.That(instance.Data, Is.EqualTo(expectedParameter));
    }

    [Test]
    public void RegisterFactoryFromSubScope_WhenCalled_ResolvesInstanceWithParameterAndDependency()
    {
        // Arrange
        var builder = new ContainerBuilder();
        const string expectedParameter = "test_parameter";

        builder
            .RegisterIFactoryExtended<string, ServiceWithDependencyAndParameterDisposable>()
            .FromSubScope()
            .ByFunction((subContainer, param) =>
            {
                subContainer.RegisterType<SimpleService>().AsSelf();
                subContainer.RegisterType<ServiceWithDependencyAndParameterDisposable>()
                    .WithParameter(new NamedParameter("data", param));
            })
            .SingleInstance();

        using var container = builder.Build();
        var factory = container.Resolve<IFactory<string, ServiceWithDependencyAndParameterDisposable>>();

        // Act
        var instance = factory.Create(expectedParameter);

        // Assert
        Assert.That(instance.Data, Is.EqualTo(expectedParameter));
        Assert.IsNotNull(instance.Dependency);
    }

    [Test]
    public void RegisterFactoryFromSubScope_WhenInstanceDisposed_SubScopeIsDisposed()
    {
        // Arrange
        var builder = new ContainerBuilder();
        var disposable = Substitute.For<IDisposable>();

        builder
            .RegisterIFactoryExtended<string, ServiceWithDependencyAndParameterDisposable>()
            .FromSubScope()
            .ByFunction((subContainer, param) =>
            {
                subContainer.RegisterInstance(disposable);
                subContainer.RegisterType<SimpleService>().AsSelf();
                subContainer.RegisterType<ServiceWithDependencyAndParameterDisposable>()
                    .WithParameter(new NamedParameter("data", param));
            })
            .SingleInstance();

        using var container = builder.Build();
        var factory = container.Resolve<IFactory<string, ServiceWithDependencyAndParameterDisposable>>();

        // Act
        using (factory.Create("test"))
        {
        }

        // Assert
        disposable.Received(1).Dispose();
    }

    #endregion

    #region PlaceholderFactories

    [Test]
    public void RegisterPlaceholderFactory_WhenCalled_ResolvesInstanceWithParameter()
    {
        // Arrange
        var builder = new ContainerBuilder();
        const string expectedParameter = "test_parameter";

        builder
            .RegisterPlaceholderFactoryExtended<string, ServiceWithParameter, Factory<string, ServiceWithParameter>>()
            .FromNewInstance()
            .SingleInstance();

        using var container = builder.Build();
        var factory = container.Resolve<Factory<string, ServiceWithParameter>>();

        // Act
        var instance = factory.Create(expectedParameter);

        // Assert
        Assert.That(instance.Data, Is.EqualTo(expectedParameter));
    }

    [Test]
    public void RegisterFactoryFromFunction_WhenCalledPlaceholder_ResolvesInstanceWithParameter()
    {
        // Arrange
        var builder = new ContainerBuilder();
        const string expectedParameter = "test_parameter";

        builder
            .RegisterPlaceholderFactoryExtended<string, ServiceWithParameter, Factory<string, ServiceWithParameter>>()
            .FromFunction((_, param) => new ServiceWithParameter(param))
            .SingleInstance();

        using var container = builder.Build();
        var factory = container.Resolve<Factory<string, ServiceWithParameter>>();

        // Act
        var instance = factory.Create(expectedParameter);

        // Assert
        Assert.That(instance.Data, Is.EqualTo(expectedParameter));
    }

    [Test]
    public void RegisterFactoryFromSubScope_WhenCalledPlaceholder_ResolvesInstanceWithParameterAndDependency()
    {
        // Arrange
        var builder = new ContainerBuilder();
        const string expectedParameter = "test_parameter";

        builder
            .RegisterPlaceholderFactoryExtended<
                string, ServiceWithDependencyAndParameterDisposable,
                Factory<string, ServiceWithDependencyAndParameterDisposable>>()
            .FromSubScope()
            .ByFunction((subContainer, param) =>
            {
                subContainer.RegisterType<SimpleService>().AsSelf();
                subContainer.RegisterType<ServiceWithDependencyAndParameterDisposable>()
                    .WithParameter(new NamedParameter("data", param));
            })
            .SingleInstance();

        using var container = builder.Build();
        var factory = container.Resolve<Factory<string, ServiceWithDependencyAndParameterDisposable>>();

        // Act
        var instance = factory.Create(expectedParameter);

        // Assert
        Assert.That(instance.Data, Is.EqualTo(expectedParameter));
        Assert.IsNotNull(instance.Dependency);
    }

    [Test]
    public void RegisterFactoryFromSubScope_WhenInstanceDisposedPlaceholder_SubScopeIsDisposed()
    {
        // Arrange
        var builder = new ContainerBuilder();
        var disposable = Substitute.For<IDisposable>();

        builder
            .RegisterPlaceholderFactoryExtended<
                string, ServiceWithDependencyAndParameterDisposable,
                Factory<string, ServiceWithDependencyAndParameterDisposable>>()
            .FromSubScope()
            .ByFunction((subContainer, param) =>
            {
                subContainer.RegisterInstance(disposable);
                subContainer.RegisterType<SimpleService>().AsSelf();
                subContainer.RegisterType<ServiceWithDependencyAndParameterDisposable>()
                    .WithParameter(new NamedParameter("data", param));
            })
            .SingleInstance();

        using var container = builder.Build();
        var factory = container.Resolve<Factory<string, ServiceWithDependencyAndParameterDisposable>>();

        // Act
        using (factory.Create("test"))
        {
        }

        // Assert
        disposable.Received(1).Dispose();
    }

    #endregion

    #endregion

    // Test Classes
    public interface IService
    {
        string GetData();
    }

    public class SimpleService : IService
    {
        public string GetData()
        {
            return nameof(SimpleService);
        }
    }

    public class ServiceDecorator : IService
    {
        public ServiceDecorator(IService baseService)
        {
            BaseService = baseService;
        }

        public IService BaseService { get; }

        public virtual string GetData()
        {
            return $"{BaseService.GetData()}.{nameof(ServiceDecorator)}";
        }
    }

    public class ServiceDecoratorDisposable : ServiceDecorator, IDisposable
    {
        private readonly string _dependency;

        public ServiceDecoratorDisposable(
            string dependency,
            IService baseService) : base(baseService)
        {
            _dependency = dependency;
        }

        public void Dispose()
        {
        }

        public override string GetData()
        {
            return $"{BaseService.GetData()}.{_dependency}";
        }
    }

    public class ServiceWithParameter
    {
        public ServiceWithParameter(string data)
        {
            Data = data;
        }

        public string Data { get; }
    }

    public class ServiceWithDependency
    {
        public ServiceWithDependency(SimpleService dependency)
        {
            Dependency = dependency;
        }

        public SimpleService Dependency { get; }
    }

    public class ServiceWithDependencyDisposable : ServiceWithDependency, IDisposable
    {
        public ServiceWithDependencyDisposable(SimpleService dependency)
            : base(dependency)
        {
        }

        public void Dispose()
        {
        }
    }

    public class ServiceWithDependencyAndParameterDisposable : ServiceWithDependencyDisposable
    {
        public ServiceWithDependencyAndParameterDisposable(SimpleService dependency, string data) : base(dependency)
        {
            Data = data;
        }

        public string Data { get; }
    }
}