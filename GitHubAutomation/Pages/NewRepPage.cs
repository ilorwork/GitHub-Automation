using OpenQA.Selenium;

namespace GitHubAutomation.Pages
{
    internal class NewRepPage : GitHubPage
    {
        private readonly By repNameField;
        private readonly By validationText;
        private readonly By repDescriptionField;
        private readonly By createRepBtn;

        public NewRepPage(IWebDriver driver, ILogger logger) : base(driver, logger)
        {
            repNameField = By.Id("react-aria-2");
            validationText = By.Id("react-aria-2-validationMessage");
            repDescriptionField = By.Name("Description");
            createRepBtn = By.XPath("//button//*[contains(text(),'Create repository')]");
        }

        public override bool IsDisplayed() => Bot.IsElementVisible(repNameField);

        public RepHomePage CreateNewRep(string repName, string repDescription)
        {
            Bot.SendKeys(repNameField, repName, nameof(repNameField));
            IsRepNameValid();

            Bot.SendKeys(repDescriptionField, repDescription, nameof(repDescriptionField));
            
            Bot.ScrollToElement(createRepBtn);
            Bot.Click(createRepBtn, nameof(createRepBtn));
            return new RepHomePage(driver, logger);
        }

        private void IsRepNameValid()
        {
            string[] validTexts = { "is available", "repository will be created as" };
            Bot.WaitForElementToContainAnyText(validationText, validTexts);
        }
    }
}
