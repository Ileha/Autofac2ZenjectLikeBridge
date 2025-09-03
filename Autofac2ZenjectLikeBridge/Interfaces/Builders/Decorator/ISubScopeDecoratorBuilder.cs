using System;
using Autofac;
using JetBrains.Annotations;

namespace Autofac2ZenjectLikeBridge.Interfaces.Builders.Decorator
{
    public interface ISubScopeDecoratorBuilder<in TDecorator, out TService> : IExtendedRegistrationBuilderBase
        where TDecorator : TService, IDisposable
    {
        void FromFunction(Action<ContainerBuilder, TService> subScopeInstaller);

        void FromInstaller<TInstaller>(TInstaller installer)
            where TInstaller : class, IInstaller;

        void FromFunction(
            Action<ContainerBuilder, TService> subScopeInstaller,
            object fromKey,
            [CanBeNull] object toKey = null);

        void FromInstaller<TInstaller>(TInstaller installer,
            object fromKey,
            [CanBeNull] object toKey = null)
            where TInstaller : class, IInstaller;
    }
}