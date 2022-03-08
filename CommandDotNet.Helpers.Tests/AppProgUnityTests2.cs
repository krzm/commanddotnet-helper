using System;
using CLIHelper;
using CommandDotNet.Helper;
using CommandDotNet.Unity.Helper;
using Microsoft.Extensions.Configuration;
using Moq;
using Unity;
using Xunit;

namespace CommandDotNet.Helpers.Tests;

//todo: IConfiguration needs wrapper to mock method
// public partial class AppProgUnityTests2
// {
//     [Theory]
//     [InlineData(new object[] { new string[]
//     {
//         "--> AppRunner created"
//         , "--> UnityContainer set in AppRunner"
//         , "--> Main"
//         , "--> SetConfig"
//         , "--> App Configuration dependency not registered"
//         , "--> SetAppRunner"
//         , "--> AppRunner on default settings"
//         , "--> Run"
//         , "--> Run in test mode"
//         , "--> Usage: testhost.exe [options]"
//         , ""
//         , "Options:"
//         , ""
//         , "  -v | --version"
//         , "  Show version information"
//         , ""
//     }})]
//     public void Test_Output_Expected_From_Default_AppProg_When_Configuration_Set(
//         string[] expectedOutput
//     )
//     {
//         IMockOut mockOut = new MockOut();
//         var containerMock = new Mock<IUnityContainer>();
//         var configurationMock = new Mock<IConfiguration>();
//         configurationMock.Setup(c => 
//             c.GetRequiredSection("CommandDotNetSettings")
//                 .Get<CommandDotNetSettings>()).Returns(
//                     new CommandDotNetSettings
//                     {
//                         UseRepl = true
//                     });
//         var sut = new AppProgUnityTest<TestCommand>(
//             mockOut);

//         sut.SetDIContainer(containerMock.Object);
//         sut.Configuration = configurationMock.Object;
//         sut.Main(Array.Empty<string>());

//         Assert.Equal(expectedOutput, mockOut.Lines);
//     }
// }