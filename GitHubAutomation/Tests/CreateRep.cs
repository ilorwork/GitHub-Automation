using GitHubAutomation.Pages;
using infra.AutomationInfra;
using infra.Helpers;

namespace GitHubAutomation.Tests
{
    [Parallelizable]
    internal class CreateRep : BaseTest
    {
        [Test]
        [Category(Categories.Repository), Category(Categories.SanityTest), Category(Categories.RegressionTest)]
        public void CreateRepTest()
        {
            #region
            const string userName = "githubcsharptest";
            const string password = "githubcsharp123";
            var repName = $"rep no {HelpersMethods.CreateRandomNumber()}";
            var repDescription = $"{repName} Description";
            #endregion

            var introPage = new IntroductionPage(driver, logger);

            var userHomePage = introPage.ClickLogin()
                .Signin(userName, password);

            var newRepPage = userHomePage.OpenNewMenu()
                .ChooseNewRepOption();

            var repHomePage = newRepPage.CreateNewRep(repName, repDescription);
            Assert.True(repHomePage.IsDisplayed());
        }
    }
}
