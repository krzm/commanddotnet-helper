using CommandDotNet.DataAnnotations;
using CommandDotNet.Diagnostics;
using CommandDotNet.NameCasing;
using CommandDotNet.Repl;
using DIHelper;

namespace CommandDotNet.Helper;

public abstract class AppProgram<TContainer, TRootCommand>
    : IAppProgram
        where TRootCommand : class
{
    protected readonly TContainer Container;

    public AppProgram(
        TContainer container)
    {
        Container = container;
    }

    public int Main(string[] args)
    {
        Debugger.AttachIfDebugDirective(args);
        var appRunner = SetAppRunner();
        SetDIContainer(appRunner);
        return appRunner.Run(args);
    }

    protected abstract void SetDIContainer(AppRunner appRunner);

    protected virtual AppRunner SetAppRunner()
    {
        return new AppRunner<TRootCommand>()
            .UseDefaultMiddleware()
            .UseNameCasing(Case.LowerCase)
            .UseDataAnnotationValidations()
            .UseRepl();
    }
}