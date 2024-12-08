using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using ScadaWeb.Pages;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using ScadaWeb.Drivers;

namespace ScadaWeb.StepDefinitions
{
    [Binding]
    public class _001TagesBTBSteps
    {
        private BTBPage _btbPage = new BTBPage();
        //private string? _name;
        MyAlert _myAlert = new MyAlert();

        private ScenarioContext _scenarioContext;

        public _001TagesBTBSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"Navigieren Sie zum Menu ""(.*)""")]
        public void GivenNavigierenSieZumMenu(string menuName)
        {
            _btbPage.MyHover(_btbPage.GetWebElement(menuName));
        }

        [When(@"Der Benutzer klickt auf die Option ""(.*)""")]
        public void WhenDerBenutzerKlicktAufDieOption(string optionName)
        {
            _btbPage.MyClick(_btbPage.GetWebElement(optionName));
        }

        [Then(@"Der Benutzer sieht das Menü ""(.*)""")]
        public void ThenDerBenutzerSiehtDasMenu(string menuName)
        {
            _btbPage.MyVerifyEqualsText(_btbPage.GetWebElement(menuName), menuName);
        }

        [Then(@"Der Benutzer gibt im Pop-Up Fenster ""(.*)"" an\.")]
        public void ThenDerBenutzerGibtImPop_UpFensterAn_(string inputText)
        {   
            _myAlert.EnterText(inputText);
            //_name = inputText;
            _scenarioContext["inputText"] = inputText;

        }

        [Then(@"Der Benutzer klickt auf die Tastatur ""(.*)""")]
        public void ThenDerBenutzerKlicktAufDieTastatur(string text)
        {
            _myAlert.AcceptAlert();
        }


        [Then(@"Das neue Tages-Betriebstagebuch mit dem angegebenen Namen erstellt wurde")]
        public void ThenDasNeueTages_BetriebstagebuchMitDemAngegebenenNamenErstelltWurde()
        {
            #nullable disable
          //  _btbPage.MyVerifyEqualsText(_btbPage.btbName, _name);
            #nullable enable
            _btbPage.MyVerifyEqualsText(_btbPage.btbName, (string)_scenarioContext["inputText"]);
        }
    }
}
