using OpenQA.Selenium;

namespace GitHub.pages.GitHubPages
{
    class LoginPage : GitHubPage
    {
        private readonly By userNameField;
        private readonly By passwordField;
        private readonly By signInBtn;

        public LoginPage ()
        {
            this.userNameField = By.Id("login_field");
            this.passwordField = By.Id("password");
            this.signInBtn = By.CssSelector("#login [type='submit']");
        }

        // protected override void AssertInPage()
        // {
        //     WaitForElementToBeVisible(signInBtn);
        // }

        protected override string GetPageName() => "Login Page";

        public UserHomePage Signin(string userName, string password)
        {
            SendKeys(userNameField, userName, "User-Name");
            SendKeys(passwordField, password, "Password");
            Click(signInBtn, "Sign-In button");
            return new UserHomePage();
        }
    }
}