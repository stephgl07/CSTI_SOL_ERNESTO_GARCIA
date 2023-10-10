using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOL.Domain.Services.Logger
{
    public interface ILoggerService
    {
        void InsertLog(string logType, string message);
    }
}
