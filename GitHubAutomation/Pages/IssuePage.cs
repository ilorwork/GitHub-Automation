namespace GitHubAutomation.Pages
{
    internal class IssuePage : GitHubPage
    {
        private readonly By closeIssueBtn;

        public IssuePage(IWebDriver driver, ILogger logger) : base(driver, logger)
        {
            closeIssueBtn = By.Name("comment_and_close");
        }

        public override bool IsDisplayed() => Bot.IsElementVisible(closeIssueBtn);
    }
}
