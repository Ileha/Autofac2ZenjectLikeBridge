using System.Reflection;
using System.Runtime.CompilerServices;
using Autofac2ZenjectLikeBridge.Entities;
using HarmonyLib;

namespace Autofac2ZenjectLikeBridge.Extensions.HarmonyPatcher;

public static class HarmonyPatch
{
    private const string PatchId = $"{nameof(Autofac2ZenjectLikeBridge)}.{nameof(HarmonyPatch)}";
    private static readonly ConditionalWeakTable<IDisposable, CompositeDisposable> DisposeData = new();
    private static readonly HashSet<Type> PatchedTypes = new();
    private static readonly object Locker = new();
    private static readonly Harmony Harmony = new(PatchId);
    private static readonly HarmonyMethod PrefixMethod = new(typeof(HarmonyPatch).GetMethod(nameof(DisposePrefix)));

    public static void PatchNonLazy()
    {
        lock (Locker)
        {
            var methods2Patch = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly =>
                {
                    try
                    {
                        return assembly.GetTypes();
                    }
                    catch (ReflectionTypeLoadException)
                    {
                        return Type.EmptyTypes;
                    }
                })
                .Except(PatchedTypes)
                .Where(type => type is { IsClass: true, IsAbstract: false, IsGenericTypeDefinition: false }
                               && type.IsAssignableTo(typeof(IDisposable)))
                .Select(type =>
                {
                    var interfaceMap = type.GetInterfaceMap(typeof(IDisposable));
                    var disposeMethod = interfaceMap.TargetMethods.FirstOrDefault();

                    return disposeMethod;
                })
                .Where(method => method != null)
                .Distinct()
                .ToArray();

            foreach (var method in methods2Patch)
            {
                PatchMethodLockFree(method, PrefixMethod);
            }
        }
    }

    public static void EnsurePatched(Type type)
    {
        lock (Locker)
        {
            if (!type.IsClass || type.IsAbstract || PatchedTypes.Contains(type))
                return;

            var interfaceMap = type.GetInterfaceMap(typeof(IDisposable));
            var disposeMethod = interfaceMap.TargetMethods.FirstOrDefault();

            if (disposeMethod == null)
                throw new InvalidOperationException(
                    $"can't find {nameof(IDisposable)}.{nameof(IDisposable.Dispose)} method in {type}");

            PatchMethodLockFree(disposeMethod, PrefixMethod);
        }
    }

    public static void PatchMethod(MethodBase? method)
    {
        lock (Locker)
            PatchMethodLockFree(method, PrefixMethod);
    }

    private static void PatchMethodLockFree(MethodBase? method, HarmonyMethod prefix)
    {
        if (method == null)
            return;

        if (PatchedTypes.Contains(method.DeclaringType))
            return;

        var declaredMethod = method.GetDeclaredMember();

        if (PatchedTypes.Contains(declaredMethod.DeclaringType))
            return;

        Harmony.Patch(
            declaredMethod,
            prefix: prefix
        );

        PatchedTypes.Add(method.DeclaringType);
        PatchedTypes.Add(declaredMethod.DeclaringType);
    }

    public static T AddToHarmony<T>(this IDisposable disposable, T instance)
        where T : IDisposable
    {
        EnsurePatched(instance.GetType());

        if (!DisposeData.TryGetValue(instance, out var value))
        {
            value = new CompositeDisposable();
            DisposeData.Add(instance, value);
        }

        disposable
            .AddTo(value);

        return instance;
    }

    // ReSharper disable once InconsistentNaming
    public static void DisposePrefix(IDisposable __instance)
    {
        if (!DisposeData.TryGetValue(__instance, out var info))
            return;

        info.Dispose();
    }
}