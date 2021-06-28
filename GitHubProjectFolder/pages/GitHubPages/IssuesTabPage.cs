using OpenQA.Selenium;

namespace GitHub.pages.GitHubPages
{
    class IssuesTabPage : RepHomePage
    {
        private By newIssueBtn;

        public IssuesTabPage()
        {
            this.newIssueBtn = By.XPath("//span[contains(text(),'New issue')]");
        }

        public NewIssuePage NewIssue()
        {
            Click(newIssueBtn);
            return new NewIssuePage();
        }
    }
}
