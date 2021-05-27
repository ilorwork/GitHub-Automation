using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace GitHubProject
{
    public class AutomationConfig
    {
        public static IWebDriver driver = new ChromeDriver();
        public static WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
    }
}
