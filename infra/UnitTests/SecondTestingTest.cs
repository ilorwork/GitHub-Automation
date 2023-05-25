// SecondTestingTest.cs (Example test class)
using infra.AutomationInfra;
using infra.UnitTests.TestPages;
using NUnit.Framework;

namespace infra.UnitTests
{
    [TestFixture]
    [Parallelizable]
    internal class SecondTestingTest : BaseTest
    {
        [Test]
        public void SecondTest()
        {
            TestPage testPage = new TestPage(driver, logger);
            testPage.GoToSignIn();
            //Thread.Sleep(10000);
        }

    }
}
