using System;


namespace C_HASHTAG__BASICS_
{
    class TypeC
    {
        public int x;



    }

    struct TypeS
    {
        public int x;


    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            TypeC c1;
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
            


            
        
        }
    }
}
