using System;
using System.Collections.Generic;
using System.Text;

namespace WorldOfTanks
{
    internal class World
    {

        List<WorldOfTanks.Tank> t34;
        List<WorldOfTanks.Tank> panther;

        public World()
        {
            t34 = new List<WorldOfTanks.Tank>();
            panther = new List<WorldOfTanks.Tank>();

            for(int i = 0; i < 5; i++)
            {
                    t34.Add(new WorldOfTanks.Tank("T-34"));
                    panther.Add(new WorldOfTanks.Tank("Pantera"));

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
            int t34Points = 0;
            int pantherPoints = 0;
            var sb = new StringBuilder();

            for(int i = 0;i < 5; i++)
            {
                sb.Append((i+1) + ". ");
                sb.Append(t34[i]*panther[i]+"\n");


            }


                return sb.ToString();
        }

    }
}
