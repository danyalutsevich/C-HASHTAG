using System;
using System.Collections.Generic;
using System.Text;

namespace WorldOfTanks.WorldOfTanks
{
    class Tank
    {
        public int Ammo { get; }
        public int Armor { get; }
        public int Mobility { get; }

        public Tank()
        {
            this.Ammo = Services.random.Next(100); 
            this.Armor = Services.random.Next(100); 
            this.Mobility = Services.random.Next(100); 

        }

        public override string ToString()
        {

            return $"Ammo:{Ammo}, Armor: {Armor}, Mobility: {Mobility}";

        }

        

    }
}
