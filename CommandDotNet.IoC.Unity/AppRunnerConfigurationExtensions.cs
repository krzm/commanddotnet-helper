using CommandDotNet.Execution;
using Unity;

namespace CommandDotNet.IoC.Unity;

public static class AppRunnerConfigurationExtensions
{
    public static AppRunner UseUnityContainer(
        this AppRunner appRunner, 
        IUnityContainer container
        , Func<CommandContext, IDisposable>? runInScope = null
        , ResolveStrategy argumentModelResolveStrategy = ResolveStrategy.TryResolve
        , ResolveStrategy commandClassResolveStrategy = ResolveStrategy.Resolve)
    {
        return appRunner.UseDependencyResolver(
            new UnityContainerResolver(container)
            , runInScope
            , argumentModelResolveStrategy
            , commandClassResolveStrategy);
    }
}