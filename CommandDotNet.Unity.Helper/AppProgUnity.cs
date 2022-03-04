using Unity;
using CommandDotNet.IoC.Unity;
using CommandDotNet.Helper;
using Microsoft.Extensions.Configuration;

namespace CommandDotNet.Unity.Helper;

public class AppProgUnity<TRootCommand> 
    : AppProgCmds<IUnityContainer, TRootCommand>
        where TRootCommand : class
{
    public AppProgUnity(
        IUnityContainer container) 
            : base(container)
    {
    }

    protected override void SetDIContainer() =>
        AppRunner.UseUnityContainer(Container);

    protected override void RegisterCmd(Type type) =>
        Container.RegisterType(type);

    protected override IConfiguration? ResolveConfig() =>
        Container.Resolve<IConfiguration>();
}