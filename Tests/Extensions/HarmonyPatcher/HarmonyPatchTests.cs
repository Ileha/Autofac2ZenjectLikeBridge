using System.Reflection;
using Autofac2ZenjectLikeBridge.Extensions.HarmonyPatcher;
using NSubstitute;

namespace Tests.Extensions.HarmonyPatcher;

[TestFixture]
public class HarmonyPatchTests
{
    [TearDown]
    public void TearDown()
    {
        // Reset patched types to ensure test isolation
        var patchedTypesField = typeof(HarmonyPatch).GetField("PatchedTypes", BindingFlags.NonPublic | BindingFlags.Static);

        if (patchedTypesField != null)
        {
            var patchedTypes = patchedTypesField.GetValue(null) as HashSet<Type>;
            patchedTypes?.Clear();
        }
    }

    [Test]
    public void PatchNonLazy_WhenCalled_PatchesConcreteDisposableTypes()
    {
        // Arrange
        HarmonyPatch.PatchNonLazy();
        var instance = new SimpleDisposable();
        var mockDisposable = Substitute.For<IDisposable>();

        // Act
        mockDisposable.AddToHarmony(instance);
        instance.Dispose();

        // Assert
        mockDisposable.Received(1).Dispose();
    }

    [Test]
    public void AddToHarmony_WhenTypeNotPatched_PatchesOnTheFly()
    {
        // Arrange
        var instance = new DynamicDisposable();
        var mockDisposable = Substitute.For<IDisposable>();

        // Act
        mockDisposable.AddToHarmony(instance);
        instance.Dispose();

        // Assert
        mockDisposable.Received(1).Dispose();
    }

    [Test]
    public void AddToHarmony_WhenGenericTypeNotPatched_PatchesOnTheFly()
    {
        // Arrange
        var instance = new GenericDisposable<int>();
        var mockDisposable = Substitute.For<IDisposable>();

        // Act
        mockDisposable.AddToHarmony(instance);
        instance.Dispose();

        // Assert
        mockDisposable.Received(1).Dispose();
    }

    [Test]
    public void EnsurePatched_WithInterface_DoesNotThrow()
    {
        // Assert
        Assert.DoesNotThrow(() => HarmonyPatch.EnsurePatched(typeof(IDisposable)));
    }

    [Test]
    public void EnsurePatched_WithAbstractClass_DoesNotThrow()
    {
        // Assert
        Assert.DoesNotThrow(() => HarmonyPatch.EnsurePatched(typeof(AbstractDisposable)));
    }
}

// Test Classes
public class SimpleDisposable : IDisposable
{
    public void Dispose() { /* Patched by Harmony */ }
}

public class DynamicDisposable : IDisposable
{
    public void Dispose() { /* Patched by Harmony */ }
}

public class GenericDisposable<T> : IDisposable
{
    public void Dispose() { /* Patched by Harmony */ }
}

public abstract class AbstractDisposable : IDisposable
{
    public abstract void Dispose();
}
