using OpenQA.Selenium;

namespace GitHub.pages.GitHubPages
{
    public class NewRepPage : GitHubPage
    {
        private readonly By repNameField;
        private readonly By descriptionField;
        private readonly By createRepBtn;

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
