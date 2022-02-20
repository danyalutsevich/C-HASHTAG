using System;
using System.IO;

namespace IO
{
    internal class FindFile
    {
        //find file in project directory

        public static string GetProjectRoot()
        {
            string dir = Directory.GetCurrentDirectory();
            int binIndex = Directory.GetCurrentDirectory().IndexOf("bin");
            return dir.Remove(binIndex - 1);
        }

        public static void FileExists(string directory, string fileName)
        {
            foreach (var i in Directory.EnumerateFiles(directory, fileName))
            {
                Console.WriteLine(i);
            }
        }

        public static void CheckSubDirectories(string dir, string fileName)
        {
            foreach (var i in Directory.EnumerateDirectories(dir))
            {
                FileExists(i, fileName);

                CheckSubDirectories(i, fileName);

            }
        }

        static void Main()
        {
            string startingPoint = GetProjectRoot();

            string fileName;
            fileName = Console.ReadLine();
            fileName = "*" + fileName + "*";

            CheckSubDirectories(startingPoint, fileName);

        }
    }
}
