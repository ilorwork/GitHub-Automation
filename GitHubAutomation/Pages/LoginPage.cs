namespace GitHubAutomation.Pages
{
    internal class LoginPage : GitHubPage
    {
        private readonly By userNameField;
        private readonly By passwordField;
        private readonly By signInBtn;

        public LoginPage(IWebDriver driver, ILogger logger) : base(driver, logger)
        {
            userNameField = By.Id("login_field");
            passwordField = By.Id("password");
            signInBtn = By.CssSelector("#login [type='submit']");
        }
        public override bool IsDisplayed() => Bot.IsElementVisible(signInBtn);

        public UserHomePage Signin(string userName, string password)
        {
            Bot.SendKeys(userNameField, userName, nameof(userNameField));
            Bot.SendKeys(passwordField, password, nameof(passwordField));
            Bot.Click(signInBtn, nameof(signInBtn));
            return new UserHomePage(driver, logger);
        }
    }
}
