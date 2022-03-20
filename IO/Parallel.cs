using System;
using System.Threading;
using System.Diagnostics;

namespace IO
{
    class Data
    {
        public CancellationTokenSource cts;
        public int ThreadNumber;
    }

    internal class Parallel
    {
        public static void Main()
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            for(int i = 0; i < 10; i++)
            {
                new Thread(TenThreads).Start(new Data { cts=cts,ThreadNumber=i+1} );
                Thread.Sleep(100);
            }
        }

        public static void TenThreads(object pam)
        {
            Data data = (Data)pam;

            if (data.cts.IsCancellationRequested)
            {
                Console.WriteLine($"Thread canceled {data.cts.IsCancellationRequested} {data.ThreadNumber}");
                return;
            }
            else
            {
                Console.WriteLine($"{data.cts.IsCancellationRequested} {data.ThreadNumber}");
            }
            if (data.ThreadNumber == 3)
            {
                data.cts.Cancel();
            }
        }

        public static void ThreadsDemo()
        {
            Thread t1 = new Thread(ThreadProc);
            t1.Start(1);
            t1.Join();

            Thread t2 = new Thread(ThreadProc);
            t2.Start(2);
            t2.Join();

            CancellationTokenSource cts = new CancellationTokenSource();
            cts.Cancel();

            new Thread(CancelThread).Start(cts.Token);

            Console.WriteLine("ThreadsDemo");
        }

        public static void ThreadProc(object num)
        {
            Console.WriteLine($"ThreadProc {num} {DateTime.Now.Millisecond}");
        }

        public static void CancelThread(object par)
        {
            Console.WriteLine("CancelThread Start");

            CancellationToken token = (CancellationToken)par;
            
            for(int i = 0; i < 100; i++)
            {
                Thread.Sleep(10);
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("CancelThread Canceled");
                    return;
                }
            }

            Console.WriteLine("CancelThread Stop");
        }

    }
}

