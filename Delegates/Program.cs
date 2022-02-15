using System;

namespace Delegates
{
    internal class Program
    {

        delegate void PrintMethod(int x);
        delegate int MathFunction(int x, PrintMethod print);

        static int Abs(int x)
        {
            Console.WriteLine($"Abs {x}: ");
            return Math.Abs(x);
        } 
        static int Pow(int x)
        {
            Console.WriteLine($"Pow {x}: ");
            return x * x;
        }
        static int Cube(int x)
        {
            Console.WriteLine($"Cube {x} = ");
            return x * x * x;
        }

        static int AbsBack(int x, PrintMethod callback)
        {
            x=Abs(x);
            callback(x);
            return x;
        }
        static int PowBack(int x, PrintMethod callback)
        {
            x = Pow(x);
            callback(x);
            return x;
        }
        static int CubeBack(int x, PrintMethod callback)
        {
            x = Cube(x);
            callback(x);
            return x;
        }
     

        static void Print(int x)
        {
            Console.Write(x);
        }
        static void PrintLine(int x)
        {
            Console.WriteLine(x);
        }
        static void SuperPrint(int x)
        {
            Console.WriteLine($"-= {x} =-");
        }

        static void Main(string[] args)
        {

            ConsoleKey key;
            ConsoleKey func;

            MathFunction mainFunc=AbsBack;
            PrintMethod print=Print;

            do
            {
                Console.Clear();
                Console.WriteLine("Choose function: ");
                Console.WriteLine("1.Abs");
                Console.WriteLine("2.Pow");
                Console.WriteLine("3.Cube");
                key = Console.ReadKey(true).Key;

                switch (key)
                {

                    case ConsoleKey.D1:
                        mainFunc = new(AbsBack);
                        break;
                    case ConsoleKey.D2:
                        mainFunc = new(PowBack);

                        break;
                    case ConsoleKey.D3:

                        mainFunc = CubeBack;
                        break;
                    default: break;
                }


                Console.WriteLine("Choose print method: ");
                Console.WriteLine("1.Print");
                Console.WriteLine("2.PrintLine");
                Console.WriteLine("3.SuperPrint");
                func = Console.ReadKey(true).Key;

                switch (func)
                {

                    case ConsoleKey.D1:
                        print = Print;
                        break;
                    case ConsoleKey.D2:
                        print = PrintLine;

                        break;
                    case ConsoleKey.D3:

                        print = SuperPrint;
                        break;
                        default : break;
                }

                Console.WriteLine("Enter number (parameter)");
                int num = Convert.ToInt32(Console.ReadLine());
                mainFunc(num, print);


                Console.ReadKey(true);

            } while (key != ConsoleKey.Escape);




        }
    }
}
