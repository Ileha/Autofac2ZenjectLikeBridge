using System.Reflection;
using Autofac2ZenjectLikeBridge.Extensions.ProxyDecorator;
using Autofac2ZenjectLikeBridge.Extensions.ProxyDecorator.API;

namespace Tests.Tools.ProxyDecorator;

[TestFixture]
public class DispatchProxyDecoratorTests
{
    private interface ITestService : IDisposable
    {
        int Add(int a, int b);
        string Echo(string s);
    }

    private class TestService : ITestService
    {
        public bool Disposed { get; private set; }

        public int Add(int a, int b)
        {
            return a + b;
        }

        public string Echo(string s)
        {
            return $"[{s}]";
        }

        public void Dispose()
        {
            Disposed = true;
        }
    }

    private class CapturingInterceptor : IMethodInterceptor
    {
        public object? LastTarget { get; private set; }
        public MethodInfo? LastMethod { get; private set; }
        public object?[]? LastArgs { get; private set; }
        public bool ProceedCalled { get; private set; }
        public Func<object?>? LastProceed { get; private set; }
        public Func<object?>? ProceedOverride { get; }
        public Func<object?, object?>? ReturnTransform { get; set; }

        public object? Invoke(object target, MethodInfo method, object?[]? args, Func<object?> proceed)
        {
            LastTarget = target;
            LastMethod = method;
            LastArgs = args;
            LastProceed = proceed;

            var toCall = ProceedOverride ?? proceed;
            var result = toCall();
            ProceedCalled = true;
            return ReturnTransform != null ? ReturnTransform(result) : result;
        }
    }

    [Test]
    public void Invoke_CallsInterceptor_WithCorrectParameters_AndProceeds()
    {
        // Arrange
        ITestService service = new TestService();
        var interceptor = new CapturingInterceptor();
        var proxy = DispatchProxyDecorator<ITestService>.Create(service, interceptor);

        // Act
        var sum = proxy.Add(2, 3);

        // Assert
        Assert.That(sum, Is.EqualTo(5));
        Assert.That(interceptor.LastTarget, Is.SameAs(service));
        Assert.That(interceptor.LastMethod, Is.Not.Null);
        Assert.That(interceptor.LastMethod!.Name, Is.EqualTo(nameof(ITestService.Add)));
        Assert.That(interceptor.LastArgs, Is.Not.Null);
        Assert.That(interceptor.LastArgs!.Length, Is.EqualTo(2));
        Assert.That(interceptor.ProceedCalled, Is.True);
    }

    [Test]
    public void Invoke_ReturnsValue_FromInterceptor_WhenOverridden()
    {
        // Arrange
        ITestService service = new TestService();
        var interceptor = new CapturingInterceptor
        {
            ReturnTransform = _ => 42 // force result
        };
        var proxy = DispatchProxyDecorator<ITestService>.Create(service, interceptor);

        // Act
        var sum = proxy.Add(1, 1);

        // Assert
        Assert.That(sum, Is.EqualTo(42));
    }

    [Test]
    public void Create_Throws_WhenArgumentsNull()
    {
        // Arrange
        ITestService service = new TestService();
        var interceptor = new CapturingInterceptor();

        // Act + Assert
        Assert.Throws<ArgumentNullException>(() =>
            DispatchProxyDecorator<ITestService>.Create(service, default(IMethodInterceptor)));
        Assert.Throws<ArgumentNullException>(() => DispatchProxyDecorator<ITestService>.Create(null, interceptor));
    }

    // [Test]
    // public void DisposeInterceptor_Invoked_OnDispose_ExecutesRegistrations_BeforeUnderlyingDispose()
    // {
    //     // Arrange
    //     var service = new TestService();
    //     var disposeInterceptor = new DisposeInterceptor();
    //
    //     var cleanupCalled = false;
    //     // Register cleanup into interceptor; it should be called when Dispose is intercepted
    //     Disposable
    //         .Create(() => cleanupCalled = true)
    //         .AddTo(disposeInterceptor);
    //
    //     var proxy = DispatchProxyDecorator<ITestService>.Create(service, disposeInterceptor);
    //
    //     // Act
    //     proxy.Dispose();
    //
    //     // Assert
    //     Assert.That(cleanupCalled, Is.True, "DisposeInterceptor should trigger registered disposables");
    //     Assert.That(service.Disposed, Is.True, "Underlying service.Dispose should be called via proceed()");
    // }

    [Test]
    public void Invoke_Echo_Works_ThroughProxy()
    {
        // Arrange
        ITestService service = new TestService();
        var interceptor = new CapturingInterceptor();
        var proxy = DispatchProxyDecorator<ITestService>.Create(service, interceptor);

        // Act
        var res = proxy.Echo("abc");

        // Assert
        Assert.That(res, Is.EqualTo("[abc]"));
        Assert.That(interceptor.LastMethod!.Name, Is.EqualTo(nameof(ITestService.Echo)));
    }
}