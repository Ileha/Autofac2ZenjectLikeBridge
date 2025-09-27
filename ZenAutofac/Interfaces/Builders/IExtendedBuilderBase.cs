using Autofac;

namespace ZenAutofac.Interfaces.Builders
{
    public interface IExtendedBuilderBase
    {
        ContainerBuilder Builder { get; }
    }
}