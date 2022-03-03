using CommandDotNet.NameCasing;
using CommandDotNet.DataAnnotations;
using CommandDotNet.Repl;

namespace CommandDotNet.Helper;

public abstract class AppProgram<TContainer, TRootCommand> 
    : AppProgramTemplate<TContainer, TRootCommand, AppRunner>
        where TRootCommand : class
{
    private readonly AppRunner appRunner;

    protected AppRunner AppRunner => appRunner;

    public AppProgram(TContainer container) 
        : base(container)
    {
        appRunner = new AppRunner<TRootCommand>();
    }

    protected override void SetAppRunner()
    {
        var config = SetCommandDotNetConfig();
        SetDefaults();
        if(config == null) return;
        if(config.UseRepl)
            appRunner.UseRepl();
    }

    protected abstract CommandDotNetSettings? SetCommandDotNetConfig();

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