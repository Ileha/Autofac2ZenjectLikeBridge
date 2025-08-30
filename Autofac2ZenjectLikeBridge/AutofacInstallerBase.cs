using System;
using Autofac;
using Autofac2ZenjectLikeBridge.Interfaces;

namespace Autofac2ZenjectLikeBridge
{
    public abstract class AutofacInstallerBase : IInstaller
    {
        protected readonly ContainerBuilder Builder;

        protected AutofacInstallerBase(ContainerBuilder builder)
        {
            Builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public abstract void Install();
    }
}