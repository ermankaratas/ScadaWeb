using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using ScadaWeb.Drivers;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaWeb.Pages
{
    public class MyAlert
    {
        #nullable disable
        private WebDriverWait Wait;

        public MyAlert()
        {
            // Standard-WebDriver wird initialisiert mit WebDriverWait
            Wait = new WebDriverWait(Driver.GetDriver(), TimeSpan.FromSeconds(10));
        }

        // Überprüfen, ob ein Alert vorhanden ist
        private IAlert GetAlert()
        {
            try
            {
                return Wait.Until(ExpectedConditions.AlertIsPresent());
            }
            catch (NoAlertPresentException)
            {
                Console.WriteLine("Kein Alert-Fenster gefunden.");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ein Fehler ist aufgetreten: " + ex.Message);
                throw;
            }
        }

        // Text in den Alert eingeben
        public void EnterText(string textToEnter)
        {
            try
            {
                var alert = GetAlert();
                alert.SendKeys(textToEnter);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim Senden des Textes: " + ex.Message);
            }
        }

        // Alert akzeptieren (OK)
        public void AcceptAlert()
        {
            try
            {
                var alert = GetAlert();
                alert.Accept();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim Akzeptieren des Alerts: " + ex.Message);
            }
        }

        // Alert ablehnen (Abbrechen) (Cancel)
        public void DismissAlert()
        {
            try
            {
                var alert = GetAlert();
                alert.Dismiss();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim Ablehnen des Alerts: " + ex.Message);
            }
        }
    }
}
