using CommandDotNet.NameCasing;
using CommandDotNet.DataAnnotations;
using CommandDotNet.Repl;

namespace CommandDotNet.Helper;

public abstract class AppProgRunner<TContainer, TRootCommand> 
    : AppProgConfig<TContainer>
        where TRootCommand : class
{
    private readonly AppRunner appRunner;

    protected AppRunner AppRunner => appRunner;

    public AppProgRunner(TContainer container) 
        : base(container)
    {
        appRunner = new AppRunner<TRootCommand>();
    }

    protected override void SetAppRunner()
    {
        SetDefaults();
        if(Settings == null) 
        {
            //todo: to logs
            Console.WriteLine("CommandDotNet on default settings");
            return;
        }
        if(Settings.UseRepl)
            appRunner.UseRepl();
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