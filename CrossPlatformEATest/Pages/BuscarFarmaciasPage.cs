using EAAutoFramework.Base;
using OpenQA.Selenium;
using EAAutoFramework.Extensions;
using EAAutoFramework.Pages;


namespace EAEmployeeTest.Pages
{
    class BuscarFarmaciasPage : ExtendPage

    {

        public BuscarFarmaciasPage(ParallelConfig parallelConfig) : base(parallelConfig)
        {

        }

        IWebElement SelectComuna => _parallelConfig.Driver.FindById("comunas");

        IWebElement SelectFarmacia => _parallelConfig.Driver.FindById("farmacias");

        IWebElement BtnBuscar  => _parallelConfig.Driver.FindByXpath("//Button[text()='Buscar Farmacias']");

        IWebElement titulo => _parallelConfig.Driver.FindByXpath("//h3[text()='Buscar Farmacias']");

        public void Seleccionar(string comuna, string farmacia)
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//option[text()='"+ comuna + "']")));
            SelectComuna.SelectDropDownList(comuna);
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//option[text()='" + farmacia + "']")));
            SelectFarmacia.SelectDropDownList(farmacia);

        }

        public void Search()
        {

            BtnBuscar.Click();

        }

        

        



    }
}
