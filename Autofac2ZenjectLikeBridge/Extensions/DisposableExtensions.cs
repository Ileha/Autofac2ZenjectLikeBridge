using Autofac.Core;

namespace Autofac2ZenjectLikeBridge.Extensions;

public static class DisposableExtensions
{
    public static T AddTo<T>(this T disposable, ICollection<IDisposable> composite)
        where T : IDisposable
    {
        if (disposable is null)
            throw new ArgumentNullException(nameof(disposable));

        ArgumentNullException.ThrowIfNull(composite);

        composite.Add(disposable);

        return disposable;
    }

    public static T AddTo<T>(this T disposable, IDisposer disposer)
        where T : IDisposable
    {
        if (disposable is null)
            throw new ArgumentNullException(nameof(disposable));

        ArgumentNullException.ThrowIfNull(disposer);

        disposer.AddInstanceForDisposal(disposable);

        return disposable;
    }
}