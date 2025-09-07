using System;
using Autofac;
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
    }
}