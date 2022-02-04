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
            Console.WriteLine("List");
            #region List;

            strings = new List<string>();
            strings.Add("first");
            strings.Add("first");
            strings.Add("second");
            strings.Add("third");

            foreach (var item in strings)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(strings[1]); //if wrong index --> exception

            strings[2] += "++";
            Console.WriteLine(strings[1]);

            //wrong you cant change object in foreach
            //foreach (var item in strings)
            //{
            //    item += "+";
            //}

            Console.WriteLine();
            //strings.Remove("first");
            //strings.RemoveAt(5);  //if wrong index --> exception
            
            foreach (var item in strings)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            //find the element
            Console.WriteLine(strings.Contains("first"));//True/False
            Console.WriteLine(strings.IndexOf("first"));//Index of the first element in case of not found returns -1
            Console.WriteLine(strings.LastIndexOf("first"));//Index of the first element in case of not found returns -1

            System.Runtime.InteropServices.GCHandle gch = System.Runtime.InteropServices.GCHandle.Alloc(strings[1], System.Runtime.InteropServices.GCHandleType.Pinned);
            IntPtr pObj = gch.AddrOfPinnedObject();
            Console.WriteLine(pObj.ToString());

            Console.WriteLine(strings[1]);

            System.Runtime.InteropServices.GCHandle gch1 = System.Runtime.InteropServices.GCHandle.Alloc("first", System.Runtime.InteropServices.GCHandleType.Pinned);
            IntPtr pObj1 = gch1.AddrOfPinnedObject();
            Console.WriteLine(pObj1.ToString());

            // change collection in loop --> exception
            //foreach (var item in strings)
            //{
            //    strings.Remove(item);
            //}
            strings.Clear();//remove all elements from collection

            #endregion

            #region dictionary
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Dictionary");

            // define key type and value type
            dict = new Dictionary<string, string>();
            //dict - pair(key, value)

            dict.Add("1", "one");
            dict.Add("2", "two");
            dict.Add("3", "three");

            Console.WriteLine(dict["1"]);

            foreach (var item in dict)
            {
            //    Console.WriteLine(item.Key + " " + item.Value);
            }
            #endregion

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
