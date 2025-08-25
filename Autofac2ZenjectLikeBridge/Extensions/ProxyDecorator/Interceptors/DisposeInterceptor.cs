using System.Reflection;
using Autofac2ZenjectLikeBridge.Entities;
using Autofac2ZenjectLikeBridge.Extensions.ProxyDecorator.API;

namespace Autofac2ZenjectLikeBridge.Extensions.ProxyDecorator.Interceptors;

public class DisposeInterceptor : BaseCompositeDisposable, IMethodInterceptor
{
    public object? Invoke(object target, MethodInfo method, object?[]? args, Func<object?> proceed)
    {
        if (method.Name != nameof(IDisposable.Dispose))
            return proceed();

        Dispose();

        var result = proceed();

        return result;
    }
}