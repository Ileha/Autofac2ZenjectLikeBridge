using System.Collections;

namespace Autofac2ZenjectLikeBridge.Entities;

public sealed class CompositeDisposable : ICollection<IDisposable>, IDisposable
{
    private readonly List<IDisposable> _disposables;
    private readonly object _gate = new();
    private bool _disposed;

    public CompositeDisposable()
    {
        _disposables = new List<IDisposable>();
    }

    public CompositeDisposable(IEnumerable<IDisposable> disposables)
    {
        ArgumentNullException.ThrowIfNull(disposables);

        _disposables = new List<IDisposable>(disposables);
    }

    public int Count
    {
        get
        {
            lock (_gate)
                return _disposed ? 0 : _disposables.Count;
        }
    }

    public bool IsReadOnly => false;

    public void Add(IDisposable item)
    {
        ArgumentNullException.ThrowIfNull(item);

        var disposeNow = false;

        lock (_gate)
            if (_disposed)
                disposeNow = true;
            else
                _disposables.Add(item);

        if (disposeNow)
            item.Dispose();
    }

    public bool Remove(IDisposable item)
    {
        ArgumentNullException.ThrowIfNull(item);

        var shouldDispose = false;

        lock (_gate)
            if (!_disposed && _disposables.Remove(item))
                shouldDispose = true;

        if (!shouldDispose)
            return false;

        item.Dispose();
        return true;
    }

    public void Clear()
    {
        IDisposable[]? currentDisposables = null;

        lock (_gate)
            if (!_disposed)
            {
                currentDisposables = _disposables.ToArray();
                _disposables.Clear();
            }

        if (currentDisposables == null)
            return;

        foreach (var d in currentDisposables)
            d.Dispose();
    }

    public bool Contains(IDisposable item)
    {
        if (item == null)
            return false;

        lock (_gate)
            return !_disposed && _disposables.Contains(item);
    }

    public void CopyTo(IDisposable[] array, int arrayIndex)
    {
        lock (_gate)
        {
            if (_disposed)
                return;

            _disposables.CopyTo(array, arrayIndex);
        }
    }

    public IEnumerator<IDisposable> GetEnumerator()
    {
        IDisposable[] snapshot;

        lock (_gate)
            snapshot = _disposed ? [] : _disposables.ToArray();

        return (snapshot as IEnumerable<IDisposable>).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Dispose()
    {
        IDisposable[]? currentDisposables = null;

        lock (_gate)
            if (!_disposed)
            {
                _disposed = true;
                currentDisposables = _disposables.ToArray();
                _disposables.Clear();
            }

        if (currentDisposables == null)
            return;

        foreach (var d in currentDisposables)
            d.Dispose();
    }
}