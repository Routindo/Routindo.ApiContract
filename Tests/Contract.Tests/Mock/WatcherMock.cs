using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Routindo.Contract.Services;
using Routindo.Contract.Watchers;

namespace Routindo.Contract.Tests.Mock
{
    class WatcherMock: IWatcher
    {
        public string Id { get; set; }
        public ILoggingService LoggingService { get; set; }
        public WatcherResult Watch()
        {
            return WatcherResult.NotFound;
        }
    }
}
