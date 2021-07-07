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
        [TestCase("githubcsharptest", "githubcsharp123")]
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
        [TestCase("githubcsharptest", "githubcsharp123")]
        //TODO: Add- DTD for createRep test
        public void CreateRep(string userName, string password)
        {
            #region
            IntroductionPage intro = new IntroductionPage();
            string repName = $"rep no {ExtensionsMethods.CreateRandomNumber()}";
            string repDescription = $"{repName} Description";
            #endregion
            TestRunner(() =>
            {
                var newRep = intro.ClickLogin()
                    .Signin(userName, password)
                    .OpenNewMenu()
                    .ChooseNewRepOption();

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
            
            // string userName = "githubcsharptest";
            // string password = "githubcsharp123";
            string repName = $"rep no {ExtensionsMethods.CreateRandomNumber()}";
            string repDescription = $"{repName} Description";
            string issueTitle = "Why?";
            string IssueBody = "Because";
            #endregion
            TestRunner(() =>
            {
                var user = GetUser();
                var newRep = intro.ClickLogin()
                    .Signin(user.UserName, user.Password)
                    .OpenNewMenu()
                    .ChooseNewRepOption();

                var repHome = newRep.CreateNewRep(repName, repDescription);
                //TODO: Assert here

                var issuesTab = repHome.SwitchToIssuesTab();
                var newIssue = issuesTab.NewIssue();
                
                newIssue.CreateNewIssue(issueTitle, IssueBody);
                //TODO: Assert here
            });
        }
    }
}