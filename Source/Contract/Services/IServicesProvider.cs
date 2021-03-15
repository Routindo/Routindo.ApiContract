using System;

namespace Routindo.Contract.Services
{
    public interface IServicesProvider
    {
        ILoggingService GetLoggingService(string name, Type type = null);

        IEnvironmentService GetEnvironmentService();
    }
}
