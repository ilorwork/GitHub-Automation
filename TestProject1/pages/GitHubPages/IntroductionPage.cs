using GitHub.config;
using OpenQA.Selenium;

namespace GitHub.pages.GitHubPages
{
    class IntroductionPage : BasePage
    {
        private By signInBtn;
        public IntroductionPage ()
        {
            this.signInBtn = By.CssSelector("[href = '/login']");
        }

        public By SignInBtn { get => signInBtn; set => signInBtn = value; }
    }
}
