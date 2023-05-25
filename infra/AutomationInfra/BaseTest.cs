// BaseTest.cs
using infra.Loggers;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Diagnostics;
using System.Drawing;

namespace infra.AutomationInfra
{
    public class BaseTest
    {
        protected IWebDriver driver;
        protected ILogger logger = LoggerFactory.CreateLogger();


        [OneTimeSetUp]
        public void Setup()
        {
            try
            {
                logger.StartTest(TestContext.CurrentContext.Test.Name);

                // Initialize the WebDriver based on the selected browser
                WebDriverFactory webDriverFactory = new WebDriverFactory();
                driver = webDriverFactory.GetDriver();

                string siteUrl = TestContext.Parameters.Get("SiteUrl");
                driver.Navigate().GoToUrl(siteUrl);

                int width = int.Parse(TestContext.Parameters.Get("width", "0"));
                int height = int.Parse(TestContext.Parameters.Get("height", "0"));
                if (width <= 0 || height <= 0) driver.Manage().Window.Maximize();
                else driver.Manage().Window.Size = new Size(width, height);
            }
            catch
            {
                string[] processesNames = { "chromedriver" };

                if (TestContext.Parameters.Get("Browser", "").ToLower().StartsWith("grid"))
                    processesNames = processesNames.Append("chrome").ToArray();

                foreach (var name in processesNames)
                {
                    Process[] processes = Process.GetProcessesByName(name);
                    foreach (var process in processes) process.Kill();
                }
                throw;
            }
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            driver.Quit();
            logger.EndTest(TestContext.CurrentContext.Test.Name);
            ExtentReportsLogger.FlushExtentReports();
        }
    }
}
