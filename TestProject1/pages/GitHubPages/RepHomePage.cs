using OpenQA.Selenium;

namespace GitHubProject
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
