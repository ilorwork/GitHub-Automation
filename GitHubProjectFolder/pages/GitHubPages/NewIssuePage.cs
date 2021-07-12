using OpenQA.Selenium;

namespace GitHub.pages.GitHubPages
{
    class NewIssuePage : IssuesTabPage
    {
        private readonly By titleField;
        private readonly By bodyField;
        private readonly By submitBtn;

        public NewIssuePage()
        {
            this.titleField = By.Id("issue_title");
            this.bodyField = By.Id("issue_body");
            this.submitBtn = By.CssSelector("[data-view-component='true'].btn-primary.btn");
        }

        // protected override void AssertInPage()
        // {
        //     WaitForElementToBeVisible(submitBtn);
        // }

        protected override string GetPageName() => "New Issue Page";

        public void CreateNewIssue(string issueTitle, string IssueBody)
        {
            SendKeys(titleField, issueTitle, "Issue title");
            SendKeys(bodyField, IssueBody, "Issue body");
            Click(submitBtn, "Submit button");
        }
    }
}
