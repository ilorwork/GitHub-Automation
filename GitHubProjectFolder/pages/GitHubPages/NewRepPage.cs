using OpenQA.Selenium;

namespace GitHub.pages.GitHubPages
{
    internal class NewRepPage : GitHubPage
    {
        private readonly By repNameField;
        private readonly By repDescriptionField;
        private readonly By createRepBtn;

        public NewRepPage()
        {
            repNameField = By.Id("repository_name");
            repDescriptionField = By.Id("repository_description");
            createRepBtn = By.XPath("//button[contains(text(),'Create repository')]");
        }

        public override bool IsDisplayed() => IsElementVisible(repNameField);

        public RepHomePage CreateNewRep(string repName, string repDescription)
        {
            SendKeys(repNameField, repName, nameof(repNameField));
            SendKeys(repDescriptionField, repDescription, nameof(repDescriptionField));
            Click(createRepBtn, nameof(createRepBtn));
            return new RepHomePage();
        }
    }
}
