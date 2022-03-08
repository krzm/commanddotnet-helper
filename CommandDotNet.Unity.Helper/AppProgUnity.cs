using Unity;
using CommandDotNet.IoC.Unity;
using CommandDotNet.Helper;
using CLIHelper;

namespace CommandDotNet.Unity.Helper;

public class AppProgUnity<TRootCommand>
    : AppProgRunner<IUnityContainer, TRootCommand>
        where TRootCommand : class
{
    public AppProgUnity(
        IOutput output) 
            : base(output)
    {
    }

    public override void SetDIContainer(IUnityContainer container)
    {
        Output.Log("UnityContainer set in AppRunner");
        AppRunner.UseUnityContainer(container);
    }
}