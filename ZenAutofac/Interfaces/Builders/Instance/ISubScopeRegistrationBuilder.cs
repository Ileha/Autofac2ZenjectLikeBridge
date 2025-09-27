using System;
using Autofac;
using Autofac.Builder;
using Autofac.Core;
using JetBrains.Annotations;

namespace ZenAutofac.Interfaces.Builders.Instance
{
    public interface ISubScopeRegistrationBuilder<out TComponent> : IExtendedBuilderBase
        where TComponent : class, IDisposable
    {
        IRegistrationBuilder<
            TComponent,
            SimpleActivatorData,
            SingleRegistrationStyle> ByFunction(Action<ContainerBuilder> subScopeLoader);

        IRegistrationBuilder<
            TComponent,
            SimpleActivatorData,
            SingleRegistrationStyle> ByModule<TModule>(
            [CanBeNull] Func<ILifetimeScope, TModule> moduleFactory = null)
            where TModule : class, IModule;
    }
}