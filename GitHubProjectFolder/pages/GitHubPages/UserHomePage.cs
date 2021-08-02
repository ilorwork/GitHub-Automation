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
        private T ChooseOptionFromNewMenu<T>(NewMenuOptions newMenuOptions, Type returnPageType) where T : GitHubPage
        {
            ClickOnOptionUsingEnum(FindElements(newDropDownOptions), newMenuOptions);

            //TODO: check maybe using ByAll method for the return type here
            var gottenPage = (GitHubPage)Activator.CreateInstance(returnPageType);
            return (T)gottenPage;
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
