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


            await Callback.ReadFileAnotherWay()
                .ContinueWith(t => { return Callback.ParseDictAsync(t.Result).Result; })
                .ContinueWith(d => { return Callback.DisplayDictAsync(d.Result).Result; });






        }


    }
}
