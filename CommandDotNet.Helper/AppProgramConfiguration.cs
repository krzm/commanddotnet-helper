using Microsoft.Extensions.Configuration;

namespace CommandDotNet.Helper;

public abstract class AppProgramConfiguration<TContainer, TRootCommand> 
    : AppProgram<TContainer, TRootCommand>
        where TRootCommand : class
{
    public AppProgramConfiguration(
        TContainer container) 
            : base(container)
    {
    }

    protected override CommandDotNetSettings? SetCommandDotNetConfig()
    {
        CommandDotNetSettings? settings = default;
        try
        {
            var config = ResolveConfig();
            settings = config.GetRequiredSection("CommandDotNetSettings")
                .Get<CommandDotNetSettings>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Config error: {ex.Message}");
        }
        return settings;
    }

    protected abstract IConfiguration? ResolveConfig();
}