using OpenQA.Selenium;

namespace GitHub.pages.GitHubPages
{
    internal class IssuePage : GitHubPage
    {
        private readonly By closeIssueBtn;

        public IssuePage()
        {
            this.closeIssueBtn = By.Name("comment_and_close");
        }

        public override bool IsDisplayed()
        {
            return IsElementVisible(closeIssueBtn);
        }
    }
}