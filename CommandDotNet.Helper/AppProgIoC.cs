using CLIHelper;

namespace CommandDotNet.Helper;

public abstract class AppProgIoC<TContainer>
    : AppProgTMethod
{
    protected AppProgIoC(
        IOutput output) 
            : base(output)
    {
    }

    public abstract void SetDIContainer(TContainer container);
}