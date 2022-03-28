using DIHelper;
using DIHelper.MicrosoftDI;
using Microsoft.Extensions.DependencyInjection;

namespace CommandDotNet.MDI.Helper;

public class AppProgSet<TAppProg>
    : MDIDependencySet
        where TAppProg 
            : class
            , IAppProgram 
{
    public AppProgSet(
        IServiceCollection container) 
            : base(container)
    {
    }

    public override void Register()
    {
        Container.AddSingleton<IAppProgram, TAppProg>();
        var serviceProvider = Container.BuildServiceProvider();
        var appProgRef = serviceProvider.GetService<IAppProgram>();
        ArgumentNullException.ThrowIfNull(appProgRef);
        var appProg = (AppProgMDI<TAppProg>)appProgRef;
        appProg.SetDIContainer(Container);
    }
}