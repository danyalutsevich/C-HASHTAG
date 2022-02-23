using System;
using System.IO;
using System.Text;

namespace binRead
{
    internal class Program
    {
        static void Main(string[] args)
        {

            using (var stream = File.Open("C:\\Users\\luche\\Desktop\\Ukraine.hxp", FileMode.Open))
            {
                using (var reader = new BinaryReader(stream, Encoding.UTF8, false))
                {
                    Console.WriteLine(reader.ReadString());

                }
            }





        }

    }
}
