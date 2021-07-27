using GitHub.helpers;
using GitHub.pages.GitHubPages;
using NUnit.Framework;

namespace GitHub.GitHubTests
{
    [Parallelizable]
    public class SingIn : BaseTest
    {
        //[Repeat(2)]
        [Test, Order(1)]
        [Category(Categories.Login), Category(Categories.SanityTest), Category(Categories.RegressionTest)]
        [TestCase("githubcsharptest", "githubcsharp123")]
        //TODO: Add- DDT for login test
        //TODO: BUG- fix gmail authorization
        public void SingInTest(string userName, string password)
        {
            TestRunner(() =>
            {
                #region
                IntroductionPage intro = new IntroductionPage();
                #endregion

                intro.ClickLogin()
                    .Signin(userName, password);
                //wait until homepage/authorization is show
                //TODO: Assert here
            });
        }
    }
}