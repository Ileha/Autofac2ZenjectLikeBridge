using Autofac2ZenjectLikeBridge.Extensions;
using NSubstitute;
using CustomCompositeDisposable = Autofac2ZenjectLikeBridge.Entities.CompositeDisposable;
using ReferencedCompositeDisposable = System.Reactive.Disposables.CompositeDisposable;

namespace Tests.Entities;

[TestFixture]
public class CompositeDisposableTests
{
    [SetUp]
    public void SetUp()
    {
        _disposable1 = Substitute.For<IDisposable>();
        _disposable2 = Substitute.For<IDisposable>();
    }

    [Test]
    public void Should_be_empty_when_created_with_default_ctor()
    {
        using var sut = new CustomCompositeDisposable();

        Assert.That(sut.Count, Is.EqualTo(0));
    }

    [Test]
    public void Should_be_empty_when_created_with_capacity_ctor()
    {
        using var sut = new CustomCompositeDisposable(64);

        Assert.That(sut.Count, Is.EqualTo(0));
    }

    [Test]
    public void Should_contain_disposables_when_created_with_params()
    {
        var sut = new CustomCompositeDisposable([_disposable1, _disposable2]);

        Assert.That(sut.Count, Is.EqualTo(2));
    }

    [Test]
    public void Should_throw_when_created_with_null_enumerable()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            using var _ = new CustomCompositeDisposable(null);
        });
    }

    [Test]
    public void Should_add_disposable()
    {
        var sut = new CustomCompositeDisposable();

        sut.Add(_disposable1);

        Assert.That(sut.Count, Is.EqualTo(1));
    }

    [Test]
    public void Should_throw_when_adding_null_disposable()
    {
        using var sut = new CustomCompositeDisposable();

        Assert.Throws<ArgumentNullException>(() => sut.Add(null));
    }

    [Test]
    public void Should_dispose_added_disposable_when_sut_is_disposed()
    {
        var sut = new CustomCompositeDisposable();
        sut.Dispose();

        sut.Add(_disposable1);

        _disposable1.Received(1).Dispose();
    }

    [Test]
    public void Should_dispose_all_disposables_when_disposed()
    {
        var sut = new CustomCompositeDisposable(new[] {_disposable1, _disposable2});

        sut.Dispose();

        _disposable1.Received(1).Dispose();
        _disposable2.Received(1).Dispose();
    }

    [Test]
    public void Should_be_empty_after_dispose()
    {
        var sut = new CustomCompositeDisposable(new[] {_disposable1, _disposable2});

        sut.Dispose();

        Assert.That(sut.Count, Is.EqualTo(0));
    }

    [Test]
    public void Should_remove_disposable()
    {
        var sut = new CustomCompositeDisposable(new[] {_disposable1});

        sut.Remove(_disposable1);

        Assert.That(sut.Count, Is.EqualTo(0));
    }

    [Test]
    public void Should_dispose_removed_disposable()
    {
        using var sut = new CustomCompositeDisposable(new[] {_disposable1});

        sut.Remove(_disposable1);

        _disposable1.Received(1).Dispose();
    }

    [Test]
    public void Should_throw_when_removing_null_disposable()
    {
        using var sut = new CustomCompositeDisposable();

        Assert.Throws<ArgumentNullException>(() => sut.Remove(null));
    }

    [Test]
    public void Should_clear_disposables()
    {
        var sut = new CustomCompositeDisposable(new[] {_disposable1, _disposable2});

        sut.Clear();

        Assert.That(sut.Count, Is.EqualTo(0));
        _disposable1.Received(1).Dispose();
        _disposable2.Received(1).Dispose();
    }

    [Test]
    public void Reference_Should_clear_disposables()
    {
        var sut = new ReferencedCompositeDisposable(new[] {_disposable1, _disposable2});

        sut.Clear();

        Assert.That(sut.Count, Is.EqualTo(0));
    }

    [Test]
    public void Should_dispose_cleared_disposables()
    {
        using var sut = new CustomCompositeDisposable(new[] {_disposable1, _disposable2});

        sut.Clear();

        _disposable1.Received(1).Dispose();
        _disposable2.Received(1).Dispose();
    }

    [Test]
    public void Reference_Should_dispose_cleared_disposables()
    {
        using var sut = new ReferencedCompositeDisposable(new[] {_disposable1, _disposable2});

        sut.Clear();

        _disposable1.Received(1).Dispose();
        _disposable2.Received(1).Dispose();
    }

    [Test]
    public void Should_contain_disposable()
    {
        var sut = new CustomCompositeDisposable(new[] {_disposable1});

        Assert.That(sut.Contains(_disposable1));
    }

    [Test]
    public void Should_not_contain_disposable_after_dispose()
    {
        var sut = new CustomCompositeDisposable(new[] {_disposable1});
        sut.Dispose();

        Assert.That(!sut.Contains(_disposable1));
    }

    [Test]
    public void Should_copy_to_array()
    {
        var sut = new CustomCompositeDisposable(new[] {_disposable1, _disposable2});
        var array = new IDisposable[2];

        sut.CopyTo(array, 0);

        Assert.That(array[0], Is.EqualTo(_disposable1));
        Assert.That(array[1], Is.EqualTo(_disposable2));
    }

    [Test]
    public void Should_get_enumerator()
    {
        var sut = new CustomCompositeDisposable(new[] {_disposable1, _disposable2});

        var disposables = new List<IDisposable>();

        foreach (var disposable in sut)
            disposables.Add(disposable);

        Assert.That(disposables, Is.EquivalentTo(new[] {_disposable1, _disposable2}));
    }

    [Test]
    public void Should_have_the_same_behavior_as_reactive_when_adding_after_dispose()
    {
        var custom = new CustomCompositeDisposable {_disposable1};
        var reactive = new ReferencedCompositeDisposable {_disposable2};

        custom.Dispose();
        reactive.Dispose();

        var newDisposable1 = Substitute.For<IDisposable>();
        var newDisposable2 = Substitute.For<IDisposable>();

        custom.Add(newDisposable1);
        reactive.Add(newDisposable2);

        newDisposable1.Received(1).Dispose();
        newDisposable2.Received(1).Dispose();
    }

    [Test]
    public void Dispose_WhenCalledShouldDisposeInnerDisposable()
    {
        var custom = new CustomCompositeDisposable();

        _disposable1
            .AddTo(custom);

        _disposable2
            .AddTo(custom);

        custom.Dispose();

        _disposable1.Received(1).Dispose();
        _disposable1.Received(1).Dispose();
    }

    [Test]
    public void Reference_Dispose_WhenCalledShouldDisposeInnerDisposable()
    {
        var custom = new ReferencedCompositeDisposable();

        _disposable1
            .AddTo(custom);

        _disposable2
            .AddTo(custom);

        custom.Dispose();

        _disposable1.Received(1).Dispose();
        _disposable1.Received(1).Dispose();
    }

#pragma warning disable NUnit1032
    private IDisposable _disposable1;
    private IDisposable _disposable2;
#pragma warning restore NUnit1032
}