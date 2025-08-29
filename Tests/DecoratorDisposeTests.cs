using Autofac;
using Autofac2ZenjectLikeBridge;
using Autofac2ZenjectLikeBridge.Entities;
using Autofac2ZenjectLikeBridge.Extensions.HarmonyPatcher;
using Autofac2ZenjectLikeBridge.Interfaces;
using NSubstitute;

namespace Tests;

[TestFixture]
public class DecoratorDisposeTests
{
    private const string RootContainerData = "root container";
    private const string SubContainerData = "sub container";
    private const string DecoratedDataFormat = "data decorated: #{0}#";

    [Test]
    public void DecoratorInSubContainerTest_WhenDIExtensions()
    {
        HarmonyPatch.PatchNonLazy();

        var builder = new ContainerBuilder();

        var decoratedOnceData = $"{SubContainerData}_1";

        builder
            .RegisterFromSubScope<ISampleReturn>(
                containerBuilder =>
                {
                    containerBuilder
                        .RegisterType<SampleReturn>()
                        .WithParameters(TypedParameter.From(decoratedOnceData))
                        .As<ISampleReturn>()
                        .SingleInstance();

                    containerBuilder
                        .RegisterDecorator<SampleReturnDecorator, ISampleReturn>();
                })
            .SingleInstance();

        builder
            .RegisterFactoryFromSubScope<Guid, ISampleReturn>(
                (containerBuilder, guid) =>
                {
                    containerBuilder
                        .RegisterType<SampleReturn>()
                        .WithParameters(TypedParameter.From($"{SubContainerData}_{guid:N}"))
                        .As<ISampleReturn>()
                        .SingleInstance();

                    containerBuilder
                        .RegisterDecorator<SampleReturnDecorator, ISampleReturn>();

                    containerBuilder
                        .RegisterDecorator<SampleReturnDecorator, ISampleReturn>();
                })
            .SingleInstance();

        using (var container = builder.Build())
        {
            var onceDecorated = container.Resolve<ISampleReturn>().GetData();
            Console.WriteLine(onceDecorated);
            Assert.That(onceDecorated, Is.EqualTo(string.Format(DecoratedDataFormat, decoratedOnceData)));

            var guid = Guid.NewGuid();

            var decoratedTwiceData = $"{SubContainerData}_{guid:N}";

            Console.WriteLine($"Resolved guid: {guid:N}");
            var twiceDecorated = container.Resolve<IFactory<Guid, ISampleReturn>>().Create(guid).GetData();
            Console.WriteLine(twiceDecorated);

            Assert.That(twiceDecorated,
                Is.EqualTo(string.Format(DecoratedDataFormat, string.Format(DecoratedDataFormat, decoratedTwiceData))));
        }
    }

    [Test]
    public void DecoratorInSubContainerTest()
    {
        // Arrange
        var builder = new ContainerBuilder();

        builder
            .RegisterInstance(Substitute.For<IDisposeReceiver>())
            .As<IDisposeReceiver>()
            .SingleInstance();

        var iSampleRootLowLevel = Guid.NewGuid();

        builder.RegisterType<LowLevel>()
            .Keyed<ISample>(iSampleRootLowLevel)
            .SingleInstance();

        builder.RegisterDecorator<ISample>(
            (context, sample) => context.CreateInstance<Decorator>(sample), fromKey: iSampleRootLowLevel, toKey: null);

        using (var container = builder.Build())
        {
            using (var scope = container.BeginLifetimeScope(subContainer =>
                   {
                       subContainer.RegisterType<LowLevelWithData>()
                           .As<ISample>()
                           .WithParameters(TypedParameter.From(SubContainerData))
                           .SingleInstance();
                   }))
            {
                var service = scope.Resolve<ISample>();
                service.DoWork();
            }

            var rootService = container.Resolve<ISample>();
            rootService.DoWork();
        }
    }

    [Test]
    public void SameInterfacesInRootAndInSubContainerTest_WhenDIExtensions()
    {
        HarmonyPatch.PatchNonLazy();
        var builder = new ContainerBuilder();

        builder
            .RegisterType<SampleReturn>()
            .As<ISampleReturn>()
            .WithParameters(TypedParameter.From(RootContainerData))
            .SingleInstance();

        builder
            .RegisterFactoryFromSubScope<ISampleReturn>(subContainer =>
            {
                subContainer
                    .RegisterType<SampleReturn>()
                    .As<ISampleReturn>()
                    .WithParameters(TypedParameter.From(SubContainerData))
                    .SingleInstance();
            })
            .SingleInstance();

        using (var rootContainer = builder.Build())
        {
            var sampleReturn = rootContainer.Resolve<ISampleReturn>();

            Console.WriteLine(sampleReturn.GetData());
            Assert.That(sampleReturn.GetData(), Is.EqualTo(RootContainerData));

            using var subContainerService = rootContainer.Resolve<IFactory<ISampleReturn>>().Create();

            Console.WriteLine(subContainerService.GetData());
            Assert.That(subContainerService.GetData(), Is.EqualTo(SubContainerData));
        }
    }

    [Test]
    public void SameInterfacesInRootAndInSubContainerTest()
    {
        var builder = new ContainerBuilder();

        builder
            .RegisterType<SampleReturn>()
            .As<ISampleReturn>()
            .WithParameters(TypedParameter.From(RootContainerData))
            .SingleInstance();

        using (var rootContainer = builder.Build())
        {
            var sampleReturn = rootContainer.Resolve<ISampleReturn>();

            Console.WriteLine(sampleReturn.GetData());
            Assert.That(sampleReturn.GetData(), Is.EqualTo(RootContainerData));

            using (var scope = rootContainer.BeginLifetimeScope(subContainer =>
                   {
                       subContainer
                           .RegisterType<SampleReturn>()
                           .As<ISampleReturn>()
                           .WithParameters(TypedParameter.From(SubContainerData))
                           .SingleInstance();
                   }))
            {
                var subContainerService = scope.Resolve<ISampleReturn>();

                Console.WriteLine(subContainerService.GetData());
                Assert.That(subContainerService.GetData(), Is.EqualTo(SubContainerData));
            }
        }
    }

    [Test]
    public void Dispose_When2DecoratorsInChildSubScopes()
    {
        // Arrange
        var builder = new ContainerBuilder();

        var receiver = Substitute.For<IDisposeReceiver>();
        builder
            .RegisterInstance(receiver)
            .As<IDisposeReceiver>()
            .SingleInstance();

        builder
            .RegisterType<LowLevel>()
            .As<ISample>()
            .SingleInstance();

        using (var container = builder.Build())
        {
            // Act
            using (var scope = container.BeginLifetimeScope(subContainer =>
                   {
                       subContainer.RegisterDecorator<Decorator, ISample>();
                   }))
            using (var scope2 = scope.BeginLifetimeScope(subContainer =>
                   {
                       subContainer.RegisterDecorator<Decorator, ISample>();
                   }))
            {
                var service = scope2.Resolve<ISample>();
                service.DoWork();
            }

            // Assert
            receiver.Received(0).ReceiveDispose();
        }

        receiver.Received(2).ReceiveDispose();
    }

    [Test]
    public void Dispose_When2DecoratorsInDifferentSubScopes()
    {
        // Arrange
        var builder = new ContainerBuilder();

        var receiver = Substitute.For<IDisposeReceiver>();
        builder
            .RegisterInstance(receiver)
            .As<IDisposeReceiver>()
            .SingleInstance();

        builder
            .RegisterType<LowLevel>()
            .As<ISample>()
            .SingleInstance();

        using (var container = builder.Build())
        {
            // Act
            using (var scope = container.BeginLifetimeScope(subContainer =>
                   {
                       subContainer.RegisterDecorator<Decorator, ISample>();
                   }))
            {
                var service = scope.Resolve<ISample>();
                service.DoWork();
            }

            using (var scope = container.BeginLifetimeScope(subContainer =>
                   {
                       subContainer.RegisterDecorator<Decorator, ISample>();
                   }))
            {
                var service = scope.Resolve<ISample>();
                service.DoWork();
            }

            // Assert
            receiver.Received(0).ReceiveDispose();
        }

        receiver.Received(2).ReceiveDispose();
    }

    [Test]
    public void Dispose_WhenContainerDisposed_DisposeDecorator()
    {
        // Arrange
        var builder = new ContainerBuilder();

        var receiver = Substitute.For<IDisposeReceiver>();
        builder
            .RegisterInstance(receiver)
            .As<IDisposeReceiver>()
            .SingleInstance();

        builder
            .RegisterType<LowLevel>()
            .As<ISample>()
            .SingleInstance();

        using (var container = builder.Build())
        {
            // Act
            using (var scope = container.BeginLifetimeScope(subContainer =>
                   {
                       subContainer.RegisterDecorator<Decorator, ISample>();
                   }))
            {
                var service = scope.Resolve<ISample>();
                service.DoWork();
            }

            // Assert
            receiver.Received(0).ReceiveDispose();
        }

        receiver.Received(1).ReceiveDispose();
    }

    [Test]
    public void Dispose_WhenSubContainerDisposed_DisposeDecorator()
    {
        // Arrange
        var builder = new ContainerBuilder();

        var receiver = Substitute.For<IDisposeReceiver>();
        builder
            .RegisterInstance(receiver)
            .As<IDisposeReceiver>()
            .SingleInstance();

        using var container = builder.Build();
        // Act
        using (var scope = container.BeginLifetimeScope(subContainer =>
               {
                   subContainer.RegisterType<LowLevel>()
                       .As<ISample>()
                       .SingleInstance();

                   subContainer.RegisterDecorator<Decorator, ISample>();
               }))
        {
            var service = scope.Resolve<ISample>();
            service.DoWork();
        }

        // Assert
        receiver.Received(1).ReceiveDispose();
    }

    [Test]
    public void Dispose_WhenSubContainerDisposed_DisposeDecorator_WhenDIExtensions()
    {
        HarmonyPatch.PatchNonLazy();

        // Arrange
        var builder = new ContainerBuilder();

        var receiver = Substitute.For<IDisposeReceiver>();
        builder
            .RegisterInstance(receiver)
            .As<IDisposeReceiver>()
            .SingleInstance();

        builder
            .RegisterFromSubScope<SubContainerDataExtractor<ISample>>(
                containerBuilder =>
                {
                    containerBuilder.RegisterType<LowLevel>()
                        .As<ISample>()
                        .SingleInstance();

                    containerBuilder.RegisterDecorator<Decorator, ISample>();

                    containerBuilder
                        .RegisterType<SubContainerDataExtractor<ISample>>()
                        .SingleInstance();
                });

        using var container = builder.Build();

        // Act
        var disposable = container.Resolve<SubContainerDataExtractor<ISample>>();
        disposable.Data.DoWork();
        disposable.Dispose();

        // Assert
        receiver.Received(1).ReceiveDispose();
    }

    public class SubContainerDataExtractor<T> : BaseCompositeDisposable
    {
        public readonly T Data;

        public SubContainerDataExtractor(T data)
        {
            Data = data;
        }
    }

    public interface ISampleReturn : IDisposable
    {
        string GetData();
    }

    public class SampleReturn : ISampleReturn
    {
        private readonly string _data;

        public SampleReturn(string data)
        {
            _data = data;
        }

        public string GetData()
        {
            return _data;
        }

        public void Dispose()
        {

        }
    }

    public class SampleReturnDecorator : ISampleReturn
    {
        private readonly ISampleReturn _baseService;

        public SampleReturnDecorator(ISampleReturn baseService)
        {
            _baseService = baseService ?? throw new ArgumentNullException(nameof(baseService));
        }

        public string GetData()
        {
            return string.Format(DecoratedDataFormat, _baseService.GetData());
        }

        public void Dispose()
        {
            _baseService.Dispose();
        }
    }

    public interface IDisposeReceiver
    {
        void ReceiveDispose();
    }

    public interface ISample
    {
        void DoWork();
    }

    public class LowLevelWithData : ISample
    {
        private readonly string _data;

        public LowLevelWithData(string data)
        {
            _data = data;
        }

        public void DoWork()
        {
            Console.WriteLine($"Doing work: {_data} {nameof(LowLevelWithData)}");
        }
    }

    public class LowLevel : ISample
    {
        public void DoWork()
        {
            Console.WriteLine($"Doing work: {nameof(LowLevel)}");
        }
    }

    public class Decorator : ISample, IDisposable
    {
        private readonly IDisposeReceiver _disposeReceiver;
        private readonly ISample _sample;

        public Decorator(
            IDisposeReceiver disposeReceiver,
            ISample sample)
        {
            _disposeReceiver = disposeReceiver ?? throw new ArgumentNullException(nameof(disposeReceiver));
            _sample = sample ?? throw new ArgumentNullException(nameof(sample));
        }

        public virtual void Dispose()
        {
            Console.WriteLine("dispose");
            _disposeReceiver.ReceiveDispose();
        }

        public void DoWork()
        {
            _sample.DoWork();
            Console.WriteLine($"Doing work: {nameof(Decorator)}");
        }
    }
}