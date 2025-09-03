using Autofac;

namespace Autofac2ZenjectLikeBridge.Interfaces.Builders
{
    public interface IExtendedBuilderBase
    {
        ContainerBuilder Builder { get; }
    }
}