using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaWeb.Drivers
{
    public class Driver
    {
        private static ThreadLocal<IWebDriver> threadDriver = new ThreadLocal<IWebDriver>();
        private static ThreadLocal<string> threadBrowserName = new ThreadLocal<string>();

        public static IWebDriver GetDriver()
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");

            if (threadBrowserName.Value == null)
                threadBrowserName.Value = "chrome";

            if (threadDriver.Value == null)
            {
                switch (threadBrowserName.Value)
                {
                    case "chrome":
                        threadDriver.Value = new ChromeDriver();
                        break;
                    case "firefox":
                        threadDriver.Value = new FirefoxDriver();
                        break;
                    case "edge":
                        threadDriver.Value = new EdgeDriver();
                        break;
                    default:
                        throw new ArgumentException($"Unsupported browser: {threadBrowserName.Value}");
                }
                threadDriver.Value.Manage().Window.Maximize();
                threadDriver.Value.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
            }
            return threadDriver.Value ?? throw new InvalidOperationException("WebDriver could not be initialized."); 
        }

        public static void QuitDriver()
        {
            if (threadDriver.Value != null)
            {
                threadDriver.Value.Quit();
                #nullable disable
                threadDriver = new ThreadLocal<IWebDriver>(() => null);
                #nullable enable
            }
        }
    }
}
