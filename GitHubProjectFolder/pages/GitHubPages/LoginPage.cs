using OpenQA.Selenium;

namespace GitHub.pages.GitHubPages
{
    internal class LoginPage : GitHubPage
    {
        private readonly By userNameField;
        private readonly By passwordField;
        private readonly By signInBtn;

        public LoginPage ()
        {
            userNameField = By.Id("login_field");
            passwordField = By.Id("password");
            signInBtn = By.CssSelector("#login [type='submit']");
        }
        public override bool IsDisplayed() => IsElementVisible(signInBtn);

        public UserHomePage Signin(string userName, string password)
        {
            SendKeys(userNameField, userName, nameof(userNameField));
            SendKeys(passwordField, password, nameof(passwordField));
            Click(signInBtn, nameof(signInBtn));
            return new UserHomePage();
        }
    }
}