// TestPage.cs (Example page object)
using OpenQA.Selenium;

namespace infra.PageObjects
{
    internal class TestPage : BasePage
    {
        private readonly By goToSignInBtn;
        private readonly By userNameField;
        private readonly By passwordField;
        private readonly By signInBtn;

        public TestPage(IWebDriver driver, ILogger logger) : base(driver, logger)
        {
            goToSignInBtn = By.CssSelector("[href=\"/login\"]");
            userNameField = By.Id("login_field");
            passwordField = By.Id("password");
            signInBtn = By.CssSelector("#login [type='submit']");
        }

        public void GoToSignIn()
        {
            Bot.Click(goToSignInBtn);
        }
        public void SignIn(string userName, string password)
        {
            EnterUsername(userName);
            EnterPassword(password);
            ClickSignInBtn();
        }

        public void EnterUsername(string userName)
        {
            Bot.SendKeys(userNameField, userName, nameof(userNameField));
        }

        public void EnterPassword(string password)
        {
            Bot.SendKeys(passwordField, password, nameof(passwordField));
        }

        public void ClickSignInBtn()
        {
            Bot.Click(signInBtn, nameof(signInBtn));
        }
    }
}
