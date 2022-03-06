using CommandDotNet.Unity.Helper;
using Xunit;

namespace CommandDotNetHelper.Tests;

public class UnitTestAppProgUnity
{
    [Fact]
    public void Test1()
    {
        var sut = new AppProgUnity<TestCommand>();
    }
}