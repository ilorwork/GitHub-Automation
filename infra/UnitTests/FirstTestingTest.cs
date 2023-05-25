// FirstTestingTest.cs (Example test class)
using infra.AutomationInfra;
using infra.UnitTests.TestPages;
using NUnit.Framework;

namespace infra.UnitTests
{
    [TestFixture]
    [Parallelizable]
    internal class FirstTestingTest : BaseTest
    {
        [Test]
        public void FirstTest()
        {
            TestPage testPage = new TestPage(driver, logger);
            testPage.GoToSignIn();
            //Thread.Sleep(10000);
        }
    }
}
