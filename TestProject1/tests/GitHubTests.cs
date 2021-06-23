using GitHub.config;
using GitHub.pages.GitHubPages;
using NUnit.Framework;

namespace GitHub.tests
{
    [TestFixture]
    public class GitHubTests : BasePage
    {
        string userName = "etoropos";
        string password = "Etoro132";
        string repName = "fdsa13252";
        string repDescription = "Because";
        string issueTitle = "Why?";
        string IssueBody = "Because";
        IntroductionPage intro = new IntroductionPage();
        LoginPage login = new LoginPage();
        UserHomePage home = new UserHomePage();
        NewRepPage newRep = new NewRepPage();
        RepHomePage repHome = new RepHomePage();
        IssuesTabPage issuesTab = new IssuesTabPage();
        NewIssuePage newIssue = new NewIssuePage();

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Driver.Url = "https://github.com";
            Driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Driver.Quit();
        }

        [Test, Order(1)]
        [Category(Categories.Login), Category(Categories.SanityTest), Category(Categories.RegressionTest)]
        //[Retry (2)]
        public void Test01_SingIn()
        {
            Click(intro.SignInBtn);
            login.Signin(userName, password);
        }

        [Test, Order(2)]
        public void Test02_CreateRep()
        {
            Click(home.NewMenuBtn);
            Click(home.NewRepBtn);

            SendKeys(newRep.RepNameField, repName);
            SendKeys(newRep.DescriptionField, repDescription);
            Click(newRep.CreateRepBtn);
        }

        [Test, Order(3)]
        public void Test03_CreateIssue() 
        { 
            Click(repHome.IssuesTab);
            Click(issuesTab.NewIssueBtn);
            SendKeys(newIssue.TitleField, issueTitle);
            SendKeys(newIssue.BodyField, IssueBody);
            Click(newIssue.SubmitBtn);
        }
    }
}