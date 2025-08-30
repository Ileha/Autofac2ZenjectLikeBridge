using System;
using Autofac;
using Autofac2ZenjectLikeBridge.Interfaces.Builders.Decorator;

namespace Autofac2ZenjectLikeBridge.Builders.Decorator
{
    public class ExtendedRegistrationDecoratorBuilder<TDecorator, TService>
        : IExtendedRegistrationDecoratorBuilder<TDecorator, TService> where TDecorator : TService
        where TService : class
    {
        private readonly ContainerBuilder _builder;

        public ExtendedRegistrationDecoratorBuilder(ContainerBuilder builder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public void RegisterDecoratorFromFunction(Func<IComponentContext, TService, TDecorator> createFunction)
        {
            _builder
                .RegisterDecorator<TService>((context, _, baseHandler) => createFunction(context, baseHandler));
        }

        public void RegisterDecoratorFromFunction(
            Func<IComponentContext, TService, TDecorator> createFunction,
            object fromKey,
            object toKey = null)
        {
            _builder
                .RegisterDecorator<TService>(
                    (context, _, baseHandler) => createFunction(context, baseHandler),
                    fromKey,
                    toKey);
        }

        public ISubScopeDecoratorBuilder<TTDecoratorDisposable, TService> FromSubScope<TTDecoratorDisposable>()
            where TTDecoratorDisposable : TDecorator, IDisposable
        {
            return new SubScopeDecoratorBuilder<TTDecoratorDisposable, TService>(_builder);
        }
    }
}