using System;
using Autofac;
using Autofac.Core;
using JetBrains.Annotations;

namespace Autofac2ZenjectLikeBridge.Interfaces.Builders.Decorator
{
    public interface ISubScopeDecoratorBuilder<in TDecorator, out TService> : IExtendedBuilderBase
        where TDecorator : TService, IDisposable
    {
        void ByFunction(Action<ContainerBuilder, TService> subScopeInstaller);

        void ByModule<TModule>(
            [CanBeNull] Func<ILifetimeScope, TService, TModule> installerFactory = null)
            where TModule : class, IModule;

        void ByFunction(
            Action<ContainerBuilder, TService> subScopeInstaller,
            object fromKey,
            [CanBeNull] object toKey = null);

        void ByModule<TModule>(
            object fromKey,
            [CanBeNull] object toKey = null,
            [CanBeNull] Func<ILifetimeScope, TService, TModule> installerFactory = null)
            where TModule : class, IModule;
    }
}