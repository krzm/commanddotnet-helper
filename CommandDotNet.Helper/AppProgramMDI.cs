using CommandDotNet.IoC.MicrosoftDependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace CommandDotNet.Helper;

public class AppProgramMDI<TRootCommand> 
    : AppProgram<IServiceCollection, TRootCommand>
    where TRootCommand : class
{
    public AppProgramMDI(
        IServiceCollection services) 
            : base(services)
    {
    }

    protected override void SetDIContainer(
        AppRunner appRunner)
    {
        var commandClassTypes = appRunner.GetCommandClassTypes();
        foreach (var type in commandClassTypes)
        {
            Container.AddTransient(type.type);
        }

        IServiceProvider serviceProvider = Container.BuildServiceProvider();
        appRunner.UseMicrosoftDependencyInjection(serviceProvider);
    }
}