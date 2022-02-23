using System;


namespace CPU_TEMP
{
    using Temp;
    internal class Program
    {
        public static Random random = new();
        static void Main(string[] args)
        {
            var temperature = RandomTemp();
            PrintTemp(temperature);

        }

        public static void PrintTemp(int temperature)
        {
            if (temperature < -1000 || temperature>10000)
            {
                throw new Exception("Looks like you are Martian");
            }

            Console.WriteLine(temperature);
            if (temperature == (int)Temp.Neutral)
            {
                Console.WriteLine("The temperature is normal");
            }
            else if (temperature < (int)Temp.Warm)
            {
                Console.WriteLine(Temp.Cold);
            }
            else if (temperature < (int)Temp.Hot)
            {
                Console.WriteLine(Temp.Warm);
            }
            else
            {
                Console.WriteLine(Temp.Hot);
            }
        }

        public static int RandomTemp()
        {

            Temp[] t =(Temp[])Enum.GetValues(typeof(Temp));

            int temperature = random.Next((int)Temp.Cold,(int)Temp.Hot);

            return temperature;

        }

    }
}
