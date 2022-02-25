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
            container.RegisterType<TimeService>();

            var rndInt = container.Resolve<RandomInt>();
            rndInt.Print();

            var rndDouble = container.Resolve<RandomDouble>();
            rndDouble.Print();

            var rndChar = container.Resolve<RandomChar>();
            rndChar.Print();

        }
    }

    class TimeService
    {
        public string GetTime()
        {
            return DateTime.Now.ToString();
        }
    }
    
    class RandomInt
    {
        [Dependency]
        public Random rnd { get; set; }

        [Dependency]
        public TimeService ts { get; set; }

        public void Print()
        {
            Console.WriteLine($"{rnd.Next()} {ts.GetTime()}");
        }
    }

    class RandomDouble
    {
        [Dependency]
        public Random rnd { get; set; }

        [Dependency]
        public Greeter greeter { get; set; }

        [Dependency]
        public TimeService ts { get; set; }

        public void Print()
        {
            Console.WriteLine($"{greeter.Hello} {rnd.NextDouble()} {ts.GetTime()}");
        }
    }


    class RandomChar
    {
        private  readonly Greeter _greeter;
        private readonly Random _random;
        private readonly TimeService _ts;

        public RandomChar(Greeter greeter,Random random, TimeService ts)
        {
            _greeter = greeter;
            _random = random;
            _ts = ts;
        }

        public void Print()
        {
            Console.WriteLine($"{_greeter.Hello} {(char)_random.Next(32,128)} {_ts.GetTime()}");
        }

    }



}
