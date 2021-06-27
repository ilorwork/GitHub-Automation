using GitHub.config;
using GitHub.pages.GitHubPages;
using NUnit.Framework;

namespace GitHub.tests
{
    [TestFixture]
    public class GitHubTests : BaseTest
    {
        [Test, Order(1)]
        [Category(Categories.Login), Category(Categories.SanityTest), Category(Categories.RegressionTest)]
        //TODO: Add DTD for login test
        //[Retry (2)]
        public void SingIn()
        {
            #region
            IntroductionPage intro = new IntroductionPage();
            string userName = "etoropos";
            string password = "Etoro132";
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
        //TODO: Add DTD for createRep test
        public void CreateRep()
        {
            #region
            IntroductionPage intro = new IntroductionPage();
            //LoginPage login = new LoginPage();
            //UserHomePage home = new UserHomePage();
            NewRepPage newRep = new NewRepPage();
            string userName = "etoropos";
            string password = "Etoro132";
            string repName = "fdsa13252";
            string repDescription = "Because";
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
        //TODO: Add DTD for createRep test
        //TODO: create a string genetator for the unic names like rep name
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
            string repName = "fdsa13252";
            string repDescription = "Because";
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