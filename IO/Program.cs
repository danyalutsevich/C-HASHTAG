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
            float Price=0;
            do
            {
                try
                {
                    Price = Convert.ToSingle(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (Price == 0);

            float inflationPrice = await Inflation.StartCountPrice(Price);

            Console.WriteLine($"Starting price: {Price}");
            Console.WriteLine($"Price after a year of inflation: {inflationPrice}");
            Console.WriteLine($"Price increased {inflationPrice/Price} times");
        }


    }
}
