using CrossPlatformEATest.Pages;
using EAAutoFramework.Base;
using EAAutoFramework.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace CrossPlatformEATest.Steps
{
    [Binding]
    class ExtendSteps : BaseStep
    {
        private new readonly ParallelConfig _parallelConfig;
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;   

        public ExtendSteps(ParallelConfig parallelConfig, FeatureContext featureContext, ScenarioContext scenarioContext) : base(parallelConfig)
        {

            _parallelConfig = parallelConfig;
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;

        }

        [Then(@"I wait for form ""(.*)"" in page ""(.*)""")]
        public void ThenIWaitForForm(string p0)
        {

            LogHelpers.WriteSteps("Validando el título de la página ingresar solicitudes: ", _featureContext.FeatureInfo.Title, _scenarioContext.ScenarioInfo.Title);
            if (p0.Contains("Ingreso Solicitud"))
            {

                _parallelConfig.CurrentPage.As<IngresarSolicitudPage>().CheckForContentVisibleText(p0,);

            }
            else if (p0.Contains("Buscar Solicitud Pendiente de Validación"))
            {

                //        _parallelConfig.CurrentPage.As<BuscarSolicitudAutorizarPage>().CheckForTextTitle(p0);

            }
        }

    }
}
