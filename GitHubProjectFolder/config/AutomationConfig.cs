using System;
using GitHub.helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace GitHub.config
{
    public class AutomationConfig
    {
        public const double DefaultTimeout = 30;
        public const double DefaultTimeoutForLongWaits = 60;
        public static IWebDriver Driver = new ChromeDriver();
        public WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(DefaultTimeout));

        public void Log(string info)
        {
            LocalLogger.PrintLog(info);
        }
    }
}
