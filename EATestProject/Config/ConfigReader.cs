using System;
using EAAutoFramework.Base;
using EAAutoFramework.ConfigElement;
using EAAutoFramework.Helpers;

namespace EAAutoFramework.Config
{
    public class ConfigReader
    {
        public static void SetFrameworkSettings()
        {
           

                Settings.AUT = EATestConfiguration.EASettings.TestSettings["staging"].AUT;
                //Settings.BuildName = buildname.Value.ToString();
                Settings.TestType = EATestConfiguration.EASettings.TestSettings["staging"].TestType;
                Settings.IsLog = EATestConfiguration.EASettings.TestSettings["staging"].IsLog;
                //Settings.IsReporting = EATestConfiguration.EASettings.TestSettings["staging"].IsReadOnly;
                Settings.LogPath = EATestConfiguration.EASettings.TestSettings["staging"].LogPath;
                Settings.AppConnectionString = EATestConfiguration.EASettings.TestSettings["staging"].AUTDBConnectionString;
                Settings.BrowserType = (BrowserType)Enum.Parse(typeof(BrowserType), EATestConfiguration.EASettings.TestSettings["staging"].Browser);
                if (EATestConfiguration.EASettings.TestSettings["staging"].AzurePipeline.CompareTo("Y") == 0)
                {
                Settings.Key = Environment.GetEnvironmentVariable("key");
                Console.WriteLine("------------------------" + Settings.Key + " ++++++++++++++++++++++++++++++");
                

                 }
            else
                    Settings.Key = EATestConfiguration.EASettings.TestSettings["staging"].Key;
                if (!EATestConfiguration.EASettings.TestSettings["staging"].Plataforma.Contains("Windows"))
                {
                     Settings.LogPath = "/EAAutoLogs/";
                }

                









        }

    }
}
