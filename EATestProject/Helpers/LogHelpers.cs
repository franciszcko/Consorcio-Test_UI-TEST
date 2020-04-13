using EAAutoFramework.Config;
using EAAutoFramework.ConfigElement;
using Palmer;
using System;
using System.IO;
using System.Security.AccessControl;

namespace EAAutoFramework.Helpers
{
    public class LogHelpers
    {
        //Global Declaration

        public LogHelpers() { }

      
        //Create a file which can store the log information
        public static void CreateLogFile(string feature, string scenario)
        {
            string dir = Settings.LogPath;
            string logFile = $"{dir}[Feature] {feature} [Scenario] {scenario}.log";
            if (!Directory.Exists(dir))
            {

        //        if (EATestConfiguration.EASettings.TestSettings["staging"].AzurePipeline.CompareTo("Y") == 0)
        //        {
        //            DirectorySecurity securityRules = new DirectorySecurity();
        //            securityRules.AddAccessRule(new FileSystemAccessRule(@"sag.cl\francisco.cleverit", FileSystemRights.FullControl, AccessControlType.Allow));
         //       }
                   
                Settings.FileCreated = true;
                Directory.CreateDirectory(dir);
            }

            if (!File.Exists(logFile))
            {
                var file = File.Create(logFile);
                file.Close();
            }
        }

        //Create a method which can write the text in the log file
        public static void Write(string logMessage)
        {
            string dir = Settings.LogPath;
            string path = $"{dir}Exceptions.log";
            if (!File.Exists(path))
            {
                var file = File.Create(path);
                file.Close(); 
            }
            if (File.Exists(path))
            {
                Retry.On<IOException>().For(TimeSpan.FromSeconds(30)).With(context =>
                {
                    File.AppendAllText(path, DateTime.Now.ToLongTimeString() + " " + DateTime.Now.ToLongDateString() + ": " + logMessage + "\n");
                });
            }
        }
        public static void WriteSteps(string logMessage,string feature, string scenario)
        {
            string dir = Settings.LogPath;
            string path = $"{dir}[Feature] {feature} [Scenario] {scenario}.log";
            if (File.Exists(path))
            {
                Retry.On<IOException>().For(TimeSpan.FromSeconds(30)).With(context =>
                {
                    File.AppendAllText(path, DateTime.Now.ToLongTimeString() + " " + DateTime.Now.ToLongDateString() + ": " + logMessage + "\n");
                });
            }
        }
    }
}