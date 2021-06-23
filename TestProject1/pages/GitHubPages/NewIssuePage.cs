using OpenQA.Selenium;

namespace GitHub.pages.GitHubPages
{
    class NewIssuePage : IssuesTabPage
    {
        private By titleField;
        private By bodyField;
        private By submitBtn;

        public NewIssuePage()
        {
            this.titleField = By.Id("issue_title");
            this.bodyField = By.Id("issue_body");
            this.submitBtn = By.XPath("//button[@class = 'btn btn-primary']");
        }

        public By TitleField { get => titleField; set => titleField = value; }
        public By BodyField { get => bodyField; set => bodyField = value; }
        public By SubmitBtn { get => submitBtn; set => submitBtn = value; }
    }
}
