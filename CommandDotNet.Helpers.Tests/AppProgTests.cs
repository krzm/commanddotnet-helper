using System;
using CommandDotNet.Helper;
using CommandDotNet.Unity.Helper;
using Config.Wrapper;
using Moq;
using Serilog.Wrapper;
using Unity;
using Xunit;

namespace CommandDotNet.Helpers.Tests;

public class AppProgTests
{
    [Theory]
    [MemberData(
        nameof(AppProgTestDataGenerator.GetTestData)
        , MemberType = typeof(AppProgTestDataGenerator))]
    public void Test_AppProg_Output_On_SetConfig(
        AppProgTestData data)
    {
        var logMock = new LoggerMock();
        var configMock = SetupConfigMock(data.ConfigOk, data.UseRepl);
        var sut = new AppProgUnityTest<TestCommand>(
            logMock
            , configMock.Object);

        if(data.SetDIContainer) 
            sut.SetDIContainer(new Mock<IUnityContainer>().Object);
        sut.Setup();
        if(data.RunMain) 
            sut.Main(Array.Empty<string>());

        Assert.Equal(data.ExpectedOutput, logMock.Lines);
    }

    private static Mock<IConfigReader> SetupConfigMock(
        bool configOk
        , bool useRepl)
    {
        var configMock = new Mock<IConfigReader>();
        configMock.Setup(c =>
            c.GetConfigSection<CommandDotNetSettings>(
                nameof(CommandDotNetSettings)))
                    .Returns(
                        configOk ? new CommandDotNetSettings
                        {
                            UseRepl = useRepl
                        } : null);
        return configMock;
    }
}