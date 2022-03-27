using GitHub.helpers;
using NUnit.Framework;

namespace GitHub.GitHubTests
{
    [Parallelizable]
    internal class CreateIssue : BaseTest
    {
        [Test, Order(3), Retry(Retries)]
        [Category(Categories.Issue), Category(Categories.SanityTest), Category(Categories.RegressionTest)]
        //TODO: Add- DDT for createRep test
        //TODO: optional bug - rep name already exist.
        public void CreateIssueTest()
        {
            TestRunner(() =>
            {
                #region
                const string userName = "githubcsharptest";
                const string password = "githubcsharp123";
                var repName = $"rep no {ExtensionsMethods.CreateRandomNumber()}";
                var repDescription = $"{repName} Description";
                const string issueTitle = "Why?";
                const string issueBody = "Because";
                #endregion

                var introPage = GetIntroductionPage();

                var userHomePage = introPage.ClickLogin()
                    .Signin(userName, password);

                var newRepPage = userHomePage.OpenNewMenu()
                    .ChooseNewRepOption();

                var repHomePage = newRepPage.CreateNewRep(repName, repDescription);

                var issuesTab = repHomePage.SwitchToIssuesTab();
                var createIssuePage = issuesTab.NewIssue();

                var issuePage = createIssuePage.CreateNewIssue(issueTitle, issueBody);
                Assert.True(issuePage.IsDisplayed());
            });
        }
    }
}