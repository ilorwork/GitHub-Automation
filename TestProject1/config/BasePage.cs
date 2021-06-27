using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using OpenQA.Selenium;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

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
        public void Click(IWebElement element)
        {
            try
            {
                element = Wait.Until(ExpectedConditions.ElementToBeClickable(element));
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
                string enumOptionDescription = GetDescription(option);
                if (!webElement.Text.Equals(enumOptionDescription)) continue;
                Click(webElement);
                elementFound = true;
                break;
            }
            if (!elementFound)
            {
                throw new Exception("Could not find any element to click on!");
            }
        }
        private string GetDescription(Enum value)
        {
            // Get the Description attribute value for the ENUM
            FieldInfo fi = value.GetType().GetField(value.ToString());//gets ENUM value
            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                    typeof(DescriptionAttribute), false);//gets the description annotations inside the ENUM 

            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }
    }
}