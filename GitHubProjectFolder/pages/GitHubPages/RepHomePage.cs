using System;
using System.ComponentModel;
using OpenQA.Selenium;

namespace GitHub.pages.GitHubPages
{
    class RepHomePage : GitHubPage
    {
        private By repHomePageTabs;

        public RepHomePage ()
        {
            this.repHomePageTabs = By.CssSelector(".UnderlineNav-body li [data-content]");
        }

        public GitHubPage SwitchToTab(RepHomePageTabs tabName)
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
        public enum RepHomePageTabs
        {
            [Description("Issues")]
            Issues,
        }
    }
}
