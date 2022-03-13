namespace CommandDotNet.Helpers.Tests;

public class AppProgTestData
{
    public bool SetDIContainer { get; set; }

    public bool ConfigOk { get; set; }

    public bool UseRepl { get; set; }

    public bool RunMain { get; set; }

    public string[]? ExpectedOutput { get; set; }
}