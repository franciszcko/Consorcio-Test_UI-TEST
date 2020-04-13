using EAAutoFramework.Base;
using EAAutoFramework.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EAAutoFramework.Extensions
{
    public static class WebElementExtensions
    {

 

        public static string GetSelectedDropDown(this IWebElement element)
        {
            SelectElement ddl = new SelectElement(element);
            return ddl.AllSelectedOptions.First().ToString();
        }

        public static IList<IWebElement> GetSelectedListOptions(this IWebElement element)
        {
            SelectElement ddl = new SelectElement(element);
            return ddl.AllSelectedOptions;
        }

        public static string GetLinkText(this IWebElement element)
        {
            return element.Text;
        }


        public static void SelectDropDownList(this IWebElement element, string value)
        {
            SelectElement ddl = new SelectElement(element);
            ddl.SelectByText(value);
        }

        
        public static void Hover(this IWebElement element, IWebDriver driver)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Perform();
        }

        public static void AssertElementPresent(this IWebElement element)
        {
            if (!IsElementPresent(element)) 
            {

                Assert.IsTrue(!IsElementPresent(element));
                throw new Exception(string.Format("Element Not Present exception"));
             
            }
                
        }

        public static bool IsElementPresent(this IWebElement element)
        {
            try
            {
                bool ele = element.Displayed;
                
                return true;
            }
            catch (Exception e)
            {
                LogHelpers.Write("Exception: " + e.InnerException);
                LogHelpers.Write("Message: " + e.Message);
                LogHelpers.Write("Traza: " + e.StackTrace);
                return false;
            }
        }

        public static void AssertIsTextPresent(this IWebElement element, string text)
        {
            if (!IsTextPresent(element, text))
            {

                Assert.IsTrue(!IsTextPresent(element, text));
                LogHelpers.Write(("Text Not Present exception" + "searched text: " + text + " found text: " + element.Text));
                throw new Exception(string.Format("Text Not Present exception"));
                
            }
        }

        public static bool IsTextPresent(this IWebElement element, string text)
        {

            try
            {
                if (element.Text.Contains(text))
                {

                    return true;

                }
                else
                {

                    return false;

                }

            }
            catch (Exception e)
            {
                LogHelpers.Write("Fuente: " + e.Source + " Exception:" + e.InnerException);
                LogHelpers.Write("Message: " + e.Message);
                LogHelpers.Write("Traza: " + e.StackTrace);
                return false;
            }


        }

        public static void AssertIsTextEqual(this IWebElement element, string text)
        {
            if (!IsTextIsEqual(element, text))
            {

                Assert.IsTrue(!IsTextIsEqual(element, text));
                LogHelpers.Write(("Text Not Present Equal" + "searched text: " + text + " found text: " + element.Text));
                throw new Exception(string.Format("Text Not Present exception"));

            }
        }



        public static bool IsTextIsEqual(this IWebElement element, string text)
        {

            try
            {
                if (element.Text.CompareTo(text) == 0)
                {

                    return true;

                }
                else
                {

                    return false;

                }

            }
            catch (Exception e)
            {
                LogHelpers.Write("Texto No es Igual: " + element.Text + " Texto esperado:" + text);
                LogHelpers.Write("Fuente: " + e.Source + " Exception:" + e.InnerException);
                LogHelpers.Write("Message: " + e.Message);
                LogHelpers.Write("Traza: " + e.StackTrace);
                return false;
            }


        }
        public static void TakeScreenshot(this IWebElement element, ParallelConfig driver, string feature, string scenario)
        {
            Screenshot screenshot = driver.Driver.GetScreenshot();
            string screenshotFile = Path.Combine(TestContext.CurrentContext.WorkDirectory, "[Feature]" + feature + "[Scenario]" + scenario + ".png");
            LogHelpers.WriteSteps("(Se realiza captura de pantalla...)", feature, scenario);
            screenshot.SaveAsFile(screenshotFile, ScreenshotImageFormat.Png);
            TestContext.AddTestAttachment(screenshotFile, scenario);

        }


    }
}
