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

            World world = new World();
            Console.WriteLine(world.ToString());
            Console.WriteLine(world.Fire());


        }
    }
}
