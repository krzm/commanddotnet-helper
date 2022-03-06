using Unity;
using CommandDotNet.IoC.Unity;
using CommandDotNet.Helper;

namespace CommandDotNet.Unity.Helper;

public class AppProgUnity<TRootCommand>
    : AppProgRunner<IUnityContainer, TRootCommand>
        where TRootCommand : class
{
    public override void SetDIContainer(IUnityContainer container) =>
        AppRunner.UseUnityContainer(container);
}