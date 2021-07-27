using GitHub.helpers;
using GitHub.pages.GitHubPages;
using NUnit.Framework;

namespace GitHub.GitHubTests
{
    [Parallelizable]
    public class CreateRep : BaseTest
    {
        [Test]
        [Category(Categories.Repository), Category(Categories.SanityTest), Category(Categories.RegressionTest)]
        //TODO: Add- DDT for createRep test
        public void CreateRepTest()
        {
            TestRunner(() =>
            {
                #region
                IntroductionPage intro = new IntroductionPage();

                const string userName = "githubcsharptest";
                const string password = "githubcsharp123";
                string repName = $"rep no {ExtensionsMethods.CreateRandomNumber()}";
                string repDescription = $"{repName} Description";
                #endregion

                var userHomePage = intro.ClickLogin()
                    .Signin(userName, password);

                var newRepPage = userHomePage.OpenNewMenu()
                    .ChooseNewRepOption();

                newRepPage.CreateNewRep(repName, repDescription);
                //TODO: Assert here
            });
        }
    }
}