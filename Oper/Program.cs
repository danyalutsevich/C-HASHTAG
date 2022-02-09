using System;

namespace Oper
{
    class Program
    {
        static void Main(string[] args)
        {

            //var complex = new DataTypes.Complex();
            //complex.Re = 1;
            //complex.Im = -2;

            var c1 = new DataTypes.Complex
            {
                Im = -2,
                Re = 1
            };
            var c2 = new DataTypes.Complex
            {
                Im = -2,
                Re = 1
            };
            var c3 = new DataTypes.Complex
            {
                Im = 1,
                Re = 0
            };
            var c0 = new DataTypes.Complex
            {
                Im = 0,
                Re = 0
            };

            Console.WriteLine(c1.ToString());
            Console.WriteLine($"{c1} + {c2} = {c1 + c2}");
            Console.WriteLine($"{c1} - {c2} = {c1 - c2}");

            try
            {

                Console.WriteLine($"{c3} * {c3} = {c3 * c3}");
                Console.WriteLine($"{c3} / {c3} = {c3 / c3}");
                Console.WriteLine($"{c3} / {c0} = {c3 / c0}");
            }
            catch (Exceptions.ComplexExceptions ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
