using System;
using System.ComponentModel;
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

        private GitHubPage SwitchToTab(RepHomePageTabs tabName)
        {
            ClickOnOptionUsingEnum(FindElements(repHomePageTabs), tabName);
            switch (tabName)
            {
                case RepHomePageTabs.Issues:
                    return new IssuesTabPage();
                default:
                    throw new Exception($"could not return any page for this option: {tabName}");
            }
        }

        public IssuesTabPage SwitchToIssuesTab()
        {
            return (IssuesTabPage)SwitchToTab(RepHomePageTabs.Issues);
        }

        public enum RepHomePageTabs
        {
            [Description("Issues")]
            Issues,
        }
    }
}
