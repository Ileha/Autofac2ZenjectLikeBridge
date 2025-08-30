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
    public void RegisterDecoratorFromFunction_WhenRegistered_AppliesDecorator()
    {
        // Arrange
        var builder = new ContainerBuilder();
        builder.RegisterType<SimpleService>().As<IService>();
        builder.RegisterDecoratorFromFunction<ServiceDecorator, IService>((_, baseService) =>
            new ServiceDecorator(baseService));
        using var container = builder.Build();

        // Act
        var instance = container.Resolve<IService>();

        // Assert
        Assert.IsInstanceOf<ServiceDecorator>(instance);
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
            .RegisterFromSubScope<ServiceWithDependencyDisposable>(
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
            .RegisterFromSubScope<ServiceWithDependencyDisposable>(
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
            .RegisterDecoratorFromSubScope<ServiceDecoratorDisposable, IService>(
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
            .RegisterDecoratorFromSubScope<ServiceDecoratorDisposable, IService>(
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
}

// Test Classes
public interface IService
{
    string GetData();
}

public class SimpleService : IService
{
    public string GetData() => nameof(SimpleService);
}

public class ServiceDecorator : IService
{
    public ServiceDecorator(IService baseService)
    {
        BaseService = baseService;
    }

    public IService BaseService { get; }

    public virtual string GetData() => $"{BaseService.GetData()}.{nameof(ServiceDecorator)}";
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

    public override string GetData() => $"{BaseService.GetData()}.{_dependency}";

    public void Dispose()
    {
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