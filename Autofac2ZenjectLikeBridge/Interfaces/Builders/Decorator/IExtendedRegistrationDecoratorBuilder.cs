using System;
using Autofac;
using JetBrains.Annotations;

namespace Autofac2ZenjectLikeBridge.Interfaces.Builders.Decorator
{
    public interface IExtendedRegistrationDecoratorBuilder<in TDecorator, out TService>
        where TDecorator : TService
    {
        void RegisterDecoratorFromFunction(
                Func<IComponentContext, TService, TDecorator> createFunction)
        ;

        void RegisterDecoratorFromFunction(
            Func<IComponentContext, TService, TDecorator> createFunction,
            object fromKey,
            [CanBeNull] object toKey = null);

        ISubScopeDecoratorBuilder<TTDecoratorDisposable, TService> FromSubScope<TTDecoratorDisposable>()
            where TTDecoratorDisposable : TDecorator, IDisposable;
    }
}