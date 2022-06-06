using System;
using System.ComponentModel;
using OpenQA.Selenium;

namespace GitHub.pages.GitHubPages
{
    internal class RepHomePage : GitHubPage
    {
        private readonly By repHomePageTabs;

        public RepHomePage ()
        {
            repHomePageTabs = By.CssSelector(".UnderlineNav-body li [data-content]");
        }

        public override bool IsDisplayed() => IsElementVisible(repHomePageTabs);

        private TGitHubPage SwitchToTab<TGitHubPage>(RepHomePageTabs tabName, Type returnPageType) where TGitHubPage : GitHubPage
        {
            ClickOnOptionUsingEnum(FindElements(repHomePageTabs), tabName);
            var gottenPage = (GitHubPage)Activator.CreateInstance(returnPageType);
            return (TGitHubPage)gottenPage;
        }

        public IssuesTabPage SwitchToIssuesTab()
        {
            return SwitchToTab<IssuesTabPage>(RepHomePageTabs.Issues, typeof(IssuesTabPage));
        }

        public enum RepHomePageTabs
        {
            [Description("Issues")]
            Issues,
        }
    }
}
