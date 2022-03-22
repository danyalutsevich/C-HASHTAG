using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace IO
{
    internal class Sum
    {
        public static uint sum { get; set; }
        static void Main()
        {
            sum = 0;

            uint X = 0;
            do
            {
                try
                {
                    X = Convert.ToUInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            } while (X == 0);

            List<Task> tasks = new List<Task>();

            //Console.WriteLine(ThreadPool.SetMinThreads(20000, 10));

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (uint i = 1; i <= X; i++)
            {
                tasks.Add(new Task(IncreaseSum, i));
                tasks[tasks.Count - 1].Start();
            }

            Task.WaitAll(tasks.ToArray());

            stopwatch.Stop();

            Console.WriteLine($"sum: {sum}");
            Console.WriteLine($"It took {stopwatch.ElapsedMilliseconds} ms");
        }

        public static void IncreaseSum(object num)
        {
            sum += (uint)num;
        }


    }
}
