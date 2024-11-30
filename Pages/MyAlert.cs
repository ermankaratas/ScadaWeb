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
            // Varsayılan WebDriver ile WebDriverWait başlatılır
            Wait = new WebDriverWait(Driver.GetDriver(), TimeSpan.FromSeconds(10));
        }

        // Alert'in varlığını kontrol et
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

        // Alert içinde metin gönder
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

        // Alert'i kabul et (OK)
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

        // Alert'i iptal et (Cancel)
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
