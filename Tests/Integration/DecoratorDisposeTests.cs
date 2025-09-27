using Autofac;
using NSubstitute;
using ZenAutofac;
using ZenAutofac.Interfaces;

namespace Tests.Integration;

[TestFixture]
public class DecoratorDisposeTests
{
    private const string RootContainerData = "root container";
    private const string SubContainerData = "sub container";
    private const string DecoratedDataFormat = "data decorated: #{0}#";

    [Test]
    public void DecoratorInSubContainerTest_WhenDIExtensions()
    {
        var builder = new ContainerBuilder();

        var decoratedOnceData = $"{SubContainerData}_1";

        builder
            .RegisterExtended<ISampleReturn>()
            .FromSubScope()
            .ByFunction(
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
            .RegisterIFactoryExtended<Guid, ISampleReturn>()
            .FromSubScope()
            .ByFunction((containerBuilder, guid) =>
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
    public void SameInterfacesInRootAndInSubContainerTest_WhenDIExtensions()
    {
        var builder = new ContainerBuilder();

        builder
            .RegisterType<SampleReturn>()
            .As<ISampleReturn>()
            .WithParameters(TypedParameter.From(RootContainerData))
            .SingleInstance();

        builder
            .RegisterIFactoryExtended<ISampleReturn>()
            .FromSubScope()
            .ByFunction(subContainer =>
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
    public void Dispose_WhenSubContainerDisposed_DisposeDecorator_WhenDIExtensions()
    {
        // Arrange
        var builder = new ContainerBuilder();

        var receiver = Substitute.For<IDisposeReceiver>();
        builder
            .RegisterInstance(receiver)
            .As<IDisposeReceiver>()
            .SingleInstance();

        builder
            .RegisterExtended<SubContainerDataExtractor<ISample>>()
            .FromSubScope()
            .ByFunction(
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

    public class SubContainerDataExtractor<T> : IDisposable
    {
        public readonly T Data;

        public SubContainerDataExtractor(T data)
        {
            Data = data;
        }

        public void Dispose()
        {
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