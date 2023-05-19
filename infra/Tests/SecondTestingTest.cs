// SecondTestingTest.cs (Example test class)
using infra.PageObjects;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;

namespace infra.Tests
{
    [TestFixture]
    [Parallelizable]
    internal class SecondTestingTest : BaseTest
    {
        [Test]
        public void SecondTest()
        {
            TestPage testPage = new TestPage(driver);
            testPage.GoToSignIn();
            //Thread.Sleep(10000);
        }

    }
}
