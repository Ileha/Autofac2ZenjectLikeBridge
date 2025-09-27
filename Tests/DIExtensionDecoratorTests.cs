using Autofac;
using NSubstitute;
using ZenAutofac;

namespace Tests;

public class DIExtensionDecoratorTests
{
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

        var mockSubContainerDisposable = Substitute.For<IDisposable>();
        var mockExternalDisposable = Substitute.For<IDisposable>();

        builder
            .RegisterInstance(externalInstance)
            .As<string>()
            .SingleInstance();

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
                        .RegisterInstance(subScopeInstance)
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
            var instance = container.Resolve<IService>();

            // Assert
            Assert.That(instance.GetData(), Is.EqualTo($"{nameof(SimpleService)}.{subScopeInstance}"));
        }

        mockSubContainerDisposable.Received(1).Dispose();
        mockExternalDisposable.Received(1).Dispose();
    }

    [Test]
    public void RegisterDecoratorExtended_FromSubScope_ByInstaller()
    {
        // Arrange
        var builder = new ContainerBuilder();

        var mockSubContainerDisposable = Substitute.For<IDisposable>();
        var mockExternalDisposable = Substitute.For<IDisposable>();
        var data = Guid.NewGuid();

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
            .ByModule(
                (scope, arg3) => scope
                    .CreateInstance<ServiceWithDependencyModule>(arg3, mockSubContainerDisposable, data));

        using (var container = builder.Build())
        {
            // Act
            var instance = container.Resolve<IService>();

            // Assert
            Assert.That(instance.GetData(), Is.EqualTo($"{nameof(SimpleService)}.{data:N}"));
        }


        mockSubContainerDisposable.Received(1).Dispose();
        mockExternalDisposable.Received(1).Dispose();
    }

    internal class ServiceWithDependencyModule : Module
    {
        private readonly Guid _data;
        private readonly IDisposable _containerDisposable;
        private readonly IService _service;

        public ServiceWithDependencyModule(
            Guid data,
            IDisposable containerDisposable,
            IService service)
        {
            _data = data;
            _containerDisposable = containerDisposable ?? throw new ArgumentNullException(nameof(containerDisposable));
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<ServiceDecoratorDisposable>()
                .WithParameters(TypedParameter.From(_service))
                .SingleInstance();

            builder
                .RegisterInstance(_data.ToString("N"))
                .As<string>()
                .SingleInstance();

            builder
                .RegisterInstance(_containerDisposable)
                .SingleInstance();
        }
    }

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
}