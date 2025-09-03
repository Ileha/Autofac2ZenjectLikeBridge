using System;
using Autofac;
using Autofac.Builder;
using Autofac2ZenjectLikeBridge.Interfaces.Builders.Instance;

namespace Autofac2ZenjectLikeBridge.Builders.Instance
{
    public class ExtendedRegistrationBuilder<TComponent> : IExtendedRegistrationBuilder<TComponent>
        where TComponent : class
    {
        public ContainerBuilder Builder { get; }

        public ExtendedRegistrationBuilder(ContainerBuilder builder)
        {
            Builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        // public ISubScopeBuilder<TComponentDisposable> FromSubScope<TComponentDisposable>()
        //     where TComponentDisposable : TComponent, IDisposable
        // {
        //     return new SubScopeBuilder<TComponentDisposable>(_builder);
        // }

        public IRegistrationBuilder<TComponent, SimpleActivatorData, SingleRegistrationStyle> FromInstance(TComponent instance)
        {
            return Builder
                .Register(_ => instance);
        }

        public IRegistrationBuilder<TComponent, SimpleActivatorData, SingleRegistrationStyle> FromNewInstance()
        {
            return Builder
                .Register(context => context.CreateInstance<TComponent>());
        }
    }
}