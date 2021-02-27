namespace Umator.Contract.Services
{
    public interface ILoggingService
    {
        void Trace(string log);
        void Debug(string log);
        void Info(string log);
        void Error(string log);
        void Fatal(string log);
    }
}
