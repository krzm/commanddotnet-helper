using CLIHelper;
using CommandDotNet.TestTools;

namespace CommandDotNet.Unity.Helper;

public class AppProgUnityTest<TRootCommand>
    : AppProgUnity<TRootCommand>
        where TRootCommand : class
{
    public AppProgUnityTest(
        IOutput output) 
            : base(output)
    {
    }

    public AppRunnerResult? AppRunnerResult { get; set; }

    protected override int Run(string[] args)
    {
        Output.Log("Run in test mode");
        AppRunnerResult = AppRunner.RunInMem(args);
        Output.Log(AppRunnerResult.Console.AllText());
        return AppRunnerResult.ExitCode;
    }
}