using System;
using System.IO;


namespace IO
{
    internal class Program
    {
        static void Main(string[] args)
        {

            const string path = "readThisFile.txt";
            string content=String.Empty;
            try
            {

                using (StreamReader reader = new StreamReader(path))
                {

                    content = reader.ReadToEnd();
                    Console.WriteLine(content);
                  
                }// тут будет вызват Dispose автоматически
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.ToString());
            }


            //writer.Flush();   // скинуть буфер наа диск, файл остается открытым


        }
    }
}
