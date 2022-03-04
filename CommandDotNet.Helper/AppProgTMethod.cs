using DIHelper;
using Microsoft.Extensions.Configuration;

namespace CommandDotNet.Helper;

public abstract class AppProgTMethod
//todo: IAppProgram prolly shoudnt be in lib with unity, becouse this Helper shoudnt have unity refs
    : IAppProgram
{
    public int Main(string[] args)
    {
        SetConfig();
        SetAppRunner();
        if(SkipCmdsReg() == false)
            RegisterCommandClasses();
        SetDIContainer();
        return Run(args);
    }

    protected abstract void SetConfig();
    
    protected abstract void SetAppRunner();

    protected abstract bool SkipCmdsReg();

    protected abstract void RegisterCommandClasses();

    protected abstract void SetDIContainer();
    
    protected abstract int Run(string[] args);
}