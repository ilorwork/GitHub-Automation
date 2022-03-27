using System;
using System.Globalization;
using System.IO;
using System.Threading;
using GitHub.config;

namespace GitHub.helpers
{
    public class LocalLogger
    {
        public static void PrintLog(string message)
        {
            var config = new AutomationConfig();

            if (!config.IsLocal) return;

            var logsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Local Logs");

            try
            {
                var formattedMessage = $"[{DateTime.Now:T}]({Thread.CurrentThread.ManagedThreadId}) {message}";

                if (!Directory.Exists(logsFolder))
                {
                    Console.WriteLine("Creating logs folder: " + logsFolder);
                    Directory.CreateDirectory(logsFolder);
                }
                var date = DateTime.Today.ToString("MM-dd-yyyy", CultureInfo.InvariantCulture);
                var logFilename = $"{date}.log";
                var logFullPath = Path.Combine(logsFolder, logFilename);

                formattedMessage += Environment.NewLine;
                if (!File.Exists(logFullPath))
                {
                    File.WriteAllText(logFullPath, formattedMessage);
                }
                else
                {
                    File.AppendAllText(logFullPath, formattedMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Log Exception: {0}", ex);
            }
        }
    }
}