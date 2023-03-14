using System;
using System.Diagnostics;
using GitHub.config;
using GitHub.pages.GitHubPages;
using NUnit.Framework;

namespace GitHub.GitHubTests
{
    [TestFixture]
    public class BaseTest : BasePage
    {
        //TODO: need to load from configuration file/class.
        private const string GitHubUrl = "https://github.com";

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            try
            {
                Log($"*** Test started: {TestContext.CurrentContext.Test.Name} ***");
                Driver.Manage().Window.Maximize();
            }
            catch
            {
                Process[] processes = Process.GetProcessesByName("chromedriver");
                foreach (Process process in processes)
                {
                    process.Kill();
                }
            }
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Driver.Quit();
            Log($"### Test Ended: {TestContext.CurrentContext.Test.Name} ###");
        }

        public void TestRunner(Action test)
        {
            var startTime = DateTime.UtcNow;

            try
            {
                test();
            }
            catch (Exception e)
            {
                Log($"Test Failed: {e}");
                Assert.Fail(e.ToString());
            }

            var endTime = DateTime.UtcNow;
            var testDuration = endTime - startTime;
            Log("Test Duration: "+ new TimeSpan(testDuration.Minutes, testDuration.Seconds, 0).ToString().Replace(":00", ""));
        }

        internal IntroductionPage NavigateToIntroductionPage()
        {
            Driver.Url = GitHubUrl;
            Log($"Navigate to: {GitHubUrl}");
            return new IntroductionPage();
        }
    }
}
