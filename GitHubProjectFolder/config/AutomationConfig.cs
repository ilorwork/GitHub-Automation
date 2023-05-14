using GitHub.helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace GitHub.config
{
    public class AutomationConfig
    {
        public AutomationConfig()
        {
            Driver = GetDriver();
        }

        // TODO: add FireFox
        public static IWebDriver Driver;
        // TODO: add selenium grid
        public bool IsLocal => GetParams("local", true);
        public const int Retries = 1;

        public void Log(string info) => LocalLogger.PrintLog(info);

        public T GetParams<T>(string param, T defaultV) => TestContext.Parameters.Get(param, defaultV);

        public IWebDriver GetDriver()
        {
            if (Driver == null)
            {
                new DriverManager().SetUpDriver(new ChromeConfig());
                return new ChromeDriver();
            }
            return Driver;
        }
    }
}
