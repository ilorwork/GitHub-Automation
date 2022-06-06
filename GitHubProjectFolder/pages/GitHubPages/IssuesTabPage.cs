using OpenQA.Selenium;

namespace GitHub.pages.GitHubPages
{
    internal class IssuesTabPage : RepHomePage
    {
        private readonly By newIssueBtn;

        public IssuesTabPage() => newIssueBtn = By.XPath("//span[contains(text(),'New issue')]");

        public CreateIssuePage NewIssue()
        {
            Click(newIssueBtn , nameof(newIssueBtn));
            return new CreateIssuePage();
        }
    }
}
