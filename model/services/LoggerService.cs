using System;
using System.Collections.Generic;
using System.Text;
using Serilog;
using Serilog.Core;
using Microsoft.Extensions.Logging;

namespace CrowdFun.Core.model.services
{
    public class LoggerService : ILoggerService
    {
        private Logger log_;

        public LoggerService()
        {
            //log_ = new LoggerConfiguration()
            //    .WriteTo
            //    .File("log.txt", rollingInterval: RollingInterval.Day)
            //    .CreateLogger();
        }

        public void LogError(StatusCode errorcode, string text)
        {
            log_.Error("{errorcode} {text}", errorcode, text);
        }

        public void LogInformation(string text)
        {
            log_.Information(text);
        }
    }
}
