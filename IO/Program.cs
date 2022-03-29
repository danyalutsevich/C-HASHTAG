using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data;
using System.IO;
using NLog;

namespace IO
{
    internal class Program
    {
        private static Logger log;

        static void Main()
        {

            Logging.FileCheck(@"nlog.config");
            Logging.Finalize();

        }


    }
}
