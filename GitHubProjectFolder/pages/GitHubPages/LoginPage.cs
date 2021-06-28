using OpenQA.Selenium;

namespace GitHub.pages.GitHubPages
{
    class LoginPage : GitHubPage
    {
        private By userNameField;
        private By passwordField;
        private By signInBtn;

        public LoginPage ()
        {
            this.userNameField = By.Id("login_field");
            this.passwordField = By.Id("password");
            this.signInBtn = By.CssSelector("#login [type='submit']");
        }
        public UserHomePage Signin(string userName, string password)
        {
            SendKeys(userNameField, userName);
            SendKeys(passwordField, password);
            Click(signInBtn);
            return new UserHomePage();
        }
    }
}