using EAAutoFramework.Config;
using EAAutoFramework.Helpers;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Remote;
using System;
using OpenQA.Selenium.Edge;

namespace EAAutoFramework.Base
{
    public class TestInitializeHook : Steps
    {

        private readonly ParallelConfig _parallelConfig;


        public TestInitializeHook(ParallelConfig parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }

        public void InitializeSettings()
        {
            ConfigReader.SetFrameworkSettings();
            OpenBrowser(Settings.BrowserType);
        }

        private void OpenBrowser(BrowserType browserType = BrowserType.FireFox)
        {          
           
            switch (browserType)
            {
                case BrowserType.InternetExplorer:
                  
                    InternetExplorerOptions internetExplorerOption = new InternetExplorerOptions();

                    _parallelConfig.Driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), internetExplorerOption);
            
                    break;

                case BrowserType.FireFox:

                     FirefoxOptions fireFoxOption = new FirefoxOptions();
                   //  fireFoxOption.AddArguments("start-maximized");
                    _parallelConfig.Driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), fireFoxOption);
                
                    break;

                case BrowserType.Chrome:

                    ChromeOptions chromeOption = new ChromeOptions();
                    chromeOption.AddArguments("start-maximized");
                    _parallelConfig.Driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), chromeOption);
             
                    break;

                case BrowserType.Edge:
     
                    EdgeOptions edgeOption = new EdgeOptions();
                    _parallelConfig.Driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), edgeOption);

                    break;

            }

        }      

    }
}
