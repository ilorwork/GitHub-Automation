using System;
using System.ComponentModel;
using System.Reflection;
using OpenQA.Selenium;

namespace GitHub.pages.GitHubPages
{
    public class RepHomePage : GitHubPage
    {
        private readonly By repHomePageTabs;

        public RepHomePage ()
        {
            this.repHomePageTabs = By.CssSelector(".UnderlineNav-body li [data-content]");
        }

        private T SwitchToTab<T>(RepHomePageTabs tabName, Type returnPageType) where T : GitHubPage
        {
            ClickOnOptionUsingEnum(FindElements(repHomePageTabs), tabName);
            var gottenPage = (GitHubPage)Activator.CreateInstance(returnPageType);
            Log($"%%%%%%%%%%%%%%%%% {gottenPage.GetType()} %%%%%%%%%%%%%%%");
            return (T)gottenPage;
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
