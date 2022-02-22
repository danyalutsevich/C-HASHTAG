using System;
using System.Collections.Generic;
using System.Text;

namespace WorldOfTanks
{
    internal class World
    {

        List<WorldOfTanks.T34> t34;
        List<WorldOfTanks.Panther> panther;
        int tankAmount;


        public World(int tankAmount)
        {
            if (tankAmount > 1000)
            {
                throw new Exception("That's a lot of tanks");
            }

            t34 = new List<WorldOfTanks.T34>();
            panther = new List<WorldOfTanks.Panther>();
            this.tankAmount = tankAmount;

            for (int i = 0; i < tankAmount; i++)
            {
                t34.Add(new WorldOfTanks.T34());
                panther.Add(new WorldOfTanks.Panther());
            }



        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var i in t34)
            {
                sb.Append(i.ToString());
                sb.Append("\n");
            }
            sb.Append("\n");
            foreach (var i in panther)
            {
                sb.Append(i.ToString());
                sb = sb.Append("\n");
            }
            return sb.ToString();
        }

        public string Fire()
        {

            var sb = new StringBuilder();

            for (int i = 0; i < tankAmount; i++)
            {
                sb.Append((i + 1) + ". ");
                sb.Append(t34[i] * panther[i] + "\n");


            }


            return sb.ToString();
        }

    }
}
