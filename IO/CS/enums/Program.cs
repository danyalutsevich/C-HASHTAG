using System;


namespace enums
{
    internal class Program
    {
        public static Random random = new Random();


        static void Main(string[] args)
        {

            Directions direction;

            random = new Random();
            direction = RandomDir();

            PrintDir(direction);
            Console.WriteLine(direction);
         

            //if (!Enum.IsDefined(direction.GetType(), direction))
            //if (!Enum.IsDefined<Directions>(direction))

            if (!Enum.IsDefined(typeof(Directions), direction))
            {
                throw new Exception($"Value {direction} is out of range");
            }



        }

      

        private static Directions RandomDir()
        {
            //int[] val = {0,10,11,20,21};
            Directions[] val = (Directions[])Enum.GetValues(typeof(Directions));
            
            
            return (Directions)val[random.Next(val.Length)];
        }

        private static void PrintDir(Directions dir)
        {
            string img = String.Empty; 

            switch (dir)
            {
                case Directions.None:
                    img = " ";
                    break;
                case Directions.Left:
                    img = "<";
                    break;
                case Directions.Right:
                    img = ">";
                    break;
                case Directions.Up:
                    img = "^";
                    break;
                case Directions.Down:
                    img = "v";
                    break;
            }
            Console.WriteLine(img);

        }
    }
}
