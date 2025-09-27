using NSubstitute;
using ZenAutofac.Extensions;
using CustomCompositeDisposable = ZenAutofac.Entities.CompositeDisposable;
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
        //Arrange
        using var sut = new CustomCompositeDisposable();

        //Act
        var count = sut.Count;

        //Assert
        Assert.That(count, Is.EqualTo(0));
    }

    [Test]
    public void Should_be_empty_when_created_with_capacity_ctor()
    {
        //Arrange
        using var sut = new CustomCompositeDisposable(64);

        //Act
        var count = sut.Count;

        //Assert
        Assert.That(count, Is.EqualTo(0));
    }

    [Test]
    public void Should_contain_disposables_when_created_with_params()
    {
        //Arrange
        var sut = new CustomCompositeDisposable([_disposable1, _disposable2]);

        //Act
        var count = sut.Count;

        //Assert
        Assert.That(count, Is.EqualTo(2));
    }

    [Test]
    public void Should_throw_when_created_with_null_enumerable()
    {
        //Arrange & Act & Asser
        Assert.Throws<ArgumentNullException>(() =>
        {
            using var _ = new CustomCompositeDisposable(null);
        });
    }

    [Test]
    public void Should_add_disposable()
    {
        //Arrange
        var sut = new CustomCompositeDisposable();

        //Act
        sut.Add(_disposable1);

        //Assert
        Assert.That(sut.Count, Is.EqualTo(1));
    }

    [Test]
    public void Should_throw_when_adding_null_disposable()
    {
        //Arrange
        using var sut = new CustomCompositeDisposable();

        //Act & Assert
        Assert.Throws<ArgumentNullException>(() => sut.Add(null));
    }

    [Test]
    public void Should_dispose_added_disposable_when_sut_is_disposed()
    {
        //Arrange
        var sut = new CustomCompositeDisposable();
        sut.Dispose();

        //Act
        sut.Add(_disposable1);

        //Assert
        _disposable1.Received(1).Dispose();
    }

    [Test]
    public void Should_dispose_all_disposables_when_disposed()
    {
        //Arrange
        var sut = new CustomCompositeDisposable(new[] {_disposable1, _disposable2});

        //Act
        sut.Dispose();

        //Assert
        _disposable1.Received(1).Dispose();
        _disposable2.Received(1).Dispose();
    }

    [Test]
    public void Should_be_empty_after_dispose()
    {
        //Arrange
        var sut = new CustomCompositeDisposable(new[] {_disposable1, _disposable2});

        //Act
        sut.Dispose();

        //Assert
        Assert.That(sut.Count, Is.EqualTo(0));
    }

    [Test]
    public void Should_remove_disposable()
    {
        //Arrange
        var sut = new CustomCompositeDisposable(new[] {_disposable1});

        //Act
        sut.Remove(_disposable1);

        //Assert
        Assert.That(sut.Count, Is.EqualTo(0));
    }

    [Test]
    public void Should_dispose_removed_disposable()
    {
        //Arrange
        using var sut = new CustomCompositeDisposable(new[] {_disposable1});

        //Act
        sut.Remove(_disposable1);

        //Assert
        _disposable1.Received(1).Dispose();
    }

    [Test]
    public void Should_throw_when_removing_null_disposable()
    {
        //Arrange
        using var sut = new CustomCompositeDisposable();

        //Act & Assert
        Assert.Throws<ArgumentNullException>(() => sut.Remove(null));
    }

    [Test]
    public void Should_clear_disposables()
    {
        //Arrange
        var sut = new CustomCompositeDisposable(new[] {_disposable1, _disposable2});

        //Act
        sut.Clear();

        //Assert
        Assert.That(sut.Count, Is.EqualTo(0));
        _disposable1.Received(1).Dispose();
        _disposable2.Received(1).Dispose();
    }

    [Test]
    public void Reference_Should_clear_disposables()
    {
        //Arrange
        var sut = new ReferencedCompositeDisposable(new[] {_disposable1, _disposable2});

        //Act
        sut.Clear();

        //Assert
        Assert.That(sut.Count, Is.EqualTo(0));
    }

    [Test]
    public void Should_dispose_cleared_disposables()
    {
        //Arrange
        using var sut = new CustomCompositeDisposable(new[] {_disposable1, _disposable2});

        //Act
        sut.Clear();

        //Assert
        _disposable1.Received(1).Dispose();
        _disposable2.Received(1).Dispose();
    }

    [Test]
    public void Reference_Should_dispose_cleared_disposables()
    {
        //Arrange
        using var sut = new ReferencedCompositeDisposable(new[] {_disposable1, _disposable2});

        //Act
        sut.Clear();

        //Assert
        _disposable1.Received(1).Dispose();
        _disposable2.Received(1).Dispose();
    }

    [Test]
    public void Should_contain_disposable()
    {
        //Arrange
        var sut = new CustomCompositeDisposable(new[] {_disposable1});

        //Act
        var contains = sut.Contains(_disposable1);

        //Assert
        Assert.That(contains);
    }

    [Test]
    public void Should_not_contain_disposable_after_dispose()
    {
        //Arrange
        var sut = new CustomCompositeDisposable(new[] {_disposable1});
        sut.Dispose();

        //Act
        var contains = sut.Contains(_disposable1);

        //Assert
        Assert.That(!contains);
    }

    [Test]
    public void Should_copy_to_array()
    {
        //Arrange
        var sut = new CustomCompositeDisposable(new[] {_disposable1, _disposable2});
        var array = new IDisposable[2];

        //Act
        sut.CopyTo(array, 0);

        //Assert
        Assert.That(array[0], Is.EqualTo(_disposable1));
        Assert.That(array[1], Is.EqualTo(_disposable2));
    }

    [Test]
    public void Should_get_enumerator()
    {
        //Arrange
        var sut = new CustomCompositeDisposable(new[] {_disposable1, _disposable2});
        var disposables = new List<IDisposable>();

        //Act
        foreach (var disposable in sut)
            disposables.Add(disposable);

        //Assert
        Assert.That(disposables, Is.EquivalentTo(new[] {_disposable1, _disposable2}));
    }

    [Test]
    public void Should_have_the_same_behavior_as_reactive_when_adding_after_dispose()
    {
        //Arrange
        var custom = new CustomCompositeDisposable {_disposable1};
        var reactive = new ReferencedCompositeDisposable {_disposable2};

        custom.Dispose();
        reactive.Dispose();

        var newDisposable1 = Substitute.For<IDisposable>();
        var newDisposable2 = Substitute.For<IDisposable>();

        //Act
        custom.Add(newDisposable1);
        reactive.Add(newDisposable2);

        //Assert
        newDisposable1.Received(1).Dispose();
        newDisposable2.Received(1).Dispose();
    }

    [Test]
    public void Dispose_WhenCalledShouldDisposeInnerDisposable()
    {
        //Arrange
        var custom = new CustomCompositeDisposable();

        _disposable1
            .AddTo(custom);

        _disposable2
            .AddTo(custom);

        //Act
        custom.Dispose();

        //Assert
        _disposable1.Received(1).Dispose();
        _disposable2.Received(1).Dispose();
    }

    [Test]
    public void Reference_Dispose_WhenCalledShouldDisposeInnerDisposable()
    {
        //Arrange
        var custom = new ReferencedCompositeDisposable();

        _disposable1
            .AddTo(custom);

        _disposable2
            .AddTo(custom);

        //Act
        custom.Dispose();

        //Assert
        _disposable1.Received(1).Dispose();
        _disposable2.Received(1).Dispose();
    }

#pragma warning disable NUnit1032
    private IDisposable _disposable1;
    private IDisposable _disposable2;
#pragma warning restore NUnit1032
}