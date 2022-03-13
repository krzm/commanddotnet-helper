using Config.Wrapper;
using Serilog;

namespace CommandDotNet.Helper;

public abstract class AppProgConfig<TContainer>
    : AppProgIoC<TContainer>
{
    private readonly IConfigReader config;

    protected AppProgConfig(
        ILogger log
        , IConfigReader config) 
            : base(log)
    {
        this.config = config;
        ArgumentNullException.ThrowIfNull(this.config);
    }

    protected CommandDotNetSettings?  Settings { get; set; }

    protected override void SetConfig()
    {
        try
        {
            Settings = config.GetConfigSection<CommandDotNetSettings>(nameof(CommandDotNetSettings));
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Config error");
        }
    }
}