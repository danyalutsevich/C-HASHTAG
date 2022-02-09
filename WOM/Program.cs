using System;

namespace WOM
{   
    // resources for all project
    class Services
    {

        public static Random random = new Random();

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ExDemo();
            }
            catch
            {
                Console.WriteLine("Exception thrown");
            }
            return;

            var world = new World();
            //world.Go();
            
            int i1 = Services.random.Next(5);
            int i2;
            do
            {
                i2 = Services.random.Next(5);

            } while (i1 == i2);

            int res=world[i1] * world[i2];

            Console.WriteLine(i1.ToString()+world[i1]);
            Console.WriteLine(i2.ToString()+world[i2]);


        }

        static void ExDemo()
        {
            Console.Write("Enter name: ");
            string name;
            name = Console.ReadLine();

            try
            {

                if (String.IsNullOrEmpty(name))
                {
                    throw new ArgumentException("name is empty");
                }
                if(name.Contains(" "))
                {
                    throw new InvalidOperationException("prohibited symbol (space)");   
                }
                Console.WriteLine($"Hello {name}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                System.GC.Collect();
            }

        }

    }
}
