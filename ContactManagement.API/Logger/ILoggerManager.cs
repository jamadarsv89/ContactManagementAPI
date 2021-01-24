namespace ContactManagement.API.Logger
{
    public interface ILoggerManager
    {
        void LogInformation(string message);
        void LogDebug(string message);
        void LogWarn(string message);
        void LogError(string message);
        void LogFatal(string message);
    }
}
