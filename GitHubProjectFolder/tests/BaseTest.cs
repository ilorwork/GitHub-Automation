using System;
using GitHub.config;
using NUnit.Framework;

namespace GitHub.tests
{
    [TestFixture]
    public class BaseTest : BasePage
    {
        private readonly string url = "https://github.com";

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Driver.Url = url;
            Driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Driver.Quit();
        }

        public void TestRunner(Action test)
        {
            try
            {
                test();
            }
            catch (Exception e)
            {
                Assert.Fail(e.ToString());
            }
        }
    }
}
