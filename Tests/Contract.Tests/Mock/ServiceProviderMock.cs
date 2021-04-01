using System;
using Routindo.Contract.Services;

namespace Routindo.Contract.Tests.Mock
{
    class ServicesProviderMock: IServicesProvider
    {
        public ILoggingService GetLoggingService(string name, Type type = null)
        {
            throw new NotImplementedException();
        }

        public IEnvironmentService GetEnvironmentService()
        {
            throw new NotImplementedException();
        }
    }
}
