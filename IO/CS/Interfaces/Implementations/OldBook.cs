using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.Implementations
{
    using Interfaces;

    internal class OldBook : Book, IDiscontable
    {

        public float Discont { get; set; }



    }
}
