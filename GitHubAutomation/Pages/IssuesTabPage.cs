using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubAutomation.Pages
{
    internal class IssuesTabPage : RepHomePage
    {
        private readonly By newIssueBtn;

        public IssuesTabPage(IWebDriver driver, ILogger logger) : base(driver, logger)
        {
            newIssueBtn = By.XPath("//span[contains(text(),'New issue')]");
        }

        public CreateIssuePage NewIssue()
        {
            Bot.Click(newIssueBtn, nameof(newIssueBtn));
            return new CreateIssuePage(driver, logger);
        }
    }
}
