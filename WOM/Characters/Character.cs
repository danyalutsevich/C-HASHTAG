using System;
using System.Collections.Generic;
using System.Text;

namespace WOM.Characters
{
    internal class Character
    {

        public int HP { get; set; }
        public int Atack { get; set; }
        public int Defence { get; set; }

        public override string ToString()
        {
            return String.Format("HP: {0}, A: {1}, D: {2}",HP,Atack,Defence);
        }

        public static int operator *(Character c1,Character c2)
        {

            int damage1 = c1.Atack - c2.Defence;
            if (damage1>0)
            {
                c1.HP -=damage1;

            }
            else
            {
                c1.HP--;
            }

            int damage2 = c2.Atack - c1.Defence;
            if (damage2 > 0)
            {

                c2.HP-=damage2;

            }
            else
            {
                c2.HP--;
            }


            return damage1+damage2; 
        } 

       

    }
}
