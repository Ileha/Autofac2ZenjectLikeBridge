using System;
using Autofac;
using JetBrains.Annotations;

namespace Autofac2ZenjectLikeBridge.Interfaces.Builders.Decorator
{
    public interface IExtendedDecoratorBuilder<in TDecorator, out TService> : IExtendedRegistrationBuilderBase
        where TDecorator : TService
    {
        void RegisterDecoratorFromFunction(
                Func<IComponentContext, TService, TDecorator> createFunction);

        void RegisterDecoratorFromFunction(
            Func<IComponentContext, TService, TDecorator> createFunction,
            object fromKey,
            [CanBeNull] object toKey = null);
    }
}