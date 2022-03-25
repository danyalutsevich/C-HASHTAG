using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data;

namespace IO
{
    internal class Program
    {
        static async Task Main()
        {

            foreach (var d in await Callback.ParseDictAsync(await Callback.ReadFileAnotherWay())) { Console.WriteLine(d); }

            var dict = await Callback.ReadFileAnotherWay().ContinueWith(t => { return Callback.ParseDictAsync(t.Result).Result; });

            Console.WriteLine(dict["x"]);




        }


    }
}
