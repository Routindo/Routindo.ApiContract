using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Routindo.Contract.Actions;
using Routindo.Contract.Arguments;
using Routindo.Contract.Services;

namespace Routindo.Contract.Tests.Mock
{
    public class ActionMock: IAction
    {
        public string Id { get; set; }
        public ILoggingService LoggingService { get; set; }
        public ActionResult Execute(ArgumentCollection arguments)
        {
            return ActionResult.Succeeded();
        }
    }
}
