using GitHub.config;
using OpenQA.Selenium;

namespace GitHub.pages.GitHubPages
{
    class LoginPage : BasePage
    {
        private By userNameField;
        private By passwordField;
        private By signInBtn;

        public LoginPage ()
        {
            this.UserNameField = By.Id("login_field");
            this.PasswordField = By.Id("password");
            this.SignInBtn = By.CssSelector("#login [type='submit']");
        }
        public void Signin(string userName, string password)
        {
            SendKeys(UserNameField, userName);
            SendKeys(PasswordField, password);
            Click(SignInBtn);
        }
        public By UserNameField { get => userNameField; set => userNameField = value; }
        public By PasswordField { get => passwordField; set => passwordField = value; }
        public By SignInBtn { get => signInBtn; set => signInBtn = value; }
    }
}