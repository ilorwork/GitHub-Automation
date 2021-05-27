using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace GitHubProject
{
    public class BasePage : AutomationConfig
    {

        public void click(By by)
        {
            IWebElement element = null;
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(by));
                element = wait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(by)));
                element.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                throw new Exception("Click element: " + element + " has failed! exception: ", e);
            }
        }

        public void sendKeys(By by, String text)
        {
            IWebElement element = null;
            try
            {
                this.click(by);
                element = driver.FindElement(by);
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