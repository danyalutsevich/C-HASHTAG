using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextStatistc
{
    internal class TextStatistic
    {
        public event Text text;
        public static StringBuilder sb;

        static TextStatistic()
        {

            sb = new StringBuilder();

        }

        public void Start()
        {

            ConsoleKeyInfo key;

            do
            {

                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    text?.Invoke("\n");
                }
                else
                {
                    text?.Invoke(key.KeyChar.ToString());
                }

            } while (key.Key != ConsoleKey.Escape);

        }

        public void Processing(string str)
        {


            sb.Append(str);
            Console.Write(str);
            str = sb.ToString();
            if (sb.Length % 40 == 0)
            {
                sb.Append("\n");
                Console.Clear();
                Console.Write(sb.ToString());
            }
            int strings = 1;

            for (int i = 0; i < str.Length; i++)
            {

                if (str[i] == '\n')
                {
                    strings++;
                }

            }
            Console.Title = $"strings: {strings}, characters: {sb.Length}";


        }


    }




}
