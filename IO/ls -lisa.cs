using System;
using System.IO;


namespace IO
{
    internal class Program
    {
        const string CurDir = "./";

        public static string GetProjectRoot()
        {
            string dir = Directory.GetCurrentDirectory();
            int binIndex = Directory.GetCurrentDirectory().IndexOf("bin");
            return dir.Remove(binIndex - 1);


            //return Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString()).ToString();

        }

        static void Main(string[] args)
        {
            string root = GetProjectRoot();
            Console.WriteLine(root);




            using (var sr = new StreamReader(root + "/TextFile1.txt"))
            {
                Console.WriteLine(sr.ReadToEnd());

            }
            return;





















            foreach (var i in Directory.EnumerateDirectories(root))
            {

                Console.WriteLine("{1, -15} {0, -5}", i, Directory.GetCreationTime(i).ToShortDateString());
            }
            foreach (var i in Directory.EnumerateFiles(root))
            {

                Console.WriteLine("{1, -15} {0, -5}", i, Directory.GetCreationTime(i).ToShortDateString());
            }




            Console.WriteLine("Enter DIR name for search: ");
            string dirName = Console.ReadLine();
            dirName = "*" + dirName + "*";
            Console.WriteLine("Directories found in directory "+Directory.GetCurrentDirectory());
            foreach(var i in Directory.EnumerateDirectories(CurDir, dirName))
            {
                
                Console.WriteLine("{1, -15} {0, -5}", i,Directory.GetCreationTime(i).ToShortDateString());
            }

            
            Console.WriteLine("Enter file name for search: ");
            string fileName = Console.ReadLine();
            Console.WriteLine("Files found in directory "+Directory.GetCurrentDirectory());
            fileName = "*" + fileName + "*";
            Console.WriteLine("Files found: ");
            foreach (var i in Directory.EnumerateFiles(CurDir, fileName))
            {

                Console.WriteLine("{0, -30} {1, 5}", i,Directory.GetCreationTime(i).ToShortDateString());
            }


            //foreach (var i in Directory.EnumerateDirectories(CurDir))
            //{
            //    Console.WriteLine("{0} {1} <DIR> {2}", Directory.GetCreationTime(i).ToShortDateString(), Directory.GetCreationTime(i).ToShortTimeString(),i);

            //}

            //foreach (var i in Directory.EnumerateFiles(CurDir))
            //{

            //    Console.WriteLine("{0} {1} {3} bytes {2}", Directory.GetCreationTime(i).ToShortDateString(), Directory.GetCreationTime(i).ToShortTimeString(),i, new System.IO.FileInfo(i).Length);


            //}

        }
    }
}
