using System;


namespace C_HASHTAG__BASICS_
{
    class TypeC
    {
        public int x;
        public override bool Equals(object obj)
        {

            if (obj is TypeC)
            {
                TypeC other = obj as TypeC;
                return other.x == x;

            }
            else
            {

                return false;

            }


        }
    }
    struct TypeS
    {
        public int x;
    }
    internal class Program
    {
        static double ReadDouble()
        {
            Console.Write("Enter x: ");

            ConsoleKeyInfo k;

            var sb = new System.Text.StringBuilder();
            bool dot = false;
            do
            {
                k = Console.ReadKey(true);

                if ((Char.IsDigit(k.KeyChar) || (k.KeyChar == '-' && sb.Length == 0) || ((k.KeyChar == '.' || k.KeyChar == ',') && !dot && sb.Length > 0)) && sb.Length < 9)
                {
                    Console.Write("*");
                    sb.Append(k.KeyChar);
                }
                else
                {
                    //Console.Beep();
                }

                if (k.KeyChar == '.' && sb.Length > 0)
                {
                    dot = true;
                }

            } while (k.Key != ConsoleKey.Enter);

            return Convert.ToDouble(sb.ToString().Replace('.', ','));



        }
        static int ReadInt()
        {

            Console.Write("Enter x: ");

            ConsoleKeyInfo k;

            var sb = new System.Text.StringBuilder();

            do
            {
                k = Console.ReadKey(true);

                if ((Char.IsDigit(k.KeyChar) || (k.KeyChar == '-' && sb.Length == 0)) && sb.Length < 9)
                {
                    Console.Write(k.KeyChar);
                    sb.Append(k.KeyChar);

                }
                else
                {
                    //Console.Beep();
                }

            } while (k.Key != ConsoleKey.Enter);

            return Int32.Parse(sb.ToString()); ;




        }
        static void Main()
        {
            try
            {
                double num = ReadDouble();
                Console.WriteLine("\n" + num);

            }
            catch
            {
                Console.WriteLine("\nYou've entered incorrect number");
            }



        }
        static void Main3()
        {
            TypeC c1 = new TypeC();
            c1.x = 10;
            var c2 = new TypeC
            {

                x = 11

            };

            Console.WriteLine(c1.Equals(c2));



            TypeS s1;
            TypeS s2;
            s1.x = 10;
            s2.x = 11;
            Console.WriteLine(s1.Equals(s2));

        }
        static void Main2(string[] args)
        {
            //Console.WriteLine("Hello World!");

            /*   TypeC c1;
               TypeC c2;
               TypeS s1;
               TypeS s2;

               c1 = new TypeC();
               c2 = new TypeC();
               c1.x = 10;
               c2 = c1;
               c2.x = 20;

               Console.WriteLine("c1.x = {0}, c2.x = {1}",c1.x,c2.x);
               s1 = new TypeS();

               s1.x = 10;
               s2 = s1;
               s2.x = 20;

               Console.WriteLine("s1.x = {0}, s2.x = {1}",s1.x,s2.x);
            */

            int i = default(int);
            bool b = false;
            float f = default(float);
            string s = default(string);

            double d = default(double);
            Int16 i16 = default(Int16);
            Int32 i32 = default(Int32);
            Int64 i64 = default(Int64);
            char c = default(char);
            System.String s1 = default(System.String);

            Console.WriteLine("{0} {1}", i.GetType(), i);
            Console.WriteLine("{0} {1}", b.GetType(), b);
            Console.WriteLine("{0} {1}", f.GetType(), f);
            Console.WriteLine("{0} {1}", "string ", s); // "\0"
            Console.WriteLine("{0} {1}", "string ", s1); //same as "s"
            Console.WriteLine("{0} {1}", d.GetType(), d);
            Console.WriteLine("{0} {1}", i16.GetType(), i16);
            Console.WriteLine("{0} {1}", i32.GetType(), i32);
            Console.WriteLine("{0} {1}", i64.GetType(), i64);
            Console.WriteLine("{0} {1}", c.GetType(), c);

            /*
             Любой ссылочный тип	null
             Любой встроенный целочисленный тип	Ноль (0)
             Любой встроенный тип с плавающей запятой	Ноль (0)
             bool	false
             char	'\0' (U+0000)
             enum	Значение, создаваемое выражением (E)0, где E — это идентификатор перечисления.
             struct	Значение, создаваемое путем установки значений по умолчанию для всех полей с типами значений и значений null для всех полей ссылочного типа.
             Любой тип значения, допускающий значение NULL	Экземпляр, свойство false которого имеет значение HasValue, а свойство Value не определено. Это значение по умолчанию также называется значением NULL типа значения, допускающего значение NULL.
            */

        }
    }
}
