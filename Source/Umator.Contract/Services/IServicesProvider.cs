using System;

namespace Umator.Contract.Services
{
    public interface IServicesProvider
    {
        ILoggingService GetLoggingService(string name, Type type = null);

        IEnvironmentService GetEnvironmentService();
    }
}
