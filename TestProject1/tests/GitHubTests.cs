using NUnit.Framework;
using System.Threading;

namespace GitHubProject
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
            driver.Url = "https://github.com";
            driver.Manage().Window.Maximize();
        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
        }

        [Test, Order(1)]
        public void Test01_SingIn()
        {
            click(intro.SignInBtn);
            login.Signin(userName, password);
        }
        [Test, Order(2)]
        public void Test02_CreateRep()
        {
            click(home.NewMenuBtn);
            click(home.NewRepBtn);

            sendKeys(newRep.RepNameField, repName);
            sendKeys(newRep.DescriptionField, repDescription);
            click(newRep.CreateRepBtn);
        }
        [Test, Order(3)]
        public void Test03_CreateIssue() 
        { 
            click(repHome.IssuesTab);
            click(issuesTab.NewIssueBtn);
            sendKeys(newIssue.TitleField, issueTitle);
            sendKeys(newIssue.BodyField, IssueBody);
            click(newIssue.SubmitBtn);
        }
    }
}