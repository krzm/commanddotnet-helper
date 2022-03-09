using CLIHelper;
using Config.Wrapper;

namespace CommandDotNet.Helper;

public abstract class AppProgConfig<TContainer>
    : AppProgIoC<TContainer>
{
    protected AppProgConfig(
        IOutput output) 
            : base(output)
    {
    }

    public IConfigWrapper? Config { get; set; }

    protected CommandDotNetSettings?  Settings { get; set; }

    protected override void SetConfig()
    {
        try
        {
            ArgumentNullException.ThrowIfNull(Config);
            Settings = Config.GetConfigSection<CommandDotNetSettings>(nameof(CommandDotNetSettings));
        }
        catch (ArgumentNullException anex)
        {
            if (anex.ParamName == nameof(Config))
                Output.Log("App Config dependency not registered");
        }
    }
}