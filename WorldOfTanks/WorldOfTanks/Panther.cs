using System;
using System.Collections.Generic;
using System.Text;

namespace WorldOfTanks.WorldOfTanks
{
    class Panther : Tank
    {
        public string Title { get; }

        public Panther()
        {
            Title = "Panther";
        }

        public override string ToString()
        {
            return $"Title: {Title}, {base.ToString()}";
        }

        public static string operator *(Panther tank, T34 enemy)
        {

            int t34Points = 0;
            int pantherPoints = 0;


            if (tank.Armor > enemy.Armor)
            {
                t34Points++;
            }
            else
            {
                pantherPoints++;
            }

            if (tank.Mobility > enemy.Mobility)
            {
                t34Points++;
            }
            else
            {
                pantherPoints++;
            }

            if (tank.Ammo > enemy.Ammo)
            {
                t34Points++;
            }
            else
            {
                pantherPoints++;
            }


            if (t34Points >= 2)
            {
                return tank.Title + " Won " + t34Points+":"+pantherPoints;
            }
            else if (pantherPoints >= 2)
            {
                return enemy.Title + " Won " + t34Points + ":" + pantherPoints;
            }
            else
            {
                return "Draw";
            }
        }
    }
}
