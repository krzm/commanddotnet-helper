using CLIHelper;

namespace CommandDotNet.Helper;

public abstract class AppProgTMethod
    : IAppProgram
{
    protected readonly IOutput Output;

    protected AppProgTMethod(
        IOutput output)
    {
        Output = output;
    }

    public int Main(string[] args)
    {
        Output.Log(nameof(Main));
        Setup();
        Output.Log(nameof(Run));
        return Run(args);
    }

    private void Setup()
    {
        Output.Log(nameof(SetConfig));
        SetConfig();
        Output.Log(nameof(SetAppRunner));
        SetAppRunner();
    }

    protected abstract void SetConfig();
    
    protected abstract void SetAppRunner();
   
    protected abstract int Run(string[] args);
}