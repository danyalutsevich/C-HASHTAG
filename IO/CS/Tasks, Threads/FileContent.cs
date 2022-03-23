using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Diagnostics;


namespace IO
{
    internal class FileContent
    {
        #region async

        

        #endregion
        static async Task Main()
        {
            #region 

            //var t = Task.Run(() => GetFileContentAsync(@"IO.exe"));
            //Console.WriteLine(t.Result);

            //Console.WriteLine(GetFileContentAsync2(@"C:\Users\luche\source\repos\C#\IO\IO\.txt").Result);
            #endregion
            Stopwatch stopwatch = Stopwatch.StartNew();

            var r = GetFileContentAsync4("IO.exe");
            var r1 = GetFileContentAsync4("IO.exe");
            var r2 = GetFileContentAsync4("IO.exe");
            //Console.WriteLine(await r);

            Console.WriteLine(await r);
            Console.WriteLine(await r1);
            Console.WriteLine(await r2);

            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);

        }

        public static async Task<string> GetFileContentAsync4(string fileName)
        {
            string content;
            using (var sr = new StreamReader(fileName))
            {
                content = await sr.ReadToEndAsync();
            }
            Thread.Sleep(1000);
            return content;
        }
        
        public static async Task<string> GetFileContentAsync3(string fileName)
        {

            string content;
            using (var sr = new StreamReader(fileName))
            {
                content = sr.ReadToEnd();
            }
            return content;

        }

        public static string GetFileContentAsync(string fileName)
        {
            string content;
            using(var sr = new StreamReader(fileName))
            {
                content = sr.ReadToEnd();
            }
            return content;
        }

        public static Task<string> GetFileContentAsync2(string fileName)
        {

            return Task.Run(()=> GetFileContentAsync(fileName));

        }


    }
}
