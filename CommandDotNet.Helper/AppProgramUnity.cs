using Unity;
using CommandDotNet.IoC.Unity;

namespace CommandDotNet.Helper;

public class AppProgramUnity<TRootCommand> 
    : AppProgram<IUnityContainer, TRootCommand>
        where TRootCommand : class
{
    public AppProgramUnity(IUnityContainer container) 
        : base(container)
    {
    }

    protected override void SetDIContainer(AppRunner appRunner) => 
        appRunner.UseUnityContainer(Container);
}