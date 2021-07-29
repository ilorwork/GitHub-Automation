using System;
using System.ComponentModel;
using OpenQA.Selenium;

namespace GitHub.pages.GitHubPages
{
    public class UserHomePage : GitHubPage
    {
        private readonly By newMenuBtn;
        private readonly By newDropDownOptions;

        public UserHomePage ()
        {
            this.newMenuBtn = By.CssSelector("summary[aria-label = 'Create new…']");
            this.newDropDownOptions = By.XPath("//*[@href='/new']/parent::details-menu/a");
        }

        public UserHomePage OpenNewMenu()
        {
            Click(newMenuBtn, nameof(newMenuBtn));
            return this;
        }
        private GitHubPage ChooseOptionFromNewMenu(NewMenuOptions newMenuOptions, Type returnPageType)
        {
            ClickOnOptionUsingEnum(FindElements(newDropDownOptions), newMenuOptions);

            //TODO: check maybe using ByAll method for the return type here
            var gottenPage = (GitHubPage)Activator.CreateInstance(returnPageType);
            return gottenPage;
        }
        public NewRepPage ChooseNewRepOption()
        {
            return (NewRepPage)ChooseOptionFromNewMenu(NewMenuOptions.NewRepository, typeof(NewRepPage));
        }
        
        public enum NewMenuOptions
        {
            [Description("New repository")]
            NewRepository,
        }
    }
}
