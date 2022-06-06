using System;
using System.ComponentModel;
using OpenQA.Selenium;

namespace GitHub.pages.GitHubPages
{
    internal class UserHomePage : GitHubPage
    {
        private readonly By newMenuBtn;
        private readonly By newDropDownOptions;

        public UserHomePage ()
        {
            newMenuBtn = By.CssSelector("summary[aria-label = 'Create new…']");
            newDropDownOptions = By.XPath("//*[@href='/new']/parent::details-menu/a");
        }

        public override bool IsDisplayed() => IsElementVisible(newMenuBtn);

        public UserHomePage OpenNewMenu()
        {
            Click(newMenuBtn, nameof(newMenuBtn));
            return this;
        }

        private TGitHubPage ChooseOptionFromNewMenu<TGitHubPage>(NewMenuOptions newMenuOptions, Type returnPageType) where TGitHubPage : GitHubPage
        {
            ClickOnOptionUsingEnum(FindElements(newDropDownOptions), newMenuOptions);

            //TODO: check maybe using ByAll method for the return type here
            var gottenPage = (GitHubPage)Activator.CreateInstance(returnPageType);
            return (TGitHubPage)gottenPage;
        }
        public NewRepPage ChooseNewRepOption()
        {
            return ChooseOptionFromNewMenu<NewRepPage>(NewMenuOptions.NewRepository, typeof(NewRepPage));
        }

        public enum NewMenuOptions
        {
            [Description("New repository")]
            NewRepository,
        }
    }
}
