using System;
using CLIHelper;
using CommandDotNet.Helper;
using CommandDotNet.Unity.Helper;
using Config.Wrapper;
using Moq;
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
        var mockOut = GetMockOut();
        var sut = new AppProgUnityTest<TestCommand>(
            mockOut);

        if(data.SetDIContainer) 
            sut.SetDIContainer(new Mock<IUnityContainer>().Object);
        if(data.SetConfig) 
            sut.Config = SetupConfigMock(data.UseRepl).Object;
        if(data.RunMain) 
            sut.Main(Array.Empty<string>());

        Assert.Equal(data.ExpectedOutput, mockOut.Lines);
    }

    private static IMockOut GetMockOut() =>
        new MockOut();

    private static Mock<IConfigWrapper> SetupConfigMock(
        bool useRepl)
    {
        var configMock = new Mock<IConfigWrapper>();
        configMock.Setup(c =>
            c.GetConfigSection<CommandDotNetSettings>(
                nameof(CommandDotNetSettings)))
                    .Returns(new CommandDotNetSettings
                        {
                            UseRepl = useRepl
                        });
        return configMock;
    }
}