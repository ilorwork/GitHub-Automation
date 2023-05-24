using GitHubAutomation.Pages;
using infra.AutomationInfra;

namespace GitHubAutomation.Tests
{
    [Parallelizable]
    internal class SignIn : BaseTest
    {
        [Test]
        [Category(Categories.Login), Category(Categories.SanityTest), Category(Categories.RegressionTest)]
        [TestCase("githubcsharptest", "githubcsharp123")]
        //TODO: BUG- fix GMail authorization
        public void SingInTest(string userName, string password)
        {
            var introPage = new IntroductionPage(driver, logger);

            var userHomePage = introPage.ClickLogin()
                .Signin(userName, password);

            Assert.True(userHomePage.IsDisplayed());
        }
    }
}
