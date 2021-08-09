using OpenQA.Selenium;

namespace GitHub.pages.GitHubPages
{
    internal class IntroductionPage : GitHubPage
    {
        private readonly By signInBtn;
        public IntroductionPage ()
        {
            this.signInBtn = By.CssSelector("[href = '/login']");
        }

        public override bool IsDisplayed()
        {
            return IsElementVisible(signInBtn);
        }

        public LoginPage ClickLogin()
        {
            Click(signInBtn, nameof(signInBtn));
            return new LoginPage();
        }
    }
}
