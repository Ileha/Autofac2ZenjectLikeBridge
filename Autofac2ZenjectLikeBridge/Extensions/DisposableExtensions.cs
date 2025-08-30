using System;
using System.Collections.Generic;
using Autofac.Core;

namespace Autofac2ZenjectLikeBridge.Extensions
{
    public static class DisposableExtensions
    {
        public static T AddTo<T>(this T disposable, ICollection<IDisposable> composite)
            where T : IDisposable
        {
            if (disposable == null)
                throw new ArgumentNullException(nameof(disposable));

            if (composite == null)
                throw new ArgumentNullException(nameof(composite));

            composite.Add(disposable);

            return disposable;
        }

        public static T AddTo<T>(this T disposable, IDisposer disposer)
            where T : IDisposable
        {
            if (disposable == null)
                throw new ArgumentNullException(nameof(disposable));

            if (disposer is null)
                throw new ArgumentNullException(nameof(disposer));

            disposer.AddInstanceForDisposal(disposable);

            return disposable;
        }
    }
}