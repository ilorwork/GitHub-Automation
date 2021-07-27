using GitHub.helpers;
using GitHub.pages.GitHubPages;
using NUnit.Framework;

namespace GitHub.GitHubTests
{
    [Parallelizable]
    public class CreateIssue : BaseTest
    {
        [Test, Order(3)]
        [Category(Categories.Issue), Category(Categories.SanityTest), Category(Categories.RegressionTest)]
        //TODO: Add- DDT for createRep test
        //TODO: optional bug - rep name already exist.
        public void CreateIssueTest()
        {
            TestRunner(() =>
            {
                #region
                IntroductionPage intro = new IntroductionPage();

                const string userName = "githubcsharptest";
                const string password = "githubcsharp123";
                string repName = $"rep no {ExtensionsMethods.CreateRandomNumber()}";
                string repDescription = $"{repName} Description";
                const string issueTitle = "Why?";
                const string issueBody = "Because";
                #endregion

                var userHomePage = intro.ClickLogin()
                    .Signin(userName, password);

                var newRepPage = userHomePage.OpenNewMenu()
                    .ChooseNewRepOption();

                var repHomePage = newRepPage.CreateNewRep(repName, repDescription);
                //TODO: Assert here ?

                var issuesTab = repHomePage.SwitchToIssuesTab();
                var newIssuePage = issuesTab.NewIssue();

                newIssuePage.CreateNewIssue(issueTitle, issueBody);
                //TODO: Assert here
            });
        }
    }
}