using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NavigationSpecflowSelenium.Support
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _scenarioContext;
        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            string browser = "CHROME";
            Helper.driver = SetWebdriver(browser);
            Helper.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Helper.driver.Close();
            Helper.driver.Dispose();
        }

        private IWebDriver SetWebdriver(string browser)
        {
            DriverOptions driverOptions = new(_scenarioContext);
            switch (browser)
            {
                case nameof(Helper.Browser.CHROME): 
                    Helper.driver = new ChromeDriver(driverOptions.GetChromeOptions()); 
                    return Helper.driver;
                default: 
                    throw new ArgumentException($"{browser} is not supported.");
            }
        }

    }
}
