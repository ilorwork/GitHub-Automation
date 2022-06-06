using OpenQA.Selenium;

namespace GitHub.pages.GitHubPages
{
    internal class IssuePage : GitHubPage
    {
        private readonly By closeIssueBtn;

        public IssuePage() => closeIssueBtn = By.Name("comment_and_close");

        public override bool IsDisplayed() => IsElementVisible(closeIssueBtn);
    }
}