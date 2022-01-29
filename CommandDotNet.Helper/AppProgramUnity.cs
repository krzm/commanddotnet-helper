using Unity;
using CommandDotNet.IoC.Unity;

namespace CommandDotNet.Helper;

public class AppProgramUnity<TRootCommand> 
    : AppProgram<IUnityContainer, TRootCommand>
        where TRootCommand : class
{
    public AppProgramUnity(IUnityContainer container) : base(container)
    {
    }

    protected override void SetAppRunnerContainer(AppRunner appRunner)
    {
        RegisterCommandClasses(appRunner);
        appRunner.UseUnityContainer(Container);
    }

    protected virtual void RegisterCommandClasses(AppRunner appRunner)
    {
        var commandClassTypes = appRunner.GetCommandClassTypes();
        foreach (var type in commandClassTypes)
        {
            Container.RegisterSingleton(type.type);
        }
    }
}