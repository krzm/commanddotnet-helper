using System;
using CLIHelper;
using CommandDotNet.Unity.Helper;
using Moq;
using Xunit;

namespace CommandDotNet.Helpers.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        IOutputLog log = new OutputLog();
        var sut = new AppProgUnityTest<TestCommand>(
            log);

        sut.Main(Array.Empty<string>());

        ArgumentNullException.ThrowIfNull(sut.AppRunnerResult);
        log.StringBuilder.Append(sut.AppRunnerResult.Console.AllText());
        var temp = log.StringBuilder.ToString();
    }
}