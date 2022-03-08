using CommandDotNet.NameCasing;
using CommandDotNet.DataAnnotations;
using CommandDotNet.Repl;
using CLIHelper;

namespace CommandDotNet.Helper;

public abstract class AppProgRunner<TContainer, TRootCommand> 
    : AppProgConfig<TContainer>
        where TRootCommand : class
{
    private readonly AppRunner appRunner;

    public AppRunner AppRunner => appRunner;

    protected AppProgRunner(
        IOutput output) 
            : base(output)
    {
        appRunner = new AppRunner<TRootCommand>();
        Output.Log("AppRunner created");
    }

    protected override void SetAppRunner()
    {
        SetDefaults();
        if(Settings == null) 
        {
            appRunner.UseRepl();
            Output.Log("AppRunner on default settings");
            return;
        }
        if(Settings.UseRepl)
        {
            appRunner.UseRepl();
            Output.Log("REPL mode on");
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