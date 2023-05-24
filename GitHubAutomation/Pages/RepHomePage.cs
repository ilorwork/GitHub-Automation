using OpenQA.Selenium;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace GitHubAutomation.Pages
{
    internal class RepHomePage : GitHubPage
    {
        private readonly By repHomePageTabs;

        public RepHomePage(IWebDriver driver, ILogger logger) : base(driver, logger)
        {
            repHomePageTabs = By.CssSelector(".UnderlineNav-body li a");
        }

        public override bool IsDisplayed() => Bot.IsElementVisible(repHomePageTabs);

        private TGitHubPage SwitchToTab<TGitHubPage>(RepHomePageTabs tabName, Type returnPageType) where TGitHubPage : GitHubPage
        {
            Bot.ClickOnOptionUsingEnum(Bot.FindElements(repHomePageTabs), tabName);

            var constructorArgs = new object[] { driver, logger };
            var gottenPage = (GitHubPage)Activator.CreateInstance(returnPageType, constructorArgs);
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
