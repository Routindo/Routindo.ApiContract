using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Routindo.Contract.Arguments;
using Routindo.Contract.Services;

namespace Routindo.Contract.Tests.Mock
{
    class ArgumentMapperMock: IArgumentsMapper
    {
        public string Id { get; set; }
        public ILoggingService LoggingService { get; set; }
        public ArgumentCollection Map(ArgumentCollection arguments)
        {
            throw new NotImplementedException();
        }
    }
}
