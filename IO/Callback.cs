using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IO
{
    internal class Callback
    {


        public static async Task<string> ReadFile()
        {
            return await Task.Run(() =>
            {
                string res;

                using (var sr = new StreamReader("ini.ini"))
                {
                    res = sr.ReadToEnd();
                }

                return res;
            });
        }

        public static async Task<string> ReadFileAnotherWay()
        {

            return await Task.Run(() =>
            {
                var sb = new StringBuilder();
                using (var sr = new StreamReader("ini.ini"))
                {
                    while (!sr.EndOfStream)
                    {
                        sb.AppendLine(sr.ReadLine());
                    }

                }
                return sb.ToString();
            });

        }

        public static async Task<dynamic> ParseDictAsync(string data)
        {
            return await Task.Run(() =>
            {

                if (data == null)
                {
                    return null;
                }

                var dict = new Dictionary<string, int>();

                foreach (var s in data.Split('\n', StringSplitOptions.RemoveEmptyEntries))
                {
                    string[] value = s.Split('=');

                    if (value.Length != 2)
                    {
                        throw new Exception("Inavlid ini file");
                    }

                    dict.Add(value[0].Trim(), Convert.ToInt32(value[1]));
                }

                return dict;
            });
        }

        public static async Task<bool> DisplayDictAsync(dynamic dict)
        {
            return await Task.Run(() =>
            {
                if (dict == null)
                {
                    return false;
                }

                foreach (var d in dict)
                {
                    Console.WriteLine(d);
                }

                return true;
            });


        }
    }
}
