using ScadaWeb.Drivers;
using ScadaWeb.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace ScadaWeb.StepDefinitions
{
    [Binding]
    public class _000AnmeldenSteps
    {
        private readonly ScenarioContext _scenarioContext;

        private LoginPage _loginPage = new LoginPage();

        public _000AnmeldenSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(@"Navigieren Sie zu scada\.web")]
        public void GivenNavigierenSieZuScada_Web()
        {
            Driver.GetDriver().Navigate().GoToUrl(TestContext.Parameters["login_url"]);
        }

        [When(@"Sie geben Benutzernamen und Passwort ein und klicken auf die Anmelden-Taste")]
        public void WhenSieGebenBenutzernamenUndPasswortEinUndKlickenAufDieAnmelden_Taste()
        {
            string? user = TestContext.Parameters["user"];
            string? password = TestContext.Parameters["password"];
            _loginPage.Login(user, password);
        }

        [Then(@"Der Benutzer sollte sich  erfolgreich anmelden")]
        public void ThenDerBenutzerSollteSichErfolgreichAnmelden()
        {
            string? main_url = TestContext.Parameters["main_url"];
            #nullable disable
            _loginPage.MyVerifyUrlContains(partialUrl: main_url);
            #nullable enable
        }
    }
}

