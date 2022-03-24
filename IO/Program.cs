using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace IO
{
    internal class Program
    {

        static async Task Main()
        {
            //var r =new DataTable().Compute("5+612", null);
            //Console.WriteLine(r);
            await Sum.StartSum();

        }


    }
}
