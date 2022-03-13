using CommandDotNet.Helper;
using CommandDotNet.IoC.MicrosoftDependencyInjection;
using Config.Wrapper;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace CommandDotNet.MDI.Helper;

public class AppProgMDI<TRootCommand> 
    : AppProgRunner<IServiceCollection, TRootCommand>
        where TRootCommand : class
{
    public AppProgMDI(
        ILogger log
        , IConfigReader config) 
            : base(log, config)
    {
    }

    public override void SetDIContainer(IServiceCollection container)
    {
        var serviceProvider = container.BuildServiceProvider();
        AppRunner.UseMicrosoftDependencyInjection(serviceProvider);
    }
}