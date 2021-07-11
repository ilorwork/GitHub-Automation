using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using GitHub.config;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace GitHub.helpers
{
    public class LocalLogger
    {
        private static string LogsFolder => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Local Logs");

        public static void PrintLog(string message)
        {
            try
            {
                string formattedMessage = $"[{DateTime.Now:T}]({Thread.CurrentThread.ManagedThreadId}) {message}";

                if (!Directory.Exists(LogsFolder))
                {
                    Console.WriteLine("Creating logs folder: " + LogsFolder);
                    Directory.CreateDirectory(LogsFolder);
                }
                string date = DateTime.Today.ToString("MM-dd-yyyy", CultureInfo.InvariantCulture);
                string logFilename = $"{date}.log";
                string logFullPath = Path.Combine(LogsFolder, logFilename);

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
                Console.WriteLine(ex);
            }
        }
        // private static Screenshot TakeScreenShot()
        // {
        //     var driver = AutomationConfig.Driver;
        //         while (driver != null)
        //         {
        //             if (driver is ITakesScreenshot takesScreenshot)
        //                 return takesScreenshot.GetScreenshot();
        //
        //             var wrapsDriver = driver as IWrapsDriver;
        //             driver = wrapsDriver?.WrappedDriver;
        //         }
        //
        //         throw new WebDriverException(
        //             "Cannot find an implementation of ITakesScreenshot in a chain of IWrapsDriver");
        // }
        public static string CaptureCurrentWindow(string windowHandle)
        {
            string localPath = "";
            try
            {
                Screenshot screenshot = AutomationConfig.Driver.TakeScreenshot();
        
                localPath = GetPathForAttachment("Screenshots", $"{windowHandle}.png");
                screenshot.SaveAsFile(localPath);
            }   
            catch (Exception e)
            {
                PrintLog($"Failed to save file for reporter: {e}");
            }
        
            return localPath;
        }
        private static string GetPathForAttachment(string folderName, string filenameExtension)
        {
            Regex invalidCharacters = new Regex(@"[(""/) !#$%&*.-]");
            var cleanTestName = invalidCharacters.Replace(TestContext.CurrentContext.Test.MethodName, "");
            var filename = $"{cleanTestName}.{filenameExtension}";
            var dir = LogsFolder ?? AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "").Replace(@"/bin/Debug", "");
            var fullPath = Path.Combine(dir, folderName);

            Directory.CreateDirectory(fullPath);
            var finalPath = Path.Combine(fullPath, filename);
            var localPath = new Uri(finalPath).LocalPath;
            return localPath;
        }
        private static string SafeGetCurrentWindowHandle(IWebDriver driver)
        {
            try
            {
                return driver.CurrentWindowHandle;
            }
            catch (NoSuchWindowException)
            {
                // This can happen if the current window is closed. In this case, we'll treat the first window as the current window
                return driver.WindowHandles.First();
            }
        }
    }
}