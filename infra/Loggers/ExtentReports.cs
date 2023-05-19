using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using infra.Helpers;
using System.Globalization;

namespace infra.Loggers
{
    public class ExtentReportsLogger : ILogger
    {
        private static ExtentReportsLogger instance;
        private ExtentReports extent;
        private ExtentTest test;

        private ExtentReportsLogger(string reportPath = null)
        {
            if (reportPath == null)
            {
                string timestamp = DateTime.Now.ToString("dd.MM.yyyy HH mm ss.fff",
                                            CultureInfo.InvariantCulture);

                reportPath = HelpersMethods.GetSolutionDirectory();
                reportPath = Path.Combine(reportPath, "Reports", "ExtentReports", timestamp, "Reports");
                // Create the directory if it doesn't exist
                Directory.CreateDirectory(reportPath);
            }

            var htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        public static ExtentReportsLogger GetInstance(string reportPath = null)
        {
            if (instance == null)
            {
                instance = new ExtentReportsLogger(reportPath);
            }
            return instance;
        }

        public void StartTest(string testName, string testDescription = null)
        {
            //TODO: check if there is a different between desc = null to not include it at all.
            test = extent.CreateTest(testName, testDescription);
        }

        public void LogInfo(string message)
        {
            test.Log(Status.Info, message);
        }

        public void LogPass(string message)
        {
            test.Log(Status.Pass, message);
        }

        public void LogFail(string message)
        {
            test.Log(Status.Fail, message);
        }

        public void EndTest(string testName = null)
        {
            extent.Flush();
        }
    }
}
