using System;
using GitHub.helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace GitHub.config
{
    public class AutomationConfig
    {
        /*
         * public const int DefaultTimeout = 30;
         * public const int DefaultTimeoutForLongWaits = 60;
         */
        public static IWebDriver Driver = new ChromeDriver();
        // remove this static
        public static WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));

        public void Log(string info)
        {
            LocalLogger.PrintLog(info);
        }
    }
}
