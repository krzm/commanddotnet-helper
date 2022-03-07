using CLIHelper;
using CommandDotNet.Helper;
using CommandDotNet.IoC.MicrosoftDependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace CommandDotNet.MDI.Helper;

public class AppProgMDI<TRootCommand> 
    : AppProgRunner<IServiceCollection, TRootCommand>
        where TRootCommand : class
{
    public AppProgMDI(
        IOutput output) 
            : base(output)
    {
    }

    public override void SetDIContainer(IServiceCollection container)
    {
        var serviceProvider = container.BuildServiceProvider();
        AppRunner.UseMicrosoftDependencyInjection(serviceProvider);
    }
}