// using static NUnit.Framework.TestContext;
//
// namespace GitHub.helpers
// {
//     public class Logger
//     {
//         // private static ExtentTest _extentTest => CurrentContext.Test.Properties.Get("TestReport") as ExtentTest;
//         // private readonly object _syncObject = new object();
//         private readonly bool _isLocalRun;
//
//         public Logger(bool isLocalRun)
//         {
//             _isLocalRun = isLocalRun;
//         }
//
//         public void Log(string step)
//         {
//             if (_isLocalRun)
//             {
//                 LocalLogger.Log(step);
//                 return;
//             }
//
//             // lock (_syncObject)
//             // {
//             //     string formattedStep = step.Replace("\r\n", "<br/>");
//             //     _extentTest.Info(formattedStep);
//             // }
//         }
//     }
// }