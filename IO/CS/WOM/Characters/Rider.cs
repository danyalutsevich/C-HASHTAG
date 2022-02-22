using System;
using System.Collections.Generic;
using System.Text;

namespace WOM.Characters
{
    internal class Rider :Character
    {

        public Rider()
        {

            base.HP = 100;
            base.Atack = 3;
            base.Defence = 10;  

        }
        public override string ToString()
        {

            return $"Rider: {base.ToString()}";

        }


    }
}
