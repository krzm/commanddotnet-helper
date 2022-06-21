using CommandDotNet.TestTools;
using Config.Wrapper;
using Serilog;

namespace CommandDotNet.Unity.Helper;

public class AppProgUnityTest<TRootCommand>
    : AppProgUnity<TRootCommand>
        where TRootCommand : class
{
    public AppProgUnityTest(
        ILogger log
        , IConfigReader config) 
            : base(log, config)
    {
    }

    public AppRunnerResult? AppRunnerResult { get; set; }

    protected override int Run(string[] args)
    {
        Log.Information("Run in test mode");
        AppRunnerResult = AppRunner.RunInMem(args);
        var text = AppRunnerResult.Console.AllText();
        ArgumentNullException.ThrowIfNull(text);
        Log.Information(text);
        return AppRunnerResult.ExitCode;
    }
}