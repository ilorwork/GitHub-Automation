using System;
using GitHub.config;
using NUnit.Framework;

namespace GitHub.tests
{
    [TestFixture]
    public class BaseTest : BasePage
    {
        private const string GitHubUrl = "https://github.com";

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Log($"*** Test started: {TestContext.CurrentContext.Test.Name} ***");
            Driver.Url = GitHubUrl;
            Driver.Manage().Window.Maximize();
            Log($"Navigate to: {GitHubUrl}");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Driver.Quit();
            Log($"### Test Ended: {TestContext.CurrentContext.Test.Name} ###");
        }

        public void TestRunner(Action test)
        {
            try
            {
                test();
            }
            catch (Exception e)
            {
                Log($"Test Failed: {e}");
                Assert.Fail(e.ToString());
            }
        }
    }
}
