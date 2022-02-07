using System;
using System.Collections.Generic;
using System.Text;

namespace WOM
{
    internal class World
    {
        List<Characters.Character> Characters;
        //Random random; // now in Services 


        public World()
        {
            Characters = new List<Characters.Character>();
           
                    
            for (int i = 0; i < 5; i++)
            {
                switch (Services.random.Next(3))
                {

                    case 0:
                        Characters.Add(new Characters.Archer());
                        break;
                    case 1:
                        Characters.Add(new Characters.Rider());
                        break;
                    case 2:
                        Characters.Add(new Characters.Wizard());
                        break;

                }


            }


        }

        public override string ToString()
        {
            var sb = new StringBuilder();
           

            foreach (var i in Characters)
            {

                sb.Append(i.ToString());
                sb.Append("\n");

            }

            return sb.ToString();
        
        }

        public void Go()
        {

            Console.WriteLine(this);

            int res = Characters[0] * Characters[1];
            Console.WriteLine(this);

        }

        public Characters.Character this[int i]
        {
            get
            {

                return Characters[i];
            }

        }


    }
}
