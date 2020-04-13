using EAAutoFramework.Base;
using EAAutoFramework.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;

namespace EAAutoFramework.Pages
{
    class ExtendPage : BasePage
    {

        public readonly WebDriverWait _wait;     

        public ExtendPage(ParallelConfig parallelConfig) : base(parallelConfig)
        {

              _wait = new WebDriverWait(_parallelConfig.Driver, TimeSpan.FromSeconds(60));

        }         
        public void SeleccionarVentantaActual(int ventanaActiva)
        {

            ReadOnlyCollection<string> myWindowHandles = _parallelConfig.Driver.WindowHandles;
            _parallelConfig.Driver.SwitchTo().Window(myWindowHandles[ventanaActiva]);
            System.Console.WriteLine(_parallelConfig.Driver.PageSource);

        }
        public void WaitForAlert()
        {

         _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());

        }
        public void SeleccionarIframeById(string id)
        {

            _parallelConfig.Driver.SwitchTo().Frame(id);

        }
        public IWebElement CheckForElementContentWithVisibleText(string text)
        {

            IWebElement Element = _parallelConfig.Driver.FindByXpath("//td[text()='" + text + "']");
            return Element;           

        }

        public void clickTabPageEtiquetas(string tab)
        {    
           
            _parallelConfig.Driver.FindByLinkText(tab).Click();
           
        }

        public IWebElement ReturnByTagElement(string tag)
        {

            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.TagName(tag)));
            IWebElement Element = _parallelConfig.Driver.FindElementByTagName(tag);
            return Element;

        }


        public IWebElement ReturnByXpathTextAndTag(string textXpath, string tag)
        {

            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//" + tag + "[text()[contains(.,'"+ textXpath + "')]]")));
            IWebElement Element = _parallelConfig.Driver.FindByXpath("//" + tag + "[text()[contains(.,'" + textXpath + "')]]");
            return Element;

        }

    }
}
