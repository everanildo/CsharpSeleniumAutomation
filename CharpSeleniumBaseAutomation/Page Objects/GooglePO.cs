using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;
using static NavigationSpecflowSelenium.Support.ExtensionMethods;


namespace NavigationSpecflowSelenium.Page_Objects
{
    public class GooglePO
    {
        private readonly IWebDriver driver;

        public GooglePO(IWebDriver _driver)
        {
            driver = _driver;
        }

        #region xpath

        //main page
        private readonly string googleSearchInput = ".//textarea[@name = 'q']";
        private readonly string googleSearchButton = ".//input[@name = 'btnK']";
        private readonly string imFeelingLuckyButton = ".//input[@name = 'btnI']";
        private readonly string resultsCountLabel = ".//div[@id = 'result-stats']";

        #endregion


        #region methods

        public void SetSearch(string searchFor)
        {
            driver.FindElement(By.XPath(googleSearchInput)).SendKeys(searchFor);
        }

        public void ClickSearchButton()
        {
            driver.FindElement(By.XPath(googleSearchButton)).Click();
        }

        public void ClickIamFeelingLuckyButton()
        {
            driver.FindElement(By.XPath(imFeelingLuckyButton)).Click();
        }

        public Int64 GetResultsCount()
        {
            driver.WaitUntilElementIsDisplayed(resultsCountLabel);
            string resultCountText = driver.FindElement(By.XPath(resultsCountLabel)).Text;
            Int64 resultCount = Convert.ToInt64(string.Join("", resultCountText.ToCharArray().Where(Char.IsDigit)));

            return resultCount;
        }
        #endregion


    }
}
