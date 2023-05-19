// BasePage.cs
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace infra.PageObjects
{
    public abstract class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        protected ActionBot Bot;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Bot = new ActionBot(driver, wait);
        }
    }
}
