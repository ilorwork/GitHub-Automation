// BasePage.cs
using OpenQA.Selenium;

namespace infra.AutomationInfra
{
    public abstract class BasePage
    {
        protected IWebDriver driver;
        protected ILogger logger;
        protected ActionBot Bot;

        public BasePage(IWebDriver driver, ILogger logger)
        {
            this.driver = driver;
            this.logger = logger;
            Bot = new ActionBot(driver, logger);
        }
    }
}
