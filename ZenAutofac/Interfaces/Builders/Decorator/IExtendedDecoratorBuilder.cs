using System;
using Autofac;
using JetBrains.Annotations;

namespace ZenAutofac.Interfaces.Builders.Decorator
{
    public interface IExtendedDecoratorBuilder<in TDecorator, out TService> : IExtendedBuilderBase
        where TDecorator : TService
    {
        void FromFunction(
                Func<IComponentContext, TService, TDecorator> createFunction);

        void FromFunction(
            Func<IComponentContext, TService, TDecorator> createFunction,
            object fromKey,
            [CanBeNull] object toKey = null);
    }
}