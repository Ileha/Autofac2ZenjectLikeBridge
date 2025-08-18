namespace Autofac2ZenjectLikeBridge.Entities;

public sealed class CancellationDisposable : IDisposable
{
    private readonly CancellationTokenSource _cts;

    public CancellationToken Token { get; }

    public CancellationDisposable()
    {
        _cts = new CancellationTokenSource();
        Token = _cts.Token;
    }

    public CancellationDisposable(CancellationTokenSource cts)
    {
        _cts = cts ?? throw new ArgumentNullException(nameof(cts));
        Token = _cts.Token;
    }

    public void Dispose()
    {
        _cts.Cancel();
        _cts.Dispose();
    }
}