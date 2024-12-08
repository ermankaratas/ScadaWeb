using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScadaWeb.Drivers;
using OpenQA.Selenium.Interactions;

namespace ScadaWeb.Pages
{
    public class ParentPage
    {
        protected WebDriverWait Wait => new WebDriverWait(Driver.GetDriver(), TimeSpan.FromSeconds(10));

        public void MyWait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }

        public void MyClick(IWebElement element)
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
            MyScrollToElement(element);
            element.Click();
        }

        public void MySendKeys(IWebElement element, string text)
        {
            // Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
            Wait.Until(driver => element.Displayed);

            MyScrollToElement(element);
            element.Clear();
            element.SendKeys(text);
        }

        public void MyScrollToElement(IWebElement element)
        {
            ((IJavaScriptExecutor)Driver.GetDriver()).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public void MyVerifyUrlContains(string partialUrl)
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains(partialUrl));
            Assert.That(Driver.GetDriver().Url.Contains(partialUrl));
        }

        public void MyHover(IWebElement element)
        {
            Wait.Until(driver => element.Displayed); ;
            Actions actions = new Actions(Driver.GetDriver());
            actions.MoveToElement(element).Perform();
        }

        public void MyVerifyEqualsText(IWebElement element, string value)
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(element, value));
            Assert.That(element.Text.Equals(value, StringComparison.OrdinalIgnoreCase));
            new Actions(Driver.GetDriver()).SendKeys(Keys.Escape).Perform();
        }
    }
}
