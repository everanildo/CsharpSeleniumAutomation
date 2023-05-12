using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace NavigationSpecflowSelenium.Support
{
    public static class ExtensionMethods
    {
        public static void ClickWithAttemptsByXpath(this IWebDriver driver, string xpath, int secondsToWait = 2, int attempts = 3)
        {
            for (int i = 1; i <= attempts; i++)
            {
                Console.WriteLine($"attempt {i} to Click element by Xpath: {xpath}");

                try
                {
                    driver.FindElement(By.XPath(xpath)).Click();
                    break;
                }
                catch (Exception)
                {
                    if (i++ == attempts)
                        Console.WriteLine($"Click Element failed. Xpath: {xpath} after {attempts} attempts ");
                }

                Thread.Sleep(TimeSpan.FromSeconds(secondsToWait));
            }
        }

        public static void WaitForElementWithAttemptsByXpath(this IWebDriver driver, string xpath, int secondsToWait = 5, int attempts = 3)
        {
            for (int i = 1; i <= attempts; i++)
            {
                Console.WriteLine($"attempt {i} to find element by: {xpath}");

                if (IsElementDisplayedWithoutWait(driver, xpath))
                {
                    Console.WriteLine($"Element found By xpath: {xpath}");
                    break;
                }
                else if (i++ == attempts)
                {
                    Console.WriteLine($"Find Element failed. Xpath: {xpath} after {attempts} attempts ");
                }

                Thread.Sleep(TimeSpan.FromSeconds(secondsToWait));
            }
        }

        public static void ClickAsAction(this IWebDriver driver, IWebElement element)
        {
            Actions action = new(driver);
            action.MoveToElement(element).Click().Build().Perform();
        }

        public static void ClickAsScript(this IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", element);
        }

        public static void ScrollToElement(this IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public static void ValidateTextFromElement(this IWebDriver driver, string element, string textToSearch)
        {
            Assert.IsTrue(driver.FindElement(By.XPath(element)).Text.Equals(textToSearch), $"element doesnot contains {textToSearch} into its text");
        }

        public static IWebElement WaitUntil(this IWebDriver driver, string xpath, int seconds = 5)
        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(seconds));
            return wait.Until(d => d.FindElement(By.XPath(xpath)));
        }

        public static bool WaitUntilElementIsDisplayed(this IWebDriver driver, string xpath, int seconds = 5)
        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(seconds));
            return wait.Until(d => d.FindElement(By.XPath(xpath))).Displayed;
        }

        public static bool IsElementDisplayedWithoutWait(this IWebDriver driver, string xpath)
        {
            try
            {
                return driver.FindElement(By.XPath(xpath)).Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsElementDisplayed(this IWebDriver driver, string xpath, int seconds = 5)
        {
            try
            {
                WebDriverWait wait = new(driver, TimeSpan.FromSeconds(seconds));
                return wait.Until(d => d.FindElement(By.XPath(xpath))).Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsStringADateTime(string text)
        {
            DateTime dateTime;
            bool isDateTime = false;

            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            isDateTime = DateTime.TryParse(text, out dateTime);
            return isDateTime;
        }

        public static int ElementCount(this IWebDriver driver, string xpath)
        {
            int count = 0;

            try
            {
                count = driver.FindElements(By.XPath(xpath)).Count();
            }
            catch (Exception)
            {
                count = 0;
            }

            return count;
        }

        public static void ScrollPageToTheTop(this IWebDriver driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, 0)");
        }

        public static void ScrollPageToTheBottom(this IWebDriver driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
        }
    }
}
