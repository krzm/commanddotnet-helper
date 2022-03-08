using CLIHelper;
using Microsoft.Extensions.Configuration;

namespace CommandDotNet.Helper;

public abstract class AppProgConfig<TContainer>
    : AppProgIoC<TContainer>
{
    protected AppProgConfig(
        IOutput output) 
            : base(output)
    {
    }

    public IConfiguration? Configuration { get; set; }

    protected CommandDotNetSettings?  Settings { get; set; }

    protected override void SetConfig()
    {
        Settings = SetCommandDotNetConfig();
    }

    private CommandDotNetSettings? SetCommandDotNetConfig()
    {
        try
        {
            ArgumentNullException.ThrowIfNull(Configuration);
            return Configuration
                .GetRequiredSection("CommandDotNetSettings")
                    .Get<CommandDotNetSettings>();
        }
        catch (ArgumentNullException anex)
        {
            if(anex.ParamName == nameof(Configuration))
                Output.Log("App Configuration dependency not registered");
        }
        catch (Exception ex)
        {
            Output.Log(ex.Message);
        }
        return default;
    }
}