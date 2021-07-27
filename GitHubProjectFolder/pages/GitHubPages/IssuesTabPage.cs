using OpenQA.Selenium;

namespace GitHub.pages.GitHubPages
{
    public class IssuesTabPage : RepHomePage
    {
        private readonly By newIssueBtn;

        public IssuesTabPage()
        {
            this.newIssueBtn = By.XPath("//span[contains(text(),'New issue')]");
        }

        public NewIssuePage NewIssue()
        {
            Click(newIssueBtn , "New issue button");
            return new NewIssuePage();
        }
    }
}
