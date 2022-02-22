using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    using Interfaces;
    using Implementations;

    internal static class ListExtentions
    {
        public static void AllProducts(this List<Product> list)
        {
            foreach (var i in list)
            {
                Console.WriteLine(i);
            }
        }

        public static void PrintBooks(this List<Product> list)
        {
            foreach (var i in list)
            {
                if (i is Book)
                {
                    Console.WriteLine(i);
                }
            }
        }

        public static void PrintOldBooks(this List<Product> list)
        {
            foreach (var i in list)
            {
                if (i is OldBook)
                {
                    Console.WriteLine(i);
                }
            }
        }

        public static void PrintRefrigerators(this List<Product> list)
        {
            foreach(var i in list)
            {
                if(i is Refrigerator)
                {
                    Console.WriteLine(i);
                }
            }
        }

        public static void PrintOldRefrigerators(this List<Product> list)
        {
            foreach (var i in list)
            {
                if (i is OldRefrigerator)
                {
                    Console.WriteLine(i);
                }
            }
        }

        public static void Printable(this List<Product> list)
        {
            foreach (var i in list)
            {
                if (i is IPrintable)
                {
                    (i as IPrintable).Print();
                }
            }
        }

        public static void Discontable(this List<Product> list)
        {
            foreach (var i in list)
            {
                if (i is IDiscontable)
                {
                    Console.Write(i);
                    Console.WriteLine($", Discount: {(i as IDiscontable).Discont * 100}%");
                }
            }
        }


    }
}
