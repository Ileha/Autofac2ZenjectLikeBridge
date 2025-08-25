using System.Reflection;

namespace Autofac2ZenjectLikeBridge.Extensions.ProxyDecorator.API;

public interface IMethodInterceptor
{
    object? Invoke(object target, MethodInfo method, object?[]? args, Func<object?> proceed);
}