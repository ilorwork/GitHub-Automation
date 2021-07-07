using GitHub.config;
using OpenQA.Selenium;

namespace GitHub.pages.GitHubPages
{
    class NewRepPage : GitHubPage
    {
        private By repNameField;
        private By descriptionField;
        private By createRepBtn;

        public NewRepPage()
        {
            this.repNameField = By.Id("repository_name");
            this.descriptionField = By.Id("repository_description");
            this.createRepBtn = By.XPath("//button[contains(text(),'Create repository')]");
        }

        public RepHomePage CreateNewRep(string repName, string repDescription)
        {
            SendKeys(repNameField, repName, "Repository name");
            SendKeys(descriptionField, repDescription, "Repository description");
            Click(createRepBtn, "Create repository button");
            return new RepHomePage();
        }
    }
}
