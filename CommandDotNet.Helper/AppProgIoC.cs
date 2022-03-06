namespace CommandDotNet.Helper;

public abstract class AppProgIoC<TContainer>
    : AppProgTMethod
{
    public abstract void SetDIContainer(TContainer container);
}