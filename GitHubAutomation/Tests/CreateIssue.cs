using GitHubAutomation.Pages;
using infra.AutomationInfra;
using infra.Helpers;

namespace GitHubAutomation.Tests
{
    [Parallelizable]
    internal class CreateIssue : BaseTest
    {
        [Test]
        [Category(Categories.Issue), Category(Categories.SanityTest), Category(Categories.RegressionTest)]
        //TODO: optional bug - rep name already exist. (Delete reps/check is exist/check for exception)
        public void CreateIssueTest()
        {
            #region
            const string userName = "githubcsharptest";
            const string password = "githubcsharp123";
            var repName = $"rep no {HelpersMethods.CreateRandomNumber()}";
            var repDescription = $"{repName} Description";
            const string issueTitle = "Why?";
            const string issueBody = "Because";
            #endregion

            var introPage = new IntroductionPage(driver, logger);

            var userHomePage = introPage.ClickLogin()
                .Signin(userName, password);

            var newRepPage = userHomePage.OpenNewMenu()
                .ChooseNewRepOption();

            var repHomePage = newRepPage.CreateNewRep(repName, repDescription);

            var issuesTab = repHomePage.SwitchToIssuesTab();
            var createIssuePage = issuesTab.NewIssue();

            var issuePage = createIssuePage.CreateNewIssue(issueTitle, issueBody);
            Assert.True(issuePage.IsDisplayed());
        }
    }
}
