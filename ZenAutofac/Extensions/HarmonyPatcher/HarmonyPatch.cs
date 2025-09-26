using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using HarmonyLib;
using JetBrains.Annotations;
using ZenAutofac.Entities;

namespace ZenAutofac.Extensions.HarmonyPatcher
{
    public static class HarmonyPatch
    {
        private static readonly string PatchId = $"{nameof(ZenAutofac)}.{nameof(HarmonyPatch)}";

        private static readonly ConditionalWeakTable<IDisposable, CompositeDisposable> DisposeData =
            new ConditionalWeakTable<IDisposable, CompositeDisposable>();

        private static readonly HashSet<Type> PatchedTypes = new HashSet<Type>();
        private static readonly object PatchLocker = new object();
        private static readonly Harmony Harmony = new Harmony(PatchId);

        private static readonly HarmonyMethod PostfixMethod =
            new HarmonyMethod(typeof(HarmonyPatch).GetMethod(nameof(DisposePrefix)));

        public static void PatchNonLazy()
        {
            lock (PatchLocker)
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
                    PatchMethodLockFree(method, PostfixMethod);
            }
        }

        public static void EnsurePatched(Type type)
        {
            lock (PatchLocker)
            {
                if (!type.IsClass || type.IsAbstract || PatchedTypes.Contains(type))
                    return;

                var interfaceMap = type.GetInterfaceMap(typeof(IDisposable));
                var disposeMethod = interfaceMap.TargetMethods.FirstOrDefault();

                if (disposeMethod == null)
                    throw new InvalidOperationException(
                        $"can't find {nameof(IDisposable)}.{nameof(IDisposable.Dispose)} method in {type}");

                PatchMethodLockFree(disposeMethod, PostfixMethod);
            }
        }

        public static void PatchMethod([CanBeNull] MethodBase method)
        {
            lock (PatchLocker)
                PatchMethodLockFree(method, PostfixMethod);
        }

        private static void PatchMethodLockFree([CanBeNull] MethodBase method, HarmonyMethod postfix)
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
                postfix: postfix
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

            var value = DisposeData.GetOrCreateValue(composite);

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