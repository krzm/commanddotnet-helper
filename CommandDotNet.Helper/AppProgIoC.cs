using Serilog;

namespace CommandDotNet.Helper;

public abstract class AppProgIoC<TContainer>
    : AppProgTMethod
{
    protected AppProgIoC(
        ILogger log) 
            : base(log)
    {
    }
}