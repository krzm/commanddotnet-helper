using DIHelper;
using DIHelper.Unity;
using Unity;

namespace CommandDotNet.Unity.Helper;

public class AppProgSet<TAppProg>
    : UnityDependencySet
        where TAppProg 
            : class
            , IAppProgram 
{
    public AppProgSet(
        IUnityContainer container) 
        : base(container)
    {
    }

    public override void Register()
    {
        Container.RegisterSingleton<IAppProgram, TAppProg>();
        var appProg = (AppProgUnity<TAppProg>)Container.Resolve<IAppProgram>();
        appProg.RegisterCommandClasses(Container);
        appProg.SetDIContainer(Container);
    }
}