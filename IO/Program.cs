using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data;
using NLog;

namespace IO
{
    internal class Program
    {
        private static Logger log;

        static void Main()
        {
            log = LogManager.GetCurrentClassLogger();

            Console.Write("Enter number: ");
            try
            {
                double num = Double.Parse(Console.ReadLine());
                Console.WriteLine($"x2 { num*2}");
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }


            LogManager.Shutdown();
        }


    }
}
