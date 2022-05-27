using DIHelper;
using Serilog;

namespace CommandDotNet.Helper;

public abstract class AppProgTMethod
    : AppProgLogger 
    , IAppProgram
{
    protected AppProgTMethod(
        ILogger log)
        : base(log)
    { 
    }

    public int Main(string[] args)
    {
        Log.Verbose(nameof(Main));
        Log.Verbose(nameof(Run));
        return Run(args);
    }

    public void Setup()
    {
        Log.Verbose(nameof(SetConfig));
        SetConfig();
        Log.Verbose(nameof(SetAppRunner));
        SetAppRunner();
    }

    protected abstract void SetConfig();
    
    protected abstract void SetAppRunner();
   
    protected abstract int Run(string[] args);
}