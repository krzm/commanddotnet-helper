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
        AppRunnerResult = AppRunner.RunInMem(args);
        return AppRunnerResult.ExitCode;
    }
}