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

        private GitHubPage SwitchToTab(RepHomePageTabs tabName, Type returnPageType)
        {
            ClickOnOptionUsingEnum(FindElements(repHomePageTabs), tabName);
            var gottenPage = (GitHubPage)Activator.CreateInstance(returnPageType);
            return gottenPage;
        }

        public IssuesTabPage SwitchToIssuesTab()
        {
            return (IssuesTabPage)SwitchToTab(RepHomePageTabs.Issues, typeof(IssuesTabPage));
        }

        public enum RepHomePageTabs
        {
            [Description("Issues")]
            Issues,
        }
    }
}
