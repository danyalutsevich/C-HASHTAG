using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.Implementations
{
    internal class OldRefrigerator:Product,Interfaces.IDiscontable
    {
        public float Discont { get; set; }

        public void Print()
        {
            Console.WriteLine($"DISCOUNTABLE Name: {Name}, Price: {Price}, Discount: {Discont * 100}%");
        }

    }
}
