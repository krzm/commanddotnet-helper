using CommandDotNet.NameCasing;
using CommandDotNet.DataAnnotations;
using CommandDotNet.Repl;
using Serilog;
using Config.Wrapper;

namespace CommandDotNet.Helper;

public abstract class AppProgRunner<TContainer, TRootCommand> 
    : AppProgConfig<TContainer>
        where TRootCommand : class
{
    private readonly AppRunner appRunner;

    public AppRunner AppRunner => appRunner;

    protected AppProgRunner(
        ILogger log
        , IConfigReader config) 
            : base(log, config)
    {
        appRunner = new AppRunner<TRootCommand>();
        Log.Verbose("AppRunner created");
    }

    protected override void SetAppRunner()
    {
        SetDefaults();
        if(Settings == null) 
        {
            appRunner.UseRepl();
            Log.Verbose("AppRunner on default settings");
            return;
        }
        if(Settings.UseRepl)
        {
            appRunner.UseRepl();
            Log.Verbose("REPL mode on");
        }
    }

    private void SetDefaults()
    {
        appRunner
            .UseDefaultMiddleware()
            .UseNameCasing(Case.LowerCase)
            .UseDataAnnotationValidations();
    }
    
    protected override int Run(string[] args) => 
        appRunner.Run(args);
}