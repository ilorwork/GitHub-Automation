using infra.AutomationInfra;

namespace GitHubAutomation.Pages
{
    internal abstract class GitHubPage : BasePage
    {
        public GitHubPage(IWebDriver driver, ILogger logger) : base(driver, logger)
        {

        }

        public abstract bool IsDisplayed();
    }
}
