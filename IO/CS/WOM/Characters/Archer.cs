using System;
using System.Collections.Generic;
using System.Text;

namespace WOM.Characters
{
    internal class Archer : Character
    {
        public Archer()
        {

            base.HP = 100;
            base.Atack = 10;
            base.Defence = 5;


        }
        public override string ToString()
        {

            return $"Archer: {base.ToString()}";

        }


    }
}
