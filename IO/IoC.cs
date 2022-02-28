﻿using System;
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
            container.RegisterType<DateService>();

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
            return DateTime.Now.ToLongTimeString();
        }
    }

    class DateService
    {
        public string GetDate()
        {
            return DateTime.Now.Date.ToString();
        }
    }
    
    class RandomInt
    {
        [Dependency]
        public Random rnd { get; set; }

        [Dependency]
        public TimeService ts { get; set; }

        [Dependency]
        public DateService ds { get; set; }

        public void Print()
        {
            Console.WriteLine($"rnd: {rnd.Next()} time: {ts.GetTime()}, date: {ds.GetDate()}");
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

        [Dependency]
        public DateService ds { get; set; }

        public void Print()
        {
            Console.WriteLine($"greater: {greeter.Hello}  time: {ts.GetTime()}, date: {ds.GetDate()}");
        }
    }


    class RandomChar
    {
        private  readonly Greeter _greeter;
        private readonly Random _random;
        private readonly TimeService _ts;
        private readonly DateService _ds;

        public RandomChar(Greeter greeter,Random random, TimeService ts, DateService ds)
        {
            _greeter = greeter;
            _random = random;
            _ts = ts;
            _ds = ds;
        }

        public void Print()
        {
            Console.WriteLine($"greater: {_greeter.Hello} rnd: {(char)_random.Next(32,128)} time: {_ts.GetTime()} date: {_ds.GetDate()}");
        }

    }



}
