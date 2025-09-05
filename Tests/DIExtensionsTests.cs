using Autofac;
using Autofac2ZenjectLikeBridge;
using NSubstitute;

namespace Tests;

[TestFixture]
public class DIExtensionsTests
{
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
        private readonly SimpleService _service;

        public ServiceWithDependencyInstaller(ContainerBuilder builder, SimpleService service)
            : base(builder)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
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
    public void Register_FromSubScope_ByInstaller()
    {
        // Arrange
        var builder = new ContainerBuilder();

        var externalInstance = new SimpleService();
        var internalService = new SimpleService();

        builder
            .RegisterInstance(externalInstance)
            .As<SimpleService>()
            .SingleInstance();

        builder
            .RegisterExtended<ServiceWithDependencyDisposable>()
            .FromSubScope()
            .ByInstaller<ServiceWithDependencyInstaller>((scope, subScopeBuilder)
                => scope.CreateInstance<ServiceWithDependencyInstaller>(subScopeBuilder, internalService))
            .SingleInstance();

        using var container = builder.Build();

        // Act
        var instance = container.Resolve<ServiceWithDependencyDisposable>();

        // Assert
        Assert.That(instance.Dependency, Is.EqualTo(internalService));
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
            .ByInstaller<ServiceWithDependencyInstaller>()
            .SingleInstance();

        using var container = builder.Build();

        // Act
        var instance = container.Resolve<ServiceWithDependencyDisposable>();

        // Assert
        Assert.That(instance.Dependency, Is.EqualTo(externalInstance));
    }

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
}