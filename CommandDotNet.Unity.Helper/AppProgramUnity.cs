using Unity;
using CommandDotNet.IoC.Unity;
using CommandDotNet.Helper;
using Microsoft.Extensions.Configuration;

namespace CommandDotNet.Unity.Helper;

public class AppProgramUnity<TRootCommand> 
    : AppProgramConfiguration<IUnityContainer, TRootCommand>
        where TRootCommand : class
{
    public AppProgramUnity(
        IUnityContainer container) 
            : base(container)
    {
    }

    protected override void SetDIContainer() =>
        AppRunner.UseUnityContainer(Container);

    protected override IConfiguration? ResolveConfig() =>
        Container.Resolve<IConfiguration>();
}