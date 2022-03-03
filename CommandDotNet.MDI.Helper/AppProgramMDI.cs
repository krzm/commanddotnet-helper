using CommandDotNet.Helper;
using CommandDotNet.IoC.MicrosoftDependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CommandDotNet.MDI.Helper;

public class AppProgramMDI<TRootCommand> 
    : AppProgramConfiguration<IServiceCollection, TRootCommand>
    where TRootCommand : class
{
    private IServiceProvider? serviceProvider;

    public AppProgramMDI(
        IServiceCollection services) 
            : base(services)
    {
    }

    protected override void SetDIContainer()
    {
        var commandClassTypes = AppRunner.GetCommandClassTypes();
        foreach (var type in commandClassTypes)
        {
            Container.AddTransient(type.type);
        }

        serviceProvider = Container.BuildServiceProvider();
        AppRunner.UseMicrosoftDependencyInjection(serviceProvider);
    }

    protected override IConfiguration? ResolveConfig()
    {
        if(serviceProvider != null)
        {
            return serviceProvider.GetService<IConfiguration>();
        }
        return default;
    }
}