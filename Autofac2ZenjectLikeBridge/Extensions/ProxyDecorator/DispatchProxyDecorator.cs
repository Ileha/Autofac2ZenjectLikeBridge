using System.Reflection;
using Autofac2ZenjectLikeBridge.Extensions.ProxyDecorator.API;

namespace Autofac2ZenjectLikeBridge.Extensions.ProxyDecorator;

internal class DispatchProxyDecorator<TDecorated> : DispatchProxy
{
    private TDecorated? _decorated;
    private IMethodInterceptor? _interceptor;

    public static TDecorated Create(TDecorated decorated, IMethodInterceptor interceptor)
    {
        var proxy = Create<TDecorated, DispatchProxyDecorator<TDecorated>>();

        if (proxy is not DispatchProxyDecorator<TDecorated> typedProxy)
            throw new InvalidOperationException("Proxy creation failed");

        typedProxy._decorated = decorated ?? throw new ArgumentNullException(nameof(decorated));
        typedProxy._interceptor = interceptor ?? throw new ArgumentNullException(nameof(interceptor));

        return (TDecorated) proxy;
    }

    public static TDecorated Create(TDecorated decorated,
        Func<object, MethodInfo, object?[]?, Func<object?>, object?> interceptor)
    {
        var interceptorEntity = new FuncInterceptor(interceptor);

        return Create(decorated, interceptorEntity);
    }

    protected override object? Invoke(MethodInfo? targetMethod, object?[]? args)
    {
        if (_decorated == null || targetMethod == null)
            throw new NullReferenceException("Decorated object or target method is null");

        return _interceptor?.Invoke(
            _decorated,
            targetMethod,
            args,
            () => targetMethod.Invoke(_decorated, args)
        ) ?? targetMethod.Invoke(_decorated, args);
    }

    private class FuncInterceptor : IMethodInterceptor
    {
        private readonly Func<object, MethodInfo, object?[]?, Func<object?>, object?> _interceptor;

        public FuncInterceptor(Func<object, MethodInfo, object?[]?, Func<object?>, object?> interceptor)
        {
            _interceptor = interceptor;
        }

        public object? Invoke(object target, MethodInfo method, object?[]? args, Func<object?> proceed)
        {
            return _interceptor(target, method, args, proceed);
        }
    }
}