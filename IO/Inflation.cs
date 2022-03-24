using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace IO
{
    internal class Inflation
    {

        public static float Price { get; set; }

        public static SemaphoreSlim semaphoreSlim { get; set; }

        static Inflation()
        {
            semaphoreSlim = new SemaphoreSlim(1, 1);
        }

        public static async Task<float> StartCountPrice(float price)
        {
         
            Price = price;
            List<Task> tasks = new List<Task>();

            for(int i = 1; i <= 12; i++)
            {
                tasks.Add(CountPrice(i));
            }

            for(int i = 0; i < tasks.Count; i++)
            {
                await tasks[i];
            }

            return Price;

        }

        private static async Task CountPrice(float percent)
        {
            semaphoreSlim.Wait();
            Price = Price + Price * ((10 + percent)/100);
            semaphoreSlim.Release();
        }


    }
}
