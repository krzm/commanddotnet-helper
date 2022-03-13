using Serilog;

namespace CommandDotNet.Helper;

public abstract class AppProgLogger
{
    protected readonly ILogger Log;

    protected AppProgLogger(
        ILogger log)
    {
        Log = log;
    }
}