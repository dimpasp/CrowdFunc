namespace CrowdFun.Core.model.services
{
    public interface ILoggerService
    {
        void LogError(StatusCode errorcode, string text);
        void LogInformation(string text);
    }
}
