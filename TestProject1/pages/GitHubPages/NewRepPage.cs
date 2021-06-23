using GitHub.config;
using OpenQA.Selenium;

namespace GitHub.pages.GitHubPages
{
    class NewRepPage : BasePage
    {
        private By repNameField;
        private By descriptionField;
        private By createRepBtn;

        public NewRepPage()
        {
            this.RepNameField = By.Id("repository_name");
            this.DescriptionField = By.Id("repository_description");
            this.CreateRepBtn = By.XPath("//button[contains(text(),'Create repository')]");
        }

        public By RepNameField { get => repNameField; set => repNameField = value; }
        public By DescriptionField { get => descriptionField; set => descriptionField = value; }
        public By CreateRepBtn { get => createRepBtn; set => createRepBtn = value; }
    }
}
