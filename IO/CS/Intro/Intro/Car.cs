using System;
using System.Collections.Generic;
using System.Text;

namespace Intro
{
    partial class Car
    {
        public bool canGoThisFarOnFullTank(ref double distanceInKm) 
        {
            return gasTankVolume / LitersPer100km * 100 >= distanceInKm;
        }

    }
}
