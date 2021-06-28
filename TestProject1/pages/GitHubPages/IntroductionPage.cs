using OpenQA.Selenium;

namespace GitHub.pages.GitHubPages
{
    class IntroductionPage : GitHubPage
    {
        private By signInBtn;
        public IntroductionPage ()
        {
            this.signInBtn = By.CssSelector("[href = '/login']");
        }

        public LoginPage ClickLogin()
        {
            Click(signInBtn);
            return new LoginPage();
        }
    }
}
