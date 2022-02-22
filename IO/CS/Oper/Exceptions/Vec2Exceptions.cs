using System;
using System.Collections.Generic;
using System.Text;

namespace Oper.Exceptions
{
    internal class Vec2Exceptions : Exception
    {
        public Vec2Exceptions() : base("Invalid operation with complex number(s)")
        {

        }
        public Vec2Exceptions(string message) : base(message)
        {

        }



    }
}
