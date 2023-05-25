using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace GitHubAutomation.Pages
{
    internal class UserHomePage : GitHubPage
    {
        private readonly By newMenuBtn;
        private readonly By newDropDownOptions;

        public UserHomePage(IWebDriver driver, ILogger logger) : base(driver, logger)
        {
            newMenuBtn = By.CssSelector("summary[aria-label = 'Create new…']");
            newDropDownOptions = By.XPath("//*[@href='/new']/parent::details-menu/a");
        }

        public override bool IsDisplayed() => Bot.IsElementVisible(newMenuBtn);

        public UserHomePage OpenNewMenu()
        {
            Bot.Click(newMenuBtn, nameof(newMenuBtn));
            return this;
        }

        private TGitHubPage ChooseOptionFromNewMenu<TGitHubPage>(NewMenuOptions newMenuOptions, Type returnPageType) where TGitHubPage : GitHubPage
        {
            Bot.ClickOnOptionUsingEnum(Bot.FindElements(newDropDownOptions), newMenuOptions);

            var constructorArgs = new object[] { driver, logger };
            //TODO: check maybe using ByAll method for the return type here
            var gottenPage = (GitHubPage)Activator.CreateInstance(returnPageType, constructorArgs);
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
