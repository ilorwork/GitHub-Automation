using GitHub.helpers;
using NUnit.Framework;

namespace GitHub.GitHubTests
{
    [Parallelizable]
    internal class CreateRep : BaseTest
    {
        [Test, Retry(Retries)]
        [Category(Categories.Repository), Category(Categories.SanityTest), Category(Categories.RegressionTest)]
        public void CreateRepTest()
        {
            TestRunner(() =>
            {
                #region
                const string userName = "githubcsharptest";
                const string password = "githubcsharp123";
                var repName = $"rep no {HelpersMethods.CreateRandomNumber()}";
                var repDescription = $"{repName} Description";
                #endregion

                var introPage = NavigateToIntroductionPage();

                var userHomePage = introPage.ClickLogin()
                    .Signin(userName, password);

                var newRepPage = userHomePage.OpenNewMenu()
                    .ChooseNewRepOption();

                var repHomePage = newRepPage.CreateNewRep(repName, repDescription);
                Assert.True(repHomePage.IsDisplayed());
            });
        }
    }
}