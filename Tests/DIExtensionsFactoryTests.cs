using Autofac;
using Autofac2ZenjectLikeBridge;
using Autofac2ZenjectLikeBridge.Entities.Factories;
using Autofac2ZenjectLikeBridge.Interfaces;
using NSubstitute;

namespace Tests;

public class DIExtensionsFactoryTests
{
    private class Factory<TParam, T> : PlaceholderFactory<TParam, T>
    {
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

    public class ServiceWithDependencyAndParameterDisposable : ServiceWithDependencyDisposable
    {
        public ServiceWithDependencyAndParameterDisposable(SimpleService dependency, string data) : base(dependency)
        {
            Data = data;
        }

        public string Data { get; }
    }

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
}