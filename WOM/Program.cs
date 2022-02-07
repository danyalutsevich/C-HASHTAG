using System;

namespace WOM
{   
    // resources for all project
    class Services
    {

        public static Random random = new Random();

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var world = new World();
            //world.Go();
            
            int i1 = Services.random.Next(5);
            int i2;
            do
            {
                i2 = Services.random.Next(5);

            } while (i1 == i2);

            int res=world[i1] * world[i2];

            Console.WriteLine(i1.ToString()+world[i1]);
            Console.WriteLine(i2.ToString()+world[i2]);


        }
    }
}
