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
    }
}