using OpenQA.Selenium;
using NavigationSpecflowSelenium.Support;
using NUnit.Framework;
using NavigationSpecflowSelenium.Page_Objects;

namespace NavigationSpecflowSelenium.StepDefinitions
{
    [Binding]
    public class NavigationStepDefinitions
    {
        IWebDriver driver = Helper.driver;

        [Given(@"I navigate to ""([^""]*)"" and validate the page title has ""([^""]*)""")]
        public void GivenINavigateToAndValidateThePageTitleHas(string urlToNavigate, string pageTitleText)
        {
            driver.Navigate().GoToUrl(urlToNavigate);
            string pageTitle = driver.Title;
            Assert.IsTrue(pageTitle.Contains(pageTitleText));
        }

        [Then(@"I Search for ""([^""]*)"" on Google home page and Check I have more than ""([^""]*)"" results")]
        public void ThenISearchForOnGoogleHomePageAndCheckIHaveMoreThanResults(string textToSearch, int expectedResultCount)
        {
            GooglePO googlePO = new (driver);

            googlePO.SetSearch(textToSearch);
            googlePO.ClickSearchButton();
            Int64 currentResultCount = googlePO.GetResultsCount();

            Assert.IsTrue(currentResultCount > expectedResultCount, $"Expected to have more than {expectedResultCount} but found {currentResultCount}");
        }

    }
}
