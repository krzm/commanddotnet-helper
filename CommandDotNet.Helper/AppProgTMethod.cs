using DIHelper;

namespace CommandDotNet.Helper;

public abstract class AppProgTMethod
//todo: IAppProgram prolly shoudnt be in lib with unity, becouse this Helper shoudnt have unity refs
    : IAppProgram
{
    public int Main(string[] args)
    {
        Setup();
        return Run(args);
    }

    private void Setup()
    {
        SetConfig();
        SetAppRunner();
    }

    protected abstract void SetConfig();
    
    protected abstract void SetAppRunner();
   
    protected abstract int Run(string[] args);
}