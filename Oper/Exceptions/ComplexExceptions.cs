using System;
using System.Collections.Generic;
using System.Text;

namespace Oper.Exceptions
{
    internal class ComplexExceptions : Exception
    {
        public ComplexExceptions() : base("Invalid operation with complex number(s)")
        {

        }
        public ComplexExceptions(string message):base(message)
        {

        }
        



    }
}
