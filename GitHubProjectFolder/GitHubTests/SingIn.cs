using GitHub.helpers;
using NUnit.Framework;

namespace GitHub.GitHubTests
{
    [Parallelizable]
    public class SingIn : BaseTest
    {
        //[Repeat(2)]
        //[Retry(2)]
        [Test, Order(1)]
        [Category(Categories.Login), Category(Categories.SanityTest), Category(Categories.RegressionTest)]
        [TestCase("githubcsharptest", "githubcsharp123")]
        //TODO: Add- DDT for login test
        //TODO: BUG- fix gmail authorization
        public void SingInTest(string userName, string password)
        {
            TestRunner(() =>
            {
                var introPage = GetIntroductionPage();
                
                introPage.ClickLogin()
                    .Signin(userName, password);
                //wait until homepage/authorization is show
                //TODO: Assert here
            });
        }
    }
}