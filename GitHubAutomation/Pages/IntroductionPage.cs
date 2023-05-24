namespace GitHubAutomation.Pages
{
    internal class IntroductionPage : GitHubPage
    {
        private readonly By signInBtn;
        public IntroductionPage(IWebDriver driver, ILogger logger) : base(driver, logger)
        {
            signInBtn = By.CssSelector("[href = '/login']");
        }

        public override bool IsDisplayed() => Bot.IsElementVisible(signInBtn);

        public LoginPage ClickLogin()
        {
            Bot.Click(signInBtn, nameof(signInBtn));
            return new LoginPage(driver, logger);
        }
    }
}
