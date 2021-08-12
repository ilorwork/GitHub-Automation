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
            if (!AutomationConfig.IsLocal) return;

            string logsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Local Logs");

            try
            {
                string formattedMessage = $"[{DateTime.Now:T}]({Thread.CurrentThread.ManagedThreadId}) {message}";

                if (!Directory.Exists(logsFolder))
                {
                    Console.WriteLine("Creating logs folder: " + logsFolder);
                    Directory.CreateDirectory(logsFolder);
                }
                string date = DateTime.Today.ToString("MM-dd-yyyy", CultureInfo.InvariantCulture);
                string logFilename = $"{date}.log";
                string logFullPath = Path.Combine(logsFolder, logFilename);

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