using Microsoft.Extensions.Logging;
using SOL.Domain.Services.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOL.Application.Services.Logger
{
    public class LoggerService : ILoggerService
    {
        private readonly ILogger<LoggerService> _logger;
        public LoggerService(ILogger<LoggerService> logger)
        {
            _logger = logger;
        }
        public void InsertLog(string logType, string message)
        {
            switch (logType)
            {
                case "Error":
                    _logger.LogError(message);
                    break;
                case "Information":
                    _logger.LogInformation(message);
                    break;
                default:
                    _logger.LogInformation(message);
                    break;
            }
        }

    }
}
