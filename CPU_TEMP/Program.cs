using System;


namespace CPU_TEMP
{
    using Temp;
    internal class Program
    {
        public static Random random = new();
        static void Main(string[] args)
        {

            Console.WriteLine(RandomTemp());

        }

        public static Temp RandomTemp()
        {

            Temp[] t =(Temp[])Enum.GetValues(typeof(Temp));

            int temperature = random.Next((int)Temp.Cold,(int)Temp.Hot);
            Console.WriteLine(temperature);

            if (temperature < (int)Temp.Warm)
            {
                return Temp.Cold;
            }
            else if(temperature < (int)Temp.Hot)
            {
                return Temp.Warm;
            }
            else
            {
                return Temp.Hot;
            }

        }

    }
}
