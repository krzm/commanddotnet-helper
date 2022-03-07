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
            return Configuration
                .GetRequiredSection("CommandDotNetSettings")
                    .Get<CommandDotNetSettings>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex}");
            return default;
        }
    }
}