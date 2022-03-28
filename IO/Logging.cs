using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
namespace IO
{
    internal class Logging
    {
        private static NLog.Config.LoggingConfiguration config;
        private static Logger logger;

        public static void CodeSetup()
        {

            config = new NLog.Config.LoggingConfiguration();
            var console = new NLog.Targets.ConsoleTarget("console");
            config.AddRule(LogLevel.Trace, LogLevel.Fatal, console);
            var file = new NLog.Targets.FileTarget("file") { FileName = "Log.txt", };
            config.AddRule(LogLevel.Trace, LogLevel.Fatal, file);

            LogManager.Configuration = config;
            logger = LogManager.GetCurrentClassLogger();

            Console.WriteLine("hi universe");
            logger.Trace("testing trace");
            LogManager.Shutdown();

        }

    }
}
