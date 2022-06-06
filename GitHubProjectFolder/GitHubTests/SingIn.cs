using GitHub.helpers;
using NUnit.Framework;

namespace GitHub.GitHubTests
{
    [Parallelizable]
    internal class SingIn : BaseTest
    {
        [Test, Retry(Retries)]
        [Category(Categories.Login), Category(Categories.SanityTest), Category(Categories.RegressionTest)]
        [TestCase("githubcsharptest", "githubcsharp123")]
        //TODO: BUG- fix GMail authorization
        public void SingInTest(string userName, string password)
        {
            TestRunner(() =>
            {
                var introPage = GetIntroductionPage();
                
                var userHomePage = introPage.ClickLogin()
                    .Signin(userName, password);
                
                Assert.True(userHomePage.IsDisplayed());
            });
        }
    }
}