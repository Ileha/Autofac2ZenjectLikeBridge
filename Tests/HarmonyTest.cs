using System.Runtime.CompilerServices;
using HarmonyLib;

namespace Tests;

public class HarmonyTest
{
    [Test]
    public void HarmonyTest_patch()
    {
        var harmony = new Harmony("example.dispose.patch");

        // Patch all IDisposable.Dispose methods
        harmony.Patch(
            typeof(Resource).GetMethod(nameof(Resource.Dispose)), // interface method!
            prefix: new HarmonyMethod(typeof(HarmonyTest).GetMethod(nameof(DisposePostfix)))
        );

        var res = new Resource();
        DisposeData.Add(res, new ExtraDisposeInfo());

        res.Dispose(); // Will now call postfix as well
    }

    // Weak table to hold per-instance metadata
    private static readonly ConditionalWeakTable<IDisposable, ExtraDisposeInfo> DisposeData = new();

    class ExtraDisposeInfo
    {
        public DateTime CreatedAt { get; } = DateTime.Now;
    }

    // Example class with Dispose
    class Resource : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("Original Dispose called.");
        }
    }

    public static void DisposePostfix(IDisposable __instance)
    {
        if (!DisposeData.TryGetValue(__instance, out var info))
            return;

        Console.WriteLine($"Extra dispose logic. Object created at {info.CreatedAt}");
    }
}