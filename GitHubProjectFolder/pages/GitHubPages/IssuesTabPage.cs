using OpenQA.Selenium;

namespace GitHub.pages.GitHubPages
{
    class IssuesTabPage : RepHomePage
    {
        private readonly By newIssueBtn;

        public IssuesTabPage()
        {
            this.newIssueBtn = By.XPath("//span[contains(text(),'New issue')]");
        }

        // protected override void AssertInPage()
        // {
        //     WaitForElementToBeVisible(newIssueBtn);
        // }

        protected override string GetPageName() => "Issues-Tab Page";

        public NewIssuePage NewIssue()
        {
            Click(newIssueBtn , "New issue button");
            return new NewIssuePage();
        }
    }
}
