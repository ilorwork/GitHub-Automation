using OpenQA.Selenium;

namespace GitHub.pages.GitHubPages
{
    internal class CreateIssuePage : IssuesTabPage
    {
        private readonly By issueTitleField;
        private readonly By issueBodyField;
        private readonly By submitBtn;

        public CreateIssuePage()
        {
            this.issueTitleField = By.Id("issue_title");
            this.issueBodyField = By.Id("issue_body");
            this.submitBtn = By.CssSelector("[data-view-component='true'].btn-primary.btn");
        }

        public IssuePage CreateNewIssue(string issueTitle, string issueBody)
        {
            SendKeys(issueTitleField, issueTitle, nameof(issueTitleField));
            SendKeys(issueBodyField, issueBody, nameof(issueBodyField));
            Click(submitBtn, nameof(submitBtn));
            return new IssuePage();
        }
    }
}
