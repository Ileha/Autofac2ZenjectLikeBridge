using System;
using Autofac;
using JetBrains.Annotations;

namespace Autofac2ZenjectLikeBridge.Interfaces.Builders.Decorator
{
    public interface ISubScopeDecoratorBuilder<in TDecorator, out TService> : IExtendedBuilderBase
        where TDecorator : TService, IDisposable
    {
        void ByFunction(Action<ContainerBuilder, TService> subScopeInstaller);

        void ByInstaller<TInstaller>(
            [CanBeNull] Func<ContainerBuilder, TService, TInstaller> installerFactory = null)
            where TInstaller : class, IInstaller;

        void ByFunction(
            Action<ContainerBuilder, TService> subScopeInstaller,
            object fromKey,
            [CanBeNull] object toKey = null);

        void ByInstaller<TInstaller>(
            object fromKey,
            [CanBeNull] object toKey = null,
            [CanBeNull] Func<ContainerBuilder, TService, TInstaller> installerFactory = null)
            where TInstaller : class, IInstaller;
    }
}