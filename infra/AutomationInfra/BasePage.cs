// BasePage.cs
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace infra.AutomationInfra
{
    public abstract class BasePage
    {
        protected IWebDriver driver;
        protected ILogger logger;
        protected WebDriverWait wait;
        protected ActionBot Bot;

        public BasePage(IWebDriver driver, ILogger logger)
        {
            this.driver = driver;
            this.logger = logger;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Bot = new ActionBot(driver, wait, logger);
        }
    }
}
