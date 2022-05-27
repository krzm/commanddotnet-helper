using System.Collections.Generic;

namespace CommandDotNet.Helpers.Tests;

public class AppProgTestDataGenerator
{
    public static IEnumerable<object[]> GetTestData()
    {
        yield return new object[]
        {
            SetOutput(new AppProgTestData 
            {
                SetDIContainer = false
                , ConfigOk = false
                , UseRepl = false
                , RunMain = false
            })
        };

        yield return new object[]
        {
            SetOutput(new AppProgTestData 
            {
                SetDIContainer = false
                , ConfigOk = false
                , UseRepl = false
                , RunMain = true
            })
        };

        yield return new object[]
        {
            SetOutput(new AppProgTestData 
            {
                SetDIContainer = true
                , ConfigOk = false
                , UseRepl = false
                , RunMain = true
            })
        };

        yield return new object[]
        {
            SetOutput(new AppProgTestData 
            {
                SetDIContainer = true
                , ConfigOk = true
                , UseRepl = false
                , RunMain = true   
            })
        };

        yield return new object[]
        {
            SetOutput(new AppProgTestData 
            {
                SetDIContainer = true
                , ConfigOk = true
                , UseRepl = true
                , RunMain = true    
            })
        };
    }

    private static AppProgTestData SetOutput(
        AppProgTestData data)
    {
        var l = new List<string>();
        l.Add("AppRunner created");
        if (data.SetDIContainer)
            l.Add("UnityContainer set in AppRunner");
        AddSetupMethod(data, l);
        if (data.RunMain)
        {
            l.Add("Main");
            l.Add("Run");
            l.Add("Run in test mode");
            GetCommandDotNetDefaultText(l);
        }
        l.Add("");
        data.ExpectedOutput = l.ToArray();
        return data;
    }

    private static void AddSetupMethod(AppProgTestData data, List<string> l)
    {
        l.Add("SetConfig");
        l.Add("SetAppRunner");
        if (data.ConfigOk == false)
            l.Add("AppRunner on default settings");
        if (data.ConfigOk && data.UseRepl)
            l.Add("REPL mode on");
    }

    private static void GetCommandDotNetDefaultText(List<string> l)
    {
        l.Add("Usage: testhost.exe [options]");
        l.Add("");
        l.Add("Options:");
        l.Add("");
        l.Add("  -v | --version");
        l.Add("  Show version information");
    }
}