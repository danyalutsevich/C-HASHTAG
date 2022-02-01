using System;

namespace Intro
{

    class Tasks
    {
        public void task1()
        {

            char sym;
            int count = 0;

            do
            {

                sym = Console.ReadKey().KeyChar;
                if (sym == ' ')
                {
                    count++;
                }

            } while (sym != '.');
            Console.WriteLine("\nYou've entered " + count + " spaces");
        }

        public void task2()
        {
            char[] ticket;

            ticket = Console.ReadLine().ToCharArray();

            int[] num = new int[6];

            try
            {

                num[0] = Int32.Parse(ticket[0].ToString());
                num[1] = Int32.Parse(ticket[1].ToString());
                num[2] = Int32.Parse(ticket[2].ToString());
                num[3] = Int32.Parse(ticket[3].ToString());
                num[4] = Int32.Parse(ticket[4].ToString());
                num[5] = Int32.Parse(ticket[5].ToString());

                if (num[0] + num[1] + num[2] == num[3] + num[4] + num[5])
                {
                    Console.WriteLine("That ticket is lucky");
                }
                else
                {
                    Console.WriteLine("That ticket is not lucky");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("You've entered incorrect ticket number");
            }




        }

        public void task3()
        {
            string line;

            line = Console.ReadLine();

            char[] letters = line.ToCharArray();

            for (int i = 0; i < letters.Length; i++)
            {
                if (Char.IsUpper(letters[i]))
                {
                    letters[i] = Char.ToLower(letters[i]);
                }
                else
                {
                    letters[i] = Char.ToUpper(letters[i]);
                }
            }

            Console.WriteLine(letters);

        }

        public void task4()
        {

            uint A = 0;
            uint B = 0;
            Console.WriteLine("Enter first number: ");
            A = UInt32.Parse(Console.ReadLine());

            Console.WriteLine("Enter second number: ");
            B = UInt32.Parse(Console.ReadLine());


            for (; A <= B; A++)
            {

                for (uint i = 0; i < A; i++)
                {

                    Console.Write(A.ToString() + " ");
                }

                Console.WriteLine();

            }
        }

        public void task5()
        {

            char[] num = Console.ReadLine().ToCharArray();
            Array.Reverse(num);
            Console.WriteLine(num);

        }
    }




    internal class Program
    {
        static void Main(string[] args)
        {

            Tasks tasks = new Tasks();
            tasks.task5();

        }
    }
}
