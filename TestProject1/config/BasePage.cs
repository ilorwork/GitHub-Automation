using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace GitHub.config
{
    public class BasePage : AutomationConfig
    {

        public void Click(By by)
        {
            IWebElement element = null;
            try
            {
                Wait.Until(ExpectedConditions.ElementIsVisible(by));
                element = Wait.Until(ExpectedConditions.ElementToBeClickable(Driver.FindElement(by)));
                element.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                throw new Exception("Click element: " + element + " has failed! exception: ", e);
            }
        }

        public void SendKeys(By by, string text)
        {
            IWebElement element = null;
            try
            {
                this.Click(by);
                element = Driver.FindElement(by);
                element.Clear();
                element.SendKeys(text);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                throw new Exception("Send keys to element: " + element + " has failed! exception: ", e);
            }
        }
    }
}