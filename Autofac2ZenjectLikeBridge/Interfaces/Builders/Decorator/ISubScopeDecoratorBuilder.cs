using System;
using Autofac;
using Autofac.Core;
using JetBrains.Annotations;

namespace ZenAutofac.Interfaces.Builders.Decorator
{
    public interface ISubScopeDecoratorBuilder<in TDecorator, out TService> : IExtendedBuilderBase
        where TDecorator : TService, IDisposable
    {
        void ByFunction(Action<ContainerBuilder, TService> subScopeLoader);

        void ByModule<TModule>(
            [CanBeNull] Func<ILifetimeScope, TService, TModule> moduleFactory = null)
            where TModule : class, IModule;

        void ByFunction(
            Action<ContainerBuilder, TService> subScopeLoader,
            object fromKey,
            [CanBeNull] object toKey = null);

        void ByModule<TModule>(
            object fromKey,
            [CanBeNull] object toKey = null,
            [CanBeNull] Func<ILifetimeScope, TService, TModule> moduleFactory = null)
            where TModule : class, IModule;
    }
}