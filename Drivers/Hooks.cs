using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace ScadaWeb.Drivers
{
    [Binding]
    public class Hooks
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            // Optional setup logic
            //Driver.threadBrowserName.Value = "firefox";
            Driver.threadBrowserName.Value = "edge";
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Driver.QuitDriver();
        }
    }
}
