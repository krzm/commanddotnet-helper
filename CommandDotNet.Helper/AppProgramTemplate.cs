using DIHelper;

namespace CommandDotNet.Helper;

public abstract class AppProgramTemplate<TContainer, TRootCommand, TAppRunner>
    : IAppProgram
        where TRootCommand : class
{
    protected readonly TContainer Container;

    public AppProgramTemplate(
        TContainer container)
    {
        Container = container;
    }

    public int Main(string[] args)
    {
        SetAppRunner();
        SetDIContainer();
        return Run(args);
    }

    protected abstract void SetAppRunner();

    protected abstract void SetDIContainer();
    
    protected abstract int Run(string[] args);
}