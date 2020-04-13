using EAAutoFramework.Base;
using EAAutoFramework.Config;
using TechTalk.SpecFlow;
using EAAutoFramework.Helpers;
using EAEmployeeTest.Pages;
using System.Threading;
using OpenQA.Selenium;
using EAAutoFramework.Extensions;

namespace EAAutoFramework.Steps
{
    [Binding]
    public class BuscarSteps : BaseStep
    {

        //Context injection
        private new readonly ParallelConfig _parallelConfig;
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;
     
        public BuscarSteps(ParallelConfig parallelConfig, FeatureContext featureContext, ScenarioContext scenarioContext): base(parallelConfig)
        {
            _parallelConfig = parallelConfig;
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;

        }

        public void NaviateSite()
        {

            _parallelConfig.Driver.Navigate().GoToUrl(Settings.AUT);
            LogHelpers.WriteSteps("Abriendo navegador y direccionando a Login page", _featureContext.FeatureInfo.Title, _scenarioContext.ScenarioInfo.Title);

        }

  
        [Given(@"que quiero saber las farmacias de turno ingreso a la aplicación")]
        public void GivenQueQuieroSaberLasFarmaciasDeTurnoIngresoALaAplicacion()
        {

            NaviateSite();
            _parallelConfig.CurrentPage = new BuscarFarmaciasPage(_parallelConfig);
         

        }

        [When(@"la página ""(.*)"" carga")]
        public void WhenLaPaginaCarga(string p0)
        {

            
               IWebElement element = _parallelConfig.Driver.FindElementByTagName("h3");
            
               element.AssertIsTextPresent(p0);

        }


        [Then(@"Se despliegan las comunas y nombres de las farmacias")]
        public void ThenSeDesplieganLasComunasYNombresDeLasFarmacias()
        {

            IWebElement elementComuna = _parallelConfig.Driver.FindById("comunas");
            IWebElement elementFarmacias = _parallelConfig.Driver.FindById("farmacias");
            elementComuna.AssertElementPresent();
            elementFarmacias.AssertElementPresent();
            
        }

        [When(@"yo selecciono una comuna '(.*)' y el nombre de una farmacia '(.*)' y presiono el boton ""(.*)""")]
        public void WhenYoSeleccionoUnaComunaYElNombreDeUnaFarmaciaYPresionoElBoton(string p0, string p1, string p2)
        {     

            _parallelConfig.CurrentPage.As<BuscarFarmaciasPage>().Seleccionar(p0,p1);           
            _parallelConfig.CurrentPage.As<BuscarFarmaciasPage>().Search();

        

        }

        [Then(@"se muestran las farmacias '(.*)' de turno de esa marca y comuna '(.*)' y validar la siguiente data '(.*)'")]
        public void ThenSeMuestranLasFarmaciasDeTurnoDeEsaMarcaYComuna(string p0, string p1, string p2)
        {
            IWebElement element = _parallelConfig.Driver.FindElementByTagName("body");
            string[] locales;
            if (p2.Contains(","))
            {
                locales = p2.Split(',');
                for (int i = 0; i < locales.Length; i++)
                {
                    string local = locales[i];
                    element.AssertIsTextPresent(local);
                }
            }  
            else
            {
                element.AssertIsTextPresent(p2);
            }




            element.AssertIsTextPresent(p0);
            element.AssertIsTextPresent(p1);
            
            _parallelConfig.Driver.Navigate().Back();

            Thread.Sleep(3000);

        }







    }

}
