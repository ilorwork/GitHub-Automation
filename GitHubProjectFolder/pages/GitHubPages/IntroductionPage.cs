using OpenQA.Selenium;

namespace GitHub.pages.GitHubPages
{
    internal class IntroductionPage : GitHubPage
    {
        private readonly By signInBtn;
        public IntroductionPage ()
        {
            signInBtn = By.CssSelector("[href = '/login']");
        }

        public override bool IsDisplayed() => IsElementVisible(signInBtn);

        public LoginPage ClickLogin()
        {
            Click(signInBtn, nameof(signInBtn));
            return new LoginPage();
        }
    }
}
