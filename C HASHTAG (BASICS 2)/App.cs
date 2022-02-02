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
}
