// FirstTestingTest.cs (Example test class)
using infra.PageObjects;
using NUnit.Framework;

namespace infra.Tests
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
