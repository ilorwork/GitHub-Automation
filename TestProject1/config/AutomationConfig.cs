using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace GitHub.config
{
    public class AutomationConfig
    {
        public static IWebDriver Driver = new ChromeDriver();
        public static WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
    }
}
