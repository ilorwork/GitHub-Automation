using System;
using GitHub.config;
using GitHub.pages.GitHubPages;
using NUnit.Framework;

namespace GitHub.GitHubTests
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
            DateTime startTime = DateTime.UtcNow;

            try
            {
                test();
            }
            catch (Exception e)
            {
                Log($"Test Failed: {e}");
                Assert.Fail(e.ToString());
            }

            DateTime endTime = DateTime.UtcNow;
            TimeSpan testDuration = endTime - startTime;
            Log("Test Duration: "+ new TimeSpan(testDuration.Minutes, testDuration.Seconds, 0).ToString().Replace(":00", ""));
        }

        public IntroductionPage GetIntroductionPage()
        {
            return new IntroductionPage();
        }
    }
}
