using System;
using System.Collections.Generic;
using System.Text;

namespace WOM.Characters
{
    internal class Wizard : Character
    {

        public Wizard()
        {

            base.HP = 100;
            base.Atack = 7;
            base.Defence = 10;


        }
        public override string ToString()
        {

            return $"Wizard: {base.ToString()}";

        }

    }
}
