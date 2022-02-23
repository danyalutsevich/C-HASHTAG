using System;
using System.Collections.Generic;

namespace Interfaces
{
    using Implementations;
    using Interfaces;

    internal class Program
    {

        static void Main(string[] args)
        {

            List <Product> products = new List <Product> ();
            products.Add(new Refrigerator { Name = "Ice", Price = 3.14f });
            products.Add(new Refrigerator { Name = "Snowflake", Price = 3.14f });
            products.Add(new Book { Name = "Fractal", Price = Convert.ToSingle(Math.PI)});
            products.Add(new OldRefrigerator { Name = "Ravanson", Price = 180,Discont = 0.0f});
            products.Add(new OldBook { Name = "Richter CLR via C#",Price = Single.MaxValue, Discont=0.3f});

            Console.WriteLine("All Products");
            products.AllProducts();


            Console.WriteLine("\nPrintable products");
            products.Printable();


            Console.WriteLine("\nDiscountable products");
            products.Discontable();


        }
    }
}
