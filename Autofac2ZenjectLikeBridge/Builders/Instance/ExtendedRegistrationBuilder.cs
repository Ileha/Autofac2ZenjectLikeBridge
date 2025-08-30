using System;
using Autofac;
using Autofac2ZenjectLikeBridge.Interfaces.Builders.Instance;

namespace Autofac2ZenjectLikeBridge.Builders.Instance
{
    public class ExtendedRegistrationBuilder<TComponent> : IExtendedRegistrationBuilder<TComponent>
    {
        private readonly ContainerBuilder _builder;

        public ExtendedRegistrationBuilder(ContainerBuilder builder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public ISubScopeBuilder<TComponentDisposable> FromSubScope<TComponentDisposable>()
            where TComponentDisposable : TComponent, IDisposable
        {
            return new SubScopeBuilder<TComponentDisposable>(_builder);
        }
    }
}