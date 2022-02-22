using System;

namespace TextStatistc
{
    delegate void Text(string str); 
    
    internal class Program
    {
        public static TextStatistic textStatistic;

        static void Main(string[] args)
        {
            textStatistic = new TextStatistic();
            textStatistic.text += textStatistic.Processing;

            textStatistic.Start();



        }

       

    }
}
