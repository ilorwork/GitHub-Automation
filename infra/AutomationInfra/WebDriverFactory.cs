// WebDriverFactory.cs
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace infra.AutomationInfra
{
    public class WebDriverFactory
    {
        public IWebDriver GetDriver()
        {
            string browser = TestContext.Parameters.Get("Browser", "Chrome");

            switch (browser.ToLower())
            {
                case "firefox":
                    new DriverManager().SetUpDriver(new FirefoxConfig(), VersionResolveStrategy.MatchingBrowser);
                    return new FirefoxDriver();

                case "chrome":
                    new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
                    return new ChromeDriver();

                case "gridchrome":
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddAdditionalOption("BrowserName", "chrome");
                    var gridChromeUrl = new Uri(TestContext.Parameters.Get("GridUrl", ""));
                    return new RemoteWebDriver(gridChromeUrl, chromeOptions);

                case "gridfirefox":
                    var firefoxOptions = new FirefoxOptions();
                    firefoxOptions.AddAdditionalOption("BrowserName", "firefox");
                    var gridFirefoxUrl = new Uri(TestContext.Parameters.Get("GridUrl", ""));
                    return new RemoteWebDriver(gridFirefoxUrl, firefoxOptions);

                default:
                    throw new NotImplementedException($"browser '{browser}' is not supported");
            }
        }
    }
}
