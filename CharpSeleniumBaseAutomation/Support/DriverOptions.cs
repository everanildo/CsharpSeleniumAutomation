

using OpenQA.Selenium.Chrome;

namespace NavigationSpecflowSelenium.Support
{
    public class DriverOptions
    {
        private readonly ScenarioContext _scenarioContext;
        public DriverOptions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        public ChromeOptions GetChromeOptions()
        {
            ChromeOptions options = new ChromeOptions();

            options.AddArgument("start-maximized");
            options.AddArgument("incognito");
            options.AddArgument("disable-extensions");
            options.AddArgument("disable-popup-blocking");
            options.AddArgument("disable-infobars");

            return options;
        }
    }
}
