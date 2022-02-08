using System;
using System.Collections.Generic;
using System.Text;

namespace WorldOfTanks.WorldOfTanks
{
    class T34 : Tank
    {
        public string Title { get; }

        public T34()
        {
            Title = "T-34";
        }

        public override string ToString()
        {
            return $"Title: {Title}, {base.ToString()}";
        }

        public static string operator *(T34 tank, Panther enemy)
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
                return tank.Title + " Won " + t34Points + ":" + pantherPoints;
            }
            else if (pantherPoints >=2)
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
