using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Autofac2ZenjectLikeBridge.Entities;
using HarmonyLib;
using JetBrains.Annotations;

namespace Autofac2ZenjectLikeBridge.Extensions.HarmonyPatcher
{
    public static class HarmonyPatch
    {
        private static readonly string PatchId = $"{nameof(Autofac2ZenjectLikeBridge)}.{nameof(HarmonyPatch)}";

        private static readonly ConditionalWeakTable<IDisposable, CompositeDisposable> DisposeData =
            new ConditionalWeakTable<IDisposable, CompositeDisposable>();

        private static readonly HashSet<Type> PatchedTypes = new HashSet<Type>();
        private static readonly object Locker = new object();
        private static readonly Harmony Harmony = new Harmony(PatchId);

        private static readonly HarmonyMethod PrefixMethod =
            new HarmonyMethod(typeof(HarmonyPatch).GetMethod(nameof(DisposePrefix)));

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
                    .Where(type => type.IsClass && !type.IsAbstract && !type.IsGenericTypeDefinition
                                   && typeof(IDisposable).IsAssignableFrom(type))
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
                    PatchMethodLockFree(method, PrefixMethod);
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

        public static void PatchMethod([CanBeNull] MethodBase method)
        {
            lock (Locker)
                PatchMethodLockFree(method, PrefixMethod);
        }

        private static void PatchMethodLockFree([CanBeNull] MethodBase method, HarmonyMethod prefix)
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

        public static T AddToHarmony<T>(this T disposable, IDisposable composite)
            where T : IDisposable
        {
            if (disposable == null)
                throw new ArgumentNullException(nameof(disposable));

            if (composite == null)
                throw new ArgumentNullException(nameof(composite));

            EnsurePatched(composite.GetType());

            if (!DisposeData.TryGetValue(composite, out var value))
            {
                value = new CompositeDisposable();
                DisposeData.Add(composite, value);
            }

            disposable
                .AddTo(value);

            return disposable;
        }

        // ReSharper disable once InconsistentNaming
        public static void DisposePrefix(IDisposable __instance)
        {
            if (!DisposeData.TryGetValue(__instance, out var info))
                return;

            info.Dispose();
        }
    }
}