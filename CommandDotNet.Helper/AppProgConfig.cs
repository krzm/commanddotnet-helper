using Microsoft.Extensions.Configuration;

namespace CommandDotNet.Helper;

public abstract class AppProgConfig<TContainer>
    : AppProgIoC<TContainer>
{
    protected CommandDotNetSettings?  Settings { get; set; }

    public AppProgConfig(
        TContainer container) 
            : base(container)
    {
    }

    protected override void SetConfig()
    {
        Settings = SetCommandDotNetConfig();
    }

    private CommandDotNetSettings? SetCommandDotNetConfig()
    {
        try
        {
            return ResolveConfig()
                .GetRequiredSection("CommandDotNetSettings")
                    .Get<CommandDotNetSettings>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex}");
            return default;
        }
    }

    protected abstract IConfiguration? ResolveConfig();

    protected override bool SkipCmdsReg()
    {
        ArgumentNullException.ThrowIfNull(Settings);
        return Settings.SkipCmdsReg;
    }
}