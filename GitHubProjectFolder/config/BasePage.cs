using System;
using System.Collections.ObjectModel;
using GitHub.helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace GitHub.config
{
    public class BasePage : AutomationConfig
    {
        protected const double DefaultTimeout = 30;

        public void Click(By by, string description = null)
        {
            Click(WaitForElementToBeClickable(by), description);
        }

        public void Click(IWebElement element, string description = null)
        {
            try
            {
                element = WaitForElementToBeClickable(element);
                element.Click();
                Log($"Click on {description}");
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                Log($"Click on {description} has failed: {e}");
                throw new Exception("Click element: " + element + " has failed! exception: ", e);
            }
        }

        public void SendKeys(By by, string text, string description = null)
        {
            IWebElement element = null;
            try
            {
                element = FindElement(by);
                this.Click(element, description);
                element.Clear();
                element.SendKeys(text);
                Log($"Send: {text} To: {description}");
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                Log($"Send-Keys to: {description} has failed: {e}");
                throw new Exception("Send keys to element: " + element + " has failed! exception: ", e);
            }
        }

        public IWebElement WaitForElementToBeVisible(By by, double timeoutInSeconds = DefaultTimeout)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(ExpectedConditions.ElementIsVisible(by));
        }

        public IWebElement WaitForElementToBeClickable(IWebElement element, double timeoutInSeconds = DefaultTimeout)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public IWebElement WaitForElementToBeClickable(By by, double timeoutInSeconds = DefaultTimeout)
        {
            return WaitForElementToBeClickable(FindElement(by), timeoutInSeconds);
        }
        
        public bool IsElementVisible(By by, double timeoutInSeconds = DefaultTimeout)
        {
            try
            {
                WaitForElementToBeVisible(by, timeoutInSeconds);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IWebElement FindElement(By by)
        {
            return WaitForElementToBeVisible(by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by, double timeoutInSeconds = DefaultTimeout)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(by));
        }

        public void ClickOnOptionUsingEnum(ReadOnlyCollection<IWebElement> listOfOptions, Enum option)
        {
            bool elementFound = default;
            foreach (var webElement in listOfOptions)
            {
                var enumOptionDescription = ExtensionsMethods.GetDescription(option);
                if (!webElement.Text.Equals(enumOptionDescription)) continue;
                Click(webElement, enumOptionDescription);
                elementFound = true;
                break;
            }
            if (!elementFound)
            {
                throw new Exception("Could not find any element to click on!");
            }
        }
    }
}