using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace IO
{
    internal class IoC
    {
        public static UnityContainer container;

        public static void Main()
        {
            container = new UnityContainer();
            container.RegisterInstance<Random>(new Random());


            var rndInt = container.Resolve<RandomInt>();
            rndInt.Print();

            var rndDouble = container.Resolve<RandomDouble>();
            rndDouble.Print();

        }
    }

    class RandomInt
    {
        [Dependency]
        public Random rnd { get; set; }

        public void Print()
        {
            Console.WriteLine(rnd.Next());
        }


    }

    class RandomDouble
    {

        [Dependency]
        public Random rnd { get; set; }
        public void Print()
        {
            Console.WriteLine(rnd.NextDouble());
        }


    }



}
