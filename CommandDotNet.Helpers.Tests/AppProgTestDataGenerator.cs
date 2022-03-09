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
                , SetConfig = false
                , UseRepl = false
                , RunMain = false
            })
        };

        yield return new object[]
        {
            SetOutput(new AppProgTestData 
            {
                SetDIContainer = false
                , SetConfig = false
                , UseRepl = false
                , RunMain = true
            })
        };

        yield return new object[]
        {
            SetOutput(new AppProgTestData 
            {
                SetDIContainer = true
                , SetConfig = false
                , UseRepl = false
                , RunMain = true
            })
        };

        yield return new object[]
        {
            SetOutput(new AppProgTestData 
            {
                SetDIContainer = true
                , SetConfig = true
                , UseRepl = false
                , RunMain = true   
            })
        };

        yield return new object[]
        {
            SetOutput(new AppProgTestData 
            {
                SetDIContainer = true
                , SetConfig = true
                , UseRepl = true
                , RunMain = true    
            })
        };
    }

    private static AppProgTestData SetOutput(
        AppProgTestData data)
    {
        var l = new List<string>();
            l.Add("--> AppRunner created");
        if(data.SetDIContainer)
            l.Add("--> UnityContainer set in AppRunner");
        if(data.RunMain)
        {
            l.Add("--> Main");
            l.Add("--> SetConfig");
            if (data.SetConfig == false)
                l.Add("--> App Config dependency not registered");
            l.Add("--> SetAppRunner");
            if (data.SetConfig == false)
                l.Add("--> AppRunner on default settings");
            if (data.SetConfig && data.UseRepl)
                l.Add("--> REPL mode on");
            l.Add("--> Run");
            l.Add("--> Run in test mode");
            GetCommandDotNetDefaultText(l);
        }
        l.Add("");
        data.ExpectedOutput = l.ToArray();
        return data;
    }

    private static void GetCommandDotNetDefaultText(List<string> l)
    {
        l.Add("--> Usage: testhost.exe [options]");
        l.Add("");
        l.Add("Options:");
        l.Add("");
        l.Add("  -v | --version");
        l.Add("  Show version information");
    }
}