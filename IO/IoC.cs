using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace IO
{

    class Greeter
    {
        public string Hello { get => "hello"; }
    }

    internal class IoC
    {
        public static UnityContainer container;

        public static void Main()
        {
            container = new UnityContainer();
            container.RegisterInstance<Random>(new Random());
            container.RegisterType<Greeter>();

            var rndInt = container.Resolve<RandomInt>();
            rndInt.Print();

            var rndDouble = container.Resolve<RandomDouble>();
            rndDouble.Print();

            var rndChar = container.Resolve<RandomChar>();
            rndChar.Print();

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
        [Dependency]
        public Greeter greeter { get; set; }

        public void Print()
        {
            Console.WriteLine($"{greeter.Hello} {rnd.NextDouble()}");
        }
    }

    class RandomChar
    {
        private  readonly Greeter _greeter;

        private readonly Random _random;

        public RandomChar(Greeter greeter,Random random)
        {
            _greeter = greeter;
            _random = random;
        }
        public void Print()
        {
            Console.WriteLine($"{_greeter.Hello} {(char)_random.Next(32,128)}");
        }

    }



}
