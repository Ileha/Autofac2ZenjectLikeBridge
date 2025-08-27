using System.Reflection;
using Autofac2ZenjectLikeBridge.Extensions.ProxyDecorator.API;
using Castle.DynamicProxy;

namespace Autofac2ZenjectLikeBridge.Extensions.ProxyDecorator;

public class DispatchProxyDecorator<TDecorated> where TDecorated : class
{
    private static readonly ProxyGenerator Generator = new();
    private static readonly HashSet<Type> CheckedTypes = new();
    private static readonly HashSet<string> IgnoredObjectMethods = [nameof(GetType)];

    public static TDecorated Create(TDecorated decorated, IMethodInterceptor interceptor)
    {
        ArgumentNullException.ThrowIfNull(decorated);
        ArgumentNullException.ThrowIfNull(interceptor);

        // Choose between class proxy or interface proxy
        if (typeof(TDecorated).IsInterface)
        {
            return (TDecorated)Generator.CreateInterfaceProxyWithTarget(
                typeof(TDecorated),
                decorated,
                new CastleInterceptor(interceptor));
        }
        else
        {
            EnsureVirtuals<TDecorated>();

            return Generator.CreateClassProxyWithTarget(
                decorated,
                new CastleInterceptor(interceptor));
        }
    }

    public static TDecorated Create(
        TDecorated decorated,
        Func<object, MethodInfo, object?[]?, Func<object?>, object?> interceptor)
    {
        return Create(decorated, new FuncInterceptor(interceptor));
    }

    internal static void EnsureVirtuals<T>()
    {
        var type = typeof(T);

        if (CheckedTypes.Contains(type))
            return;

        var nonVirtuals = type
            .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
            .Where(m =>
                !IgnoredObjectMethods.Contains(m.Name) &&
                (m.IsPublic || m.IsAssembly || m.IsFamilyOrAssembly))
            .Where(m => !m.IsVirtual || m.IsFinal)
            .ToList();

        if (nonVirtuals.Count > 0)
            throw new InvalidOperationException(
                $"Type {type.Name} has non-virtual methods that cannot be intercepted: " +
                string.Join(", ", nonVirtuals.Select(m => m.Name)));

        CheckedTypes.Add(type);
    }

    private class CastleInterceptor : IInterceptor
    {
        private readonly IMethodInterceptor _interceptor;

        public CastleInterceptor(IMethodInterceptor interceptor) => _interceptor = interceptor;

        public void Intercept(IInvocation invocation)
        {
            object? ResultProvider()
            {
                invocation.Proceed();
                return invocation.ReturnValue;
            }

            invocation.ReturnValue = _interceptor.Invoke(
                invocation.InvocationTarget,
                invocation.Method,
                invocation.Arguments,
                ResultProvider);
        }
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