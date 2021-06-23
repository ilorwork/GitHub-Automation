using GitHub.config;
using OpenQA.Selenium;

namespace GitHub.pages.GitHubPages
{
    class RepHomePage : BasePage
    {
        private By issuesTab;

        public RepHomePage ()
        {
            this.issuesTab = By.XPath("//span[contains(text(),'Issues')]");
        }
        public By IssuesTab { get => issuesTab; set => issuesTab = value; }
    }
}
