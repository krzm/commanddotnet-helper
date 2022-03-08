using System;
using CLIHelper;
using CommandDotNet.Unity.Helper;
using Moq;
using Unity;
using Xunit;

namespace CommandDotNet.Helpers.Tests;

public partial class AppProgUnityTests
{
    [Theory]
    [InlineData(new object[] { new string[]
    {
        "--> AppRunner created"
        , "--> Main"
        , "--> SetConfig"
        , "--> App Configuration dependency not registered"
        , "--> SetAppRunner"
        , "--> AppRunner on default settings"
        , "--> Run"
        , "--> Run in test mode"
        , "--> Usage: testhost.exe [options]"
        , ""
        , "Options:"
        , ""
        , "  -v | --version"
        , "  Show version information"
        , ""
    }})]
    public void Test_Output_Expected_From_Default_AppProg(
        string[] expectedOutput
    )
    {
        IMockOut mockOut = new MockOut();
        var sut = new AppProgUnityTest<TestCommand>(
            mockOut);

        sut.Main(Array.Empty<string>());

        Assert.Equal(expectedOutput, mockOut.Lines);
    }

    [Theory]
    [InlineData(new object[] { new string[]
    {
        "--> AppRunner created"
        , "--> UnityContainer set in AppRunner"
        , "--> Main"
        , "--> SetConfig"
        , "--> App Configuration dependency not registered"
        , "--> SetAppRunner"
        , "--> AppRunner on default settings"
        , "--> Run"
        , "--> Run in test mode"
        , "--> Usage: testhost.exe [options]"
        , ""
        , "Options:"
        , ""
        , "  -v | --version"
        , "  Show version information"
        , ""
    }})]
    public void Test_Output_Expected_From_Default_AppProg_When_UnityContainer_Set(
        string[] expectedOutput
    )
    {
        IMockOut mockOut = new MockOut();
        var sut = new AppProgUnityTest<TestCommand>(
            mockOut);

        sut.SetDIContainer(new Mock<IUnityContainer>().Object);
        sut.Main(Array.Empty<string>());

        Assert.Equal(expectedOutput, mockOut.Lines);
    }
}