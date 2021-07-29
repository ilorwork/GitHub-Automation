using OpenQA.Selenium;

namespace GitHub.pages.GitHubPages
{
    public class NewRepPage : GitHubPage
    {
        private readonly By repNameField;
        private readonly By repDescriptionField;
        private readonly By createRepBtn;

        public NewRepPage()
        {
            this.repNameField = By.Id("repository_name");
            this.repDescriptionField = By.Id("repository_description");
            this.createRepBtn = By.XPath("//button[contains(text(),'Create repository')]");
        }

        public RepHomePage CreateNewRep(string repName, string repDescription)
        {
            SendKeys(repNameField, repName, nameof(repNameField));
            SendKeys(repDescriptionField, repDescription, nameof(repDescriptionField));
            Click(createRepBtn, nameof(createRepBtn));
            return new RepHomePage();
        }
    }
}
