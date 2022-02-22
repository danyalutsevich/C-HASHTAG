using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.Implementations
{
    internal class Product
    {
        public float Price { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Price: {Price}";

        }

    }
}
