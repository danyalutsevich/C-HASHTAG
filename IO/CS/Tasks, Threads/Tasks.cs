using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace IO
{
    internal class Tasks
    {
        class Programm
        {
            public static readonly object Lock = new object();

            static void TenTasksStart()
            {
                
                List<Task> tasks = new List<Task>();
                num = 0;
                //ThreadPool.SetMinThreads(10,10);
                ThreadPool.SetMinThreads(2, 0);
                for (int i = 0; i < 10; i++)
                {
                    //Task.Run(() => { TenTasks(i); });
                    tasks.Add(new Task(TenTasks, i + 1));
                    tasks[tasks.Count - 1].Start();
                }

                Task.WaitAll(tasks.ToArray());

            }
            public static int num { get; set; }
            public static void TenTasks(object startNum)
            {
                int n;
                lock (Lock)
                {
                    n = num;
                    num++;
                }
                Console.WriteLine($"Start: {startNum} {n} +");
                Thread.Sleep(1000);
                Console.WriteLine($"Start: {startNum} {n} -");
            }

            public static void TaskProc()
            {
                Console.WriteLine("TaskProc");
            }

            public static void TaskProcWithParam(object state)
            {
                Console.WriteLine("TaskProcWithParam " + state);
            }

            public static void TaskDemo()
            {

                Task task = new Task(TaskProc);
                Console.WriteLine("Before Start");
                task.Start();
                Console.WriteLine("Before Wait");
                task.Wait();
                Console.WriteLine("After Wait");


                Task task2 = new Task(TaskProcWithParam, "Hello1");
                task2.Start();
                task2.Wait();


                Task.Run(TaskProc).Wait();

                Task task4 = Task.Run(() => TaskProcWithParam("Hello2"));


            }
        }


    }
}
