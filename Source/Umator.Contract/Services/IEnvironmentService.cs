using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umator.Contract.Services
{
    public interface IEnvironmentService
    {
        string DataDirectory { get; }  

        string LogsDirectory { get; }

        string ConfigDirectory { get; }
    }
}
