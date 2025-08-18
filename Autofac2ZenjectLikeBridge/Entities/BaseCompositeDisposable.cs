using System.Collections;
using Autofac2ZenjectLikeBridge.Extensions;

namespace Autofac2ZenjectLikeBridge.Entities;

public abstract class BaseCompositeDisposable<T> : ICollection<IDisposable>, IDisposable
    where T : ICollection<IDisposable>, IDisposable
{
    private readonly T _compositeDisposable;
    public int Count => _compositeDisposable.Count;
    public bool IsReadOnly => _compositeDisposable.IsReadOnly;

    protected CancellationToken CancellationToken { get; }

    protected BaseCompositeDisposable(T baseDisposable)
    {
        _compositeDisposable = baseDisposable ?? throw new ArgumentNullException(nameof(baseDisposable));

        var cancellationDisposable = new CancellationDisposable()
            .AddTo(_compositeDisposable);

        CancellationToken = cancellationDisposable.Token;
    }

    public IEnumerator<IDisposable> GetEnumerator()
    {
        return _compositeDisposable.GetEnumerator();
    }

    public void Add(IDisposable item)
    {
        _compositeDisposable.Add(item);
    }

    public void Clear()
    {
        _compositeDisposable.Clear();
    }

    public bool Contains(IDisposable item)
    {
        return _compositeDisposable.Contains(item);
    }

    public void CopyTo(IDisposable[] array, int arrayIndex)
    {
        _compositeDisposable.CopyTo(array, arrayIndex);
    }

    public bool Remove(IDisposable item)
    {
        return _compositeDisposable.Remove(item);
    }

    public virtual void Dispose()
    {
        _compositeDisposable.Dispose();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public abstract class BaseCompositeDisposable : BaseCompositeDisposable<CompositeDisposable>
{
    protected BaseCompositeDisposable()
        : base(new CompositeDisposable())
    {
    }
}