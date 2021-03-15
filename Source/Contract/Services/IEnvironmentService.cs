namespace Routindo.Contract.Services
{
    public interface IEnvironmentService
    {
        string DataDirectory { get; }  

        string LogsDirectory { get; }

        string ConfigDirectory { get; }
    }
}
