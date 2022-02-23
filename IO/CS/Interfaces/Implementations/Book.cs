using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.Implementations
{
    internal class Book : Product, Interfaces.IPrintable
    {
        public void Print()
        {
            Console.WriteLine($"Name: {Name}, Price: {Price} ");

        }
    }
}
