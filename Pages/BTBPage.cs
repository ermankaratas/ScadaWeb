using OpenQA.Selenium;
using ScadaWeb.Drivers;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaWeb.Pages
{
    public class BTBPage : ParentPage
    {
        public BTBPage()
        {
            PageFactory.InitElements(Driver.GetDriver(), this);
        }

        #nullable disable
        [FindsBy(How = How.XPath, Using = "(//span[@class='rmLink rmRootLink rmExpand rmExpandDown'])[3]")]
        private IWebElement einstellungen;

        [FindsBy(How = How.XPath, Using = "((//ul[@class='rmVertical rmGroup rmLevel1'])[3]/li)[4]/a")]
        private IWebElement btbKonfig;

        [FindsBy(How = How.XPath, Using = "(//span[@class='rtbIn'])[2]")]
        private IWebElement neuesBtb;

        [FindsBy(How = How.XPath, Using = "(//ul[@class='rtbActive rtbGroup rtbLevel1']/li)[1]/a")]
        private IWebElement tagesBtb;

        [FindsBy(How = How.XPath, Using = "//div[@class='listHeader']/h4/span")]
        public IWebElement btbName;

        public IWebElement GetWebElement(string strElement)
        {
            switch (strElement)
            {
                case "Einstellungen":
                    return this.einstellungen;
                case "Betriebstagebuch konfigurieren":
                    return this.btbKonfig;
                case "Neues Betriebstagebuch":
                    return this.neuesBtb;
                case "Tages-Betriebstagebuch":
                    return this.tagesBtb;
                default:
                    return null;
            }
        }
    }
}
