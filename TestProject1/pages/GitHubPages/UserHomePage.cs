using System.ComponentModel;
using OpenQA.Selenium;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace GitHub.pages.GitHubPages
{
    class UserHomePage : GitHubPage
    {
        private By newMenuBtn;
        private By newDropDownOptions;

        public UserHomePage ()
        {
            this.newMenuBtn = By.CssSelector("summary[aria-label = 'Create new…']");
            this.newDropDownOptions = By.XPath("//*[@href='/new']/parent::details-menu/a");
        }

        public UserHomePage OpenNewMenu()
        {
            Click(newMenuBtn);
            return this;
        }
        public void ChooseOptionFromNewMenu(NewMenuOptions newMenuOptions)
        {
            // TODO: return corresponding pages
            ClickOnOptionUsingEnum(FindElements(newDropDownOptions), newMenuOptions);
        }
        
        public enum NewMenuOptions
        {
            [Description("New repository")]
            NewRepository,
        }
    }
}
