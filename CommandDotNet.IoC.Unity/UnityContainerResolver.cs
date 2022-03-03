using CommandDotNet.Builders;
using Unity;

namespace CommandDotNet.IoC.Unity;

public class UnityContainerResolver : IDependencyResolver
{
    private readonly IUnityContainer container;

    public UnityContainerResolver(IUnityContainer container)
    {
        this.container = container;
    }

    public object Resolve(Type type)
    {
        return container.Resolve(type);
    }

    public bool TryResolve(Type type, out object? item)
    {
        item = container.Resolve(type);
        return item is { };
    }
}