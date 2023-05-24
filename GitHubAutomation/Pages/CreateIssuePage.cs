namespace GitHubAutomation.Pages
{
    internal class CreateIssuePage : IssuesTabPage
    {
        private readonly By issueTitleField;
        private readonly By issueBodyField;
        private readonly By submitBtn;

        public CreateIssuePage(IWebDriver driver, ILogger logger) : base(driver, logger)
        {
            issueTitleField = By.Id("issue_title");
            issueBodyField = By.Id("issue_body");
            submitBtn = By.XPath("//button[contains(text(),'Submit new issue')][@class='btn-primary btn ml-2']");
        }

        public IssuePage CreateNewIssue(string issueTitle, string issueBody)
        {
            Bot.SendKeys(issueTitleField, issueTitle, nameof(issueTitleField));
            Bot.SendKeys(issueBodyField, issueBody, nameof(issueBodyField));
            Bot.Click(submitBtn, nameof(submitBtn));
            return new IssuePage(driver, logger);
        }
    }
}
