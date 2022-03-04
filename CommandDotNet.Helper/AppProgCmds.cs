namespace CommandDotNet.Helper;

public abstract class AppProgCmds<TContainer, TRootCommand>
    : AppProgRunner<TContainer, TRootCommand>
        where TRootCommand : class
{
    protected Type[]? CmdsSkipAutoReg { get; set; }

    protected AppProgCmds(
        TContainer container)
            : base(container)
    {
    }

    protected override void RegisterCommandClasses()
    {
        var cmds = AppRunner.GetCommandClassTypes();
        foreach (var cmd in cmds)
        {
            if(CmdsSkipAutoReg != null 
                && CmdsSkipAutoReg.Contains(cmd.type))
                continue;
            RegisterCmd(cmd.type);
        }
    }

    protected abstract void RegisterCmd(Type type);
}