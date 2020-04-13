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

            LogHelpers.WriteSteps("Validando Titulo: " + p0, _featureContext.FeatureInfo.Title, _scenarioContext.ScenarioInfo.Title);
            IWebElement element = _parallelConfig.Driver.FindElementByTagName("h3");
            
               element.AssertIsTextPresent(p0);

        }


        [Then(@"Se despliegan las comunas y nombres de las farmacias")]
        public void ThenSeDesplieganLasComunasYNombresDeLasFarmacias()
        {


            LogHelpers.WriteSteps("Validando campos: ", _featureContext.FeatureInfo.Title, _scenarioContext.ScenarioInfo.Title);
            IWebElement elementComuna = _parallelConfig.Driver.FindById("comunas");
            IWebElement elementFarmacias = _parallelConfig.Driver.FindById("farmacias");
            elementComuna.AssertElementPresent();
            elementFarmacias.AssertElementPresent();
            
        }

        [When(@"yo selecciono una comuna '(.*)' y el nombre de una farmacia '(.*)' y presiono el boton ""(.*)""")]
        public void WhenYoSeleccionoUnaComunaYElNombreDeUnaFarmaciaYPresionoElBoton(string p0, string p1, string p2)
        {

            LogHelpers.WriteSteps("Seleccionandoy enviado parámetros: comuna: " + p0 + " farmacia:" + p1, _featureContext.FeatureInfo.Title, _scenarioContext.ScenarioInfo.Title);
            _parallelConfig.CurrentPage.As<BuscarFarmaciasPage>().Seleccionar(p0,p1);           
            _parallelConfig.CurrentPage.As<BuscarFarmaciasPage>().Search();
            Util.TakeScreenshot(_parallelConfig, _featureContext.FeatureInfo.Title, _scenarioContext.ScenarioInfo.Title + "_formulario_before");

        

        }

        [Then(@"se muestran las farmacias '(.*)' de turno de esa marca y comuna '(.*)' y validar la siguiente data '(.*)'")]
        public void ThenSeMuestranLasFarmaciasDeTurnoDeEsaMarcaYComuna(string p0, string p1, string p2)
        {

            LogHelpers.WriteSteps("Entrando a validación principal: " + p0 +  " " + p1 + " " + p2, _featureContext.FeatureInfo.Title, _scenarioContext.ScenarioInfo.Title);
            IWebElement element = _parallelConfig.Driver.FindElementByTagName("body");
            Util.TakeScreenshot(_parallelConfig, _featureContext.FeatureInfo.Title, _scenarioContext.ScenarioInfo.Title + "_formulario_after");

            string[] locales;
            if (p2.Contains(","))
            {
                locales = p2.Split(',');
                for (int i = 0; i < locales.Length; i++)
                {

                    string local = locales[i];
                    LogHelpers.WriteSteps("Validando arreglo de locales: " + p2, _featureContext.FeatureInfo.Title, _scenarioContext.ScenarioInfo.Title);
                   
                    element.AssertIsTextPresent(local);
                }
            }  
            else
            {
                LogHelpers.WriteSteps("Validando local: " + p2, _featureContext.FeatureInfo.Title, _scenarioContext.ScenarioInfo.Title);
                element.AssertIsTextPresent(p2);
            }



            LogHelpers.WriteSteps("Validando comuna: " + p2, _featureContext.FeatureInfo.Title, _scenarioContext.ScenarioInfo.Title);
            element.AssertIsTextPresent(p0);
            LogHelpers.WriteSteps("Validando farmacia: " + p2, _featureContext.FeatureInfo.Title, _scenarioContext.ScenarioInfo.Title);
            element.AssertIsTextPresent(p1);
            
            _parallelConfig.Driver.Navigate().Back();

            Thread.Sleep(3000);

        }







    }

}
