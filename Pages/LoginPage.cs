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
    public class LoginPage : ParentPage
    {
        public LoginPage()
        {
            PageFactory.InitElements(Driver.GetDriver(), this);
        }
        
        #nullable disable
        [FindsBy(How = How.CssSelector, Using = "input[id='ctl05_tbLogin']")]
        public IWebElement Username;

        [FindsBy(How = How.CssSelector, Using = "input[id='ctl05_tbPassword']")]
        public IWebElement Password;

        [FindsBy(How = How.CssSelector, Using = "input[id='ctl05_Button1']")]
        public IWebElement LoginButton;

        public void Login(string username, string password)
        {
            MySendKeys(Username, username);
            MySendKeys(Password, password);
            MyClick(LoginButton);
        }
    }
}
