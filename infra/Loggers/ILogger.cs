public interface ILogger
{
    void StartTest(string testName, string testDescription = null);
    void LogInfo(string message);
    void LogPass(string message);
    void LogFail(string message);
    void EndTest(string testName = null);
}
