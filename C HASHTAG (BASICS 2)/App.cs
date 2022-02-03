using System;
using System.Collections.Generic;
using System.Text;

namespace C_HASHTAG__BASICS_2_
{
   partial class App{

        int[] arr;
        int[,] arr2;
        int[][] arr3;

        public void Run()
        {

            CollectionsDemo();

        }
        public void CollectionsDemo()
        {
            List<string> strings;
            Dictionary<string, string> dict;


            strings = new List<string>();
            strings.Add("first");
            strings.Add("second");
            strings.Add("third");
            foreach (var item in strings)
            {
                Console.WriteLine(item);
            }

            dict = new Dictionary<string, string>();

            dict.Add("1", "first");
            dict.Add("2", "second");
            dict.Add("3", "third");
            dict.Add("7", "third");
            dict.Add("6", "third");
            dict.Add("5", "third");
            dict.Add("4", "third");

            foreach (var item in dict)
            {
                Console.WriteLine(item.Key+" "+item.Value);
            }


        }
        public void CtorDemo()
        {

            TheClass obj = new TheClass(20);
            Console.WriteLine(obj);


        }
        public void ArraysDemo()
        {
            Console.WriteLine("Hi universe!");
            arr = new int[10];
            for (int i = 0; i < 5; i++)
            {
                arr[i] = i*i;
            }
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
            arr2 = new int[4,4];

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    arr2[i, j] = 10 * i + j * 11;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(arr2[i,j]+" ");
                }
                Console.WriteLine();
            }

            //foreach (var item in arr2)
            //{
            //    Console.WriteLine(item);
            //}


            arr3 = new int[3][];

            for (int i = 0; i < 3; i++)
            {
                arr3[i] = new int[2 + i];
                for (int j = 0; j < 2+i; j++)
                {
                    arr3[i][j] = 10 * i + j * 11;
                }

            }

            
            foreach (var i in arr3)  
            {
                foreach (var j in i)
                {
                    Console.Write(j+" ");
                }
                Console.WriteLine();
            }


        }



   }
   
    class TheClass
    {
        private int x;
        public int Y { get; set; } //auto property
        public int W { get;private set; } //auto property
        public int X { 
            get { return this.x; } 
            set { this.x = value; } 
        }
        private TheClass()//default ctor
        {
            x = 10;
        }
        public TheClass(int x)//parametr ctor
        {
            this.x = x;
            
        }
        public override string ToString()
        {
            return $"x = {this.x}";
        }


    }

}
