using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NLog;

namespace IO
{
    internal class Logging
    {
        private static Logger logger;

        static Logging()
        {
            logger = LogManager.GetCurrentClassLogger();
        }

        public static bool FileCheck(string path)
        {
            if (File.Exists(path))
            {
                using (var sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        Console.WriteLine(sr.ReadLine());
                    }
                }
                return true;
            }
            else
            {
                logger.Warn($"File not found {path}");

                return false;
            }
        }

        public static void Finalize()
        {
            LogManager.Shutdown();
        }




        private static void CodeSetup()
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
        private static NLog.Config.LoggingConfiguration config;

    }
}
