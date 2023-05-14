using OpenQA.Selenium;

namespace GitHub.pages.GitHubPages
{
    internal class NewRepPage : GitHubPage
    {
        private readonly By repNameField;
        private readonly By validationText;
        private readonly By repDescriptionField;
        private readonly By createRepBtn;

        public NewRepPage()
        {
            repDescriptionField = By.Name("Description");
            repNameField = By.Id("react-aria-2");
            validationText = By.Id("react-aria-2-validationMessage");
            createRepBtn = By.XPath("//button//*[contains(text(),'Create repository')]");
        }

        public override bool IsDisplayed() => IsElementVisible(repNameField);

        public RepHomePage CreateNewRep(string repName, string repDescription)
        {
            SendKeys(repNameField, repName, nameof(repNameField));
            IsRepNameValid();

            SendKeys(repDescriptionField, repDescription, nameof(repDescriptionField));

            ScrollToElement(createRepBtn);
            Click(createRepBtn, nameof(createRepBtn));
            return new RepHomePage();
        }

        public void IsRepNameValid() {

            string[] validTexts = { "is available", "repository will be created as" };
            WaitForElementToContainAnyText(validationText, validTexts);
        }
    }
}
