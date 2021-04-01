using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Routindo.Contract.Services;

namespace Routindo.Contract.Tests.Mock
{
    class EnvironmentServiceMock: IEnvironmentService
    {
        public string DataDirectory { get; }
        public string LogsDirectory { get; }
        public string ConfigDirectory { get; }
    }
}
