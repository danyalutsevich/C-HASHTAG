using System;
using System.Collections.Generic;

namespace WorldOfTanks
{

    class Services
    {

        public static Random random = new Random();

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                World world = new World(1000);
                Console.WriteLine(world.ToString());
                Console.WriteLine(world.Fire());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);

            }


        }
    }
}
