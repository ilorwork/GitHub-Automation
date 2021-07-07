using System;
using System.Collections.ObjectModel;
using GitHub.helpers;
using OpenQA.Selenium;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace GitHub.config
{
    public class BasePage : AutomationConfig
    {

        public void Click(By by, string description = null)
        {
            IWebElement element = null;
            try
            {
                Wait.Until(ExpectedConditions.ElementIsVisible(by));
                element = Wait.Until(ExpectedConditions.ElementToBeClickable(Driver.FindElement(by)));
                element.Click();
                Log($"Click on {description}");
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                throw new Exception("Click element: " + element + " has failed! exception: ", e);
            }
        }
        public void Click(IWebElement element, string description = null)
        {
            try
            {
                element = Wait.Until(ExpectedConditions.ElementToBeClickable(element));
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
                this.Click(by , description);
                element = Driver.FindElement(by);
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

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            //TODO: wait for all elements disabled because need to check why it fails.
            //Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(FindElements(by)));
            return Driver.FindElements(by);
        }
        public void ClickOnOptionUsingEnum(ReadOnlyCollection<IWebElement> listOfOptions, Enum option)
        {
            bool elementFound = false;
            foreach (var webElement in listOfOptions)
            {
                string enumOptionDescription = ExtensionsMethods.GetDescription(option);
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