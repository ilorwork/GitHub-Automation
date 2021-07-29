using OpenQA.Selenium;

namespace GitHub.pages.GitHubPages
{
    public class NewIssuePage : IssuesTabPage
    {
        private readonly By issueTitleField;
        private readonly By issueBodyField;
        private readonly By submitBtn;

        public NewIssuePage()
        {
            this.issueTitleField = By.Id("issue_title");
            this.issueBodyField = By.Id("issue_body");
            this.submitBtn = By.CssSelector("[data-view-component='true'].btn-primary.btn");
        }

        public void CreateNewIssue(string issueTitle, string issueBody)
        {
            SendKeys(issueTitleField, issueTitle, nameof(issueTitleField));
            SendKeys(issueBodyField, issueBody, nameof(issueBodyField));
            Click(submitBtn, nameof(submitBtn));
        }
    }
}
