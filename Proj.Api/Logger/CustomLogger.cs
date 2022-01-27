using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLog;

namespace Proj.Api.Logger
{
    public class CustomLogger : ICustomLogger
    {
        private static readonly NLog.ILogger logger = LogManager.GetCurrentClassLogger();
        public CustomLogger()
        {

        }
        public void Info(string message)
        {
            logger.Info(message);
        }
        public void Warn(string message)
        {
            logger.Warn(message);
        }
        public void Debug(string message)
        {
            logger.Debug(message);
        }

        public void Error(string message)
        {
            logger.Error(message);
        }

        public void Error(Exception e)
        {
            logger.Error(e);
        }
       
    }
}
