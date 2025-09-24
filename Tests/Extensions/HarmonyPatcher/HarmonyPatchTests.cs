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
        var patchedTypesField =
            typeof(HarmonyPatch).GetField("PatchedTypes", BindingFlags.NonPublic | BindingFlags.Static);

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

    [Test]
    public void HarmonyDisposeCallsLast_When_Dispose()
    {
        // Arrange
        var disposablesOrder = new List<IDisposable>();

        var instance = Substitute.For<IDisposable>();
        var childDisposable = Substitute.For<IDisposable>();

        CollectDisposableOrder(instance);
        CollectDisposableOrder(childDisposable);

        // Act
        childDisposable.AddToHarmony(instance);
        instance.Dispose();

        // Assert
        childDisposable.Received(1).Dispose();
        CollectionAssert.AreEqual(new [] { instance, childDisposable }, disposablesOrder);

        void CollectDisposableOrder(IDisposable disposable)
        {
            disposable
                .When(x => x.Dispose())
                .Do(x => disposablesOrder.Add(disposable));
        }
    }

    [TestCase(10)]
    [TestCase(20)]
    public void HarmonyDisposeInOrderAdded_When_Dispose(int childCount)
    {
        // Arrange
        var disposablesOrder = new List<IDisposable>();

        var instance = Substitute.For<IDisposable>();
        CollectDisposableOrder(instance);

        var childDisposables = new IDisposable[childCount];

        for (var i = 0; i < childDisposables.Length; i++)
        {
            childDisposables[i] = Substitute.For<IDisposable>();
            CollectDisposableOrder(childDisposables[i]);
            childDisposables[i].AddToHarmony(instance);
        }


        // Act
        instance.Dispose();

        // Assert
        Assert.Multiple(() =>
        {
            for (var i = 0; i < childDisposables.Length; i++)
                childDisposables[i].Received(1).Dispose();
        });

        CollectionAssert.AreEqual(new [] { instance }.Concat(childDisposables), disposablesOrder);

        void CollectDisposableOrder(IDisposable disposable)
        {
            disposable
                .When(x => x.Dispose())
                .Do(x => disposablesOrder.Add(disposable));
        }
    }
}

// Test Classes
public class SimpleDisposable : IDisposable
{
    public void Dispose()
    {
        /* Patched by Harmony */
    }
}

public class DynamicDisposable : IDisposable
{
    public void Dispose()
    {
        /* Patched by Harmony */
    }
}

public class GenericDisposable<T> : IDisposable
{
    public void Dispose()
    {
        /* Patched by Harmony */
    }
}

public abstract class AbstractDisposable : IDisposable
{
    public abstract void Dispose();
}