using OpenQA.Selenium;

namespace GitHubProject
{
    class UserHomePage : BasePage
    {
        private By newMenuBtn;
        private By newRepBtn;

        public UserHomePage ()
        {
            this.NewMenuBtn = By.CssSelector("summary[aria-label = 'Create new…']");
            this.NewRepBtn = By.CssSelector("[role = 'menuitem'][href = '/new']");
        }

        public By NewMenuBtn { get => newMenuBtn; set => newMenuBtn = value; }
        public By NewRepBtn { get => newRepBtn; set => newRepBtn = value; }
    }
}
