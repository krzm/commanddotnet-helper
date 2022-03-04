using CommandDotNet.Helper;
using CommandDotNet.IoC.MicrosoftDependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CommandDotNet.MDI.Helper;

public class AppProgMDI<TRootCommand> 
    : AppProgCmds<IServiceCollection, TRootCommand>
    where TRootCommand : class
{
    private IServiceProvider? serviceProvider;

    public AppProgMDI(
        IServiceCollection services) 
            : base(services)
    {
    }

    protected override void SetDIContainer()
    {
        serviceProvider = Container.BuildServiceProvider();
        AppRunner.UseMicrosoftDependencyInjection(serviceProvider);
    }

    protected override void RegisterCmd(Type type) =>
        Container.AddTransient(type);

    protected override IConfiguration? ResolveConfig()
    {
        if(serviceProvider == null) 
            throw new NullReferenceException(nameof(serviceProvider));
        return serviceProvider.GetService<IConfiguration>();
    }
}