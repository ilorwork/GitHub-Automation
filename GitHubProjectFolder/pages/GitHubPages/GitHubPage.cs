using GitHub.config;

namespace GitHub.pages.GitHubPages
{
    internal abstract class GitHubPage : BasePage
    {
        public abstract bool IsDisplayed();
    }
}
