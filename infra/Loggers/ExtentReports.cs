using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Utils;
using infra.Helpers;

namespace infra.Loggers
{
    /// <summary>
    /// Represents a logger implementation using ExtentReports for logging test information and generating reports.
    /// </summary>
    public class ExtentReportsLogger : ILogger
    {
        /// <summary>
        /// The ExtentReports instance used for generating the reports.
        /// </summary>
        private static ExtentReports extent;

        /// <summary>
        /// The singleton instance of the ExtentReportsLogger class.
        /// </summary>
        private static ExtentReportsLogger extentLogger;

        /// <summary>
        /// The current ExtentTest instance representing a test within the report.
        /// </summary>
        private ExtentTest test;

        /// <summary>
        /// This constructor is marked as private to enforce the singleton pattern.
        /// </summary>
        private ExtentReportsLogger()
        {
        }

        /// <summary>
        /// Gets the singleton instance of the <see cref="ExtentReportsLogger"/> class.
        /// </summary>
        /// <param name="reportPath">The path where the ExtentReports should be generated. If not specified, a default path is used.</param>
        /// <returns>The singleton instance of the <see cref="ExtentReportsLogger"/> class.</returns>
        public static ExtentReportsLogger GetInstance(string reportPath = null)
        {
            if (extent == null)
            {
                var createdPath = handleReportPathCreation(reportPath);

                var htmlReporter = new ExtentHtmlReporter(createdPath);
                extent = new ExtentReports();
                extent.AttachReporter(htmlReporter);

                extentLogger = new ExtentReportsLogger();
            }

            return extentLogger;
        }

        /// <summary>
        /// Starts a new test with the specified name and description.
        /// </summary>
        /// <param name="testName">The name of the test.</param>
        /// <param name="testDescription">The description of the test (optional).</param>
        public void StartTest(string testName, string testDescription = null)
        {
            test = extent.CreateTest(testName, testDescription);
        }

        /// <summary>
        /// Logs an informational message for the current test.
        /// </summary>
        /// <param name="message">The informational message to log.</param>
        public void LogInfo(string message)
        {
            test.Log(Status.Info, message);
        }

        /// <summary>
        /// Logs a pass message for the current test.
        /// </summary>
        /// <param name="message">The pass message to log.</param>
        public void LogPass(string message)
        {
            test.Log(Status.Pass, message);
        }

        /// <summary>
        /// Logs a fail message for the current test.
        /// </summary>
        /// <param name="message">The fail message to log.</param>
        public void LogFail(string message)
        {
            test.Log(Status.Fail, message);
        }

        /// <summary>
        /// Ends the current test. [Obsolete]
        /// </summary>
        /// <param name="testName">The name of the test to end. If not specified, the current test is ended.</param>
        [Obsolete]
        public void EndTest(string testName = "")
        {
            // No need to flush the extent instance here
        }

        /// <summary>
        /// Flushes the ExtentReports instance, generating the reports and saving them to the specified location.
        /// </summary>
        public static void FlushExtentReports()
        {
            extent.Flush();
        }

        /// <summary>
        /// Handles the creation of the report path.
        /// If the report path is not specified, a default path is used based on the solution directory.
        /// </summary>
        /// <param name="reportPath">The specified report path. If not specified, a default path is used.</param>
        /// <returns>The final report path.</returns>
        private static string handleReportPathCreation(string reportPath = "")
        {
            if (reportPath.IsNullOrEmpty())
            {
                reportPath = HelpersMethods.GetSolutionDirectory();
            }

            string timestamp = HelpersMethods.GetTimestamp();
            reportPath = Path.Combine(reportPath, "Reports", "ExtentReports", timestamp, "Reports");
            // Create the directory if it doesn't exist
            Directory.CreateDirectory(reportPath);
            return reportPath;
        }
    }
}
