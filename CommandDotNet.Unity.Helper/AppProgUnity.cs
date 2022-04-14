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
    public Type[]? MannuallyRegisterCmds { get; set; }

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
            var skipCmd = MannuallyRegisterCmds?.FirstOrDefault(c => c == type.type);
            if (skipCmd != null) continue;
            container.RegisterSingleton(type.type);
        }
    }
}