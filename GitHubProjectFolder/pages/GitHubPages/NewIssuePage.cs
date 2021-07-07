using OpenQA.Selenium;

namespace GitHub.pages.GitHubPages
{
    class NewIssuePage : IssuesTabPage
    {
        private By titleField;
        private By bodyField;
        private By submitBtn;

        public NewIssuePage()
        {
            this.titleField = By.Id("issue_title");
            this.bodyField = By.Id("issue_body");
            this.submitBtn = By.CssSelector("[data-view-component='true'].btn-primary.btn");
        }

        public void CreateNewIssue(string issueTitle, string IssueBody)
        {
            SendKeys(titleField, issueTitle, "Issue title");
            SendKeys(bodyField, IssueBody, "Issue body");
            Click(submitBtn, "Submit button");
        }
    }
}
