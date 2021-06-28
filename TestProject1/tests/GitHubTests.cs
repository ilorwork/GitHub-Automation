using GitHub.config;
using GitHub.pages.GitHubPages;
using NUnit.Framework;
using GitHub.helpers;
namespace GitHub.tests
{
    [TestFixture]
    public class GitHubTests : BaseTest
    {
        //[Repeat(2)]
        [Test, Order(1)]
        [Category(Categories.Login), Category(Categories.SanityTest), Category(Categories.RegressionTest)]
        [TestCase("etoropos", "Etoro132")]
        //TODO: Add- DTD for login test
        //TODO: BUG- fix gmail autorization
        public void SingIn(string userName, string password)
        {
            #region
            IntroductionPage intro = new IntroductionPage();
            #endregion
            TestRunner(() =>
            {
                intro.ClickLogin()
                    .Signin(userName, password);
                //wait until homepage is show
                //TODO: Assert here
            });
        }

        [Test, Order(2)]
        [Category(Categories.SanityTest), Category(Categories.RegressionTest)]
        //TODO: Add- DTD for createRep test
        public void CreateRep()
        {
            #region
            IntroductionPage intro = new IntroductionPage();
            //LoginPage login = new LoginPage();
            //UserHomePage home = new UserHomePage();
            NewRepPage newRep = new NewRepPage();
            string userName = "etoropos";
            string password = "Etoro132";
            string repName = $"rep no {ExtensionsMethods.CreateRandomNumber()}";
            string repDescription = $"{repName} Description";
            #endregion
            TestRunner(() =>
            {
                intro.ClickLogin()
                    .Signin(userName, password)
                    .OpenNewMenu()
                    .ChooseOptionFromNewMenu(UserHomePage.NewMenuOptions.NewRepository);

                newRep.CreateNewRep(repName, repDescription);
                //TODO: Assert here
            });
        }

        [Test, Order(3)]
        [Category(Categories.SanityTest), Category(Categories.RegressionTest)]
        //TODO: Add- DTD for createRep test
        //TODO: optional bug - rep name already exist.
        public void CreateIssue()
        {
            #region
            IntroductionPage intro = new IntroductionPage();
            //LoginPage login = new LoginPage();
            UserHomePage home = new UserHomePage();
            NewRepPage newRep = new NewRepPage();
            RepHomePage repHome = new RepHomePage();
            //IssuesTabPage issuesTab = new IssuesTabPage();
            NewIssuePage newIssue = new NewIssuePage();
            string userName = "etoropos";
            string password = "Etoro132";
            string repName = $"rep no {ExtensionsMethods.CreateRandomNumber()}";
            string repDescription = $"{repName} Description";
            string issueTitle = "Why?";
            string IssueBody = "Because";
            #endregion
            TestRunner(() =>
            {
                intro.ClickLogin()
                    .Signin(userName, password)
                    .OpenNewMenu()
                    .ChooseOptionFromNewMenu(UserHomePage.NewMenuOptions.NewRepository);

                newRep.CreateNewRep(repName, repDescription);
                //TODO: Assert here

                var issuesTab = (IssuesTabPage)repHome.SwitchToTab(RepHomePage.RepHomePageTabs.Issues);
                issuesTab.NewIssue();
                
                newIssue.CreateNewIssue(issueTitle, IssueBody);
                //TODO: Assert here
            });
        }
    }
}