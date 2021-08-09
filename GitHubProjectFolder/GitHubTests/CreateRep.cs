using GitHub.helpers;
using NUnit.Framework;

namespace GitHub.GitHubTests
{
    [Parallelizable]
    internal class CreateRep : BaseTest
    {
        [Test]
        [Category(Categories.Repository), Category(Categories.SanityTest), Category(Categories.RegressionTest)]
        //TODO: Add- DDT for createRep test
        public void CreateRepTest()
        {
            TestRunner(() =>
            {
                #region
                const string userName = "githubcsharptest";
                const string password = "githubcsharp123";
                string repName = $"rep no {ExtensionsMethods.CreateRandomNumber()}";
                string repDescription = $"{repName} Description";
                #endregion

                var introPage = GetIntroductionPage();

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