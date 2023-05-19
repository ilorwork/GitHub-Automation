using System.Globalization;

namespace infra.Loggers
{
    public class LocalLogger : ILogger
    {
        private static LocalLogger instance;
        private static readonly object lockObject = new object();

        private LocalLogger()
        {
            // Private constructor to prevent external instantiation
        }

        public static LocalLogger GetInstance()
        {
            lock (lockObject)
            {
                if (instance == null)
                {
                    instance = new LocalLogger();
                }
                return instance;
            }
        }

        private static void Log(string message)
        {
            var logsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Local Logs");

            try
            {
                var formattedMessage = $"[{DateTime.Now:T}]({Thread.CurrentThread.ManagedThreadId}) {message}{Environment.NewLine}";
                var date = DateTime.Today.ToString("MM-dd-yyyy", CultureInfo.InvariantCulture);
                var logFilename = $"{date}.log";
                var logFullPath = Path.Combine(logsFolder, logFilename);

                Directory.CreateDirectory(Path.GetDirectoryName(logFullPath));

                lock (lockObject)
                {
                    using (StreamWriter writer = File.AppendText(logFullPath))
                    {
                        writer.Write(formattedMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing log entry: {ex.Message}");
            }
        }

        public void StartTest(string testName, string testDescription = null)
        {
            Log($"*** Test started: {testName} ***");
            Log($"Test description: {testDescription}");
        }

        public void LogInfo(string message) => Log(message);
        public void LogPass(string message) => Log(message);
        public void LogFail(string message) => Log(message);

        public void EndTest(string testName = null)
        {
            Log($"### Test Ended: {testName} ### {Environment.NewLine}");
        }
    }
}