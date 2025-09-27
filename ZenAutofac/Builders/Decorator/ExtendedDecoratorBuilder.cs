using System;
using Autofac;
using ZenAutofac.Interfaces.Builders.Decorator;

namespace ZenAutofac.Builders.Decorator
{
    public class ExtendedDecoratorBuilder<TDecorator, TService>
        : IExtendedDecoratorBuilder<TDecorator, TService>
        where TDecorator : TService
        where TService : class
    {
        public ContainerBuilder Builder { get; }

        public ExtendedDecoratorBuilder(ContainerBuilder builder)
        {
            Builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public void FromFunction(Func<IComponentContext, TService, TDecorator> createFunction)
        {
            Builder
                .RegisterDecorator<TService>((context, _, baseHandler) => createFunction(context, baseHandler));
        }

        public void FromFunction(
            Func<IComponentContext, TService, TDecorator> createFunction,
            object fromKey,
            object toKey = null)
        {
            Builder
                .RegisterDecorator<TService>(
                    (context, _, baseHandler) => createFunction(context, baseHandler),
                    fromKey,
                    toKey);
        }
    }
}