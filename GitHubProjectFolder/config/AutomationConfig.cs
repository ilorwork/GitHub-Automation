using GitHub.helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace GitHub.config
{
    public class AutomationConfig
    {
        // TODO: add FireFox
        public static IWebDriver Driver = new ChromeDriver();
        // TODO: add selenium grid
        public bool IsLocal => GetParams("local", true);
        public const int Retries = 2;

        public void Log(string info) => LocalLogger.PrintLog(info);

        public T GetParams<T>(string param, T defaultV) => TestContext.Parameters.Get(param, defaultV);
    }
}
