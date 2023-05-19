using NUnit.Framework;

namespace infra.Loggers
{
    internal class LoggerFactory
    {
        public static ILogger CreateLogger()
        {
            string logger = TestContext.Parameters.Get("Logger");

            switch (logger.ToLower())
            {
                case "localfile":
                    return LocalLogger.GetInstance();
                case "extentreports":
                    return ExtentReportsLogger.GetInstance();
                default:
                    throw new NotImplementedException($"Logger: {logger} isn't implemented");
            }
        }
    }
}
