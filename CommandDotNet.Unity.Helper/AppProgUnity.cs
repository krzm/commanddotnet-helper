using Unity;
using CommandDotNet.IoC.Unity;
using CommandDotNet.Helper;
using Serilog;
using Config.Wrapper;

namespace CommandDotNet.Unity.Helper;

public class AppProgUnity<TRootCommand>
    : AppProgRunner<IUnityContainer, TRootCommand>
        where TRootCommand : class
{
    public AppProgUnity(
        ILogger log
        , IConfigReader config) 
            : base(log, config)
    {
    }

    public void SetDIContainer(IUnityContainer container)
    {
        Log.Verbose("UnityContainer set in AppRunner");
        AppRunner.UseUnityContainer(container);
    }

    public virtual void RegisterCommandClasses(
        IUnityContainer container)
    {
        var commandClassTypes = AppRunner.GetCommandClassTypes();
        foreach (var type in commandClassTypes)
        {
            container.RegisterSingleton(type.type);
        }
    }
}