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


        #region Task return


        public static void TaskProcStart()
        {
            var taskR = Task.Run(TaskProcString);
            taskR.Wait();

            Console.WriteLine($"res: {taskR.Result}");
        }

        public static string TaskProcString()
        {
            Console.WriteLine("TaskProcS w");
            return "TaskProcS r";
        }

        #endregion  

        #region Delegate (не поддерживается современными платформами)
        delegate void VoidDelegate();
        public static void DelegateProcStart()
        {
            VoidDelegate d = DelegateProc;
            var action = d.BeginInvoke(null, null);
            Thread.Sleep(1000);
            d.EndInvoke(action);
        }

        public static void DelegateProc()
        {
            Console.WriteLine("DelegateProc");
        }


        #endregion

        #region Sum
        public static readonly object Lock = new object();

        public static uint sum { get; set; }
        static void SumStart()
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
            lock (Lock)
            {
                sum += (uint)num;
            }
        }
        #endregion

        #region Async Sum

        public static async Task StartSum()
        {
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

            uint sum = 0;

            List<Task<uint>> tasks = new List<Task<uint>>();

            ThreadPool.SetMinThreads(100, 10);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start(); 


            for (uint i = 1; i <= X; i++)
            {
                tasks.Add(SumAsync(i));
            }

            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            for (int i = 0; i < tasks.Count; i++)
            {
                sum += await tasks[i];
            }
            stopwatch.Stop();

            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Done in {stopwatch.ElapsedMilliseconds} ms");

        }

        public static async Task<uint> SumAsync(uint num)
        {
            //Thread.Sleep(1000);
            await Task.Delay(1000);
            return num;
        }




        #endregion

    }
}
