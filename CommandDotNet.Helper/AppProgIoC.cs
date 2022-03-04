namespace CommandDotNet.Helper;

public abstract class AppProgIoC<TContainer>
    : AppProgTMethod
{
    protected readonly TContainer Container;

    public AppProgIoC(
        TContainer container)
    {
        Container = container;
    }
}