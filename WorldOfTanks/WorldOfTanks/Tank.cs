using System;
using System.Collections.Generic;
using System.Text;

namespace WorldOfTanks.WorldOfTanks
{
    internal class Tank
    {
        public string Title { get; set; }
        public int Ammo { get; }
        public int Armor { get; }
        public int Mobility { get; }

        public Tank(string Title)
        {
            this.Title = Title;
            this.Ammo = Services.random.Next(100); 
            this.Armor = Services.random.Next(100); 
            this.Mobility = Services.random.Next(100); 

        }

        public override string ToString()
        {

            return $"Title: {Title}, Ammo:{Ammo}, Armor: {Armor}, Mobility: {Mobility}";

        }

        public static string operator *(Tank tank,Tank enemy)
        {

            int t34Points = 0;
            int pantherPoints = 0;
            var sb = new StringBuilder();


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


            if (t34Points == 3)
            {
                sb.Append(tank.Title + " Won");
            }
            else if (pantherPoints == 3)
            {
                sb.Append(enemy.Title + " Won");
            }
            else
            {
                sb.Append("Draw");
            }


            return sb.ToString();

        }

    }
}
