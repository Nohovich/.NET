using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            // Assigning the values of the jagged array
            // at the time of its declaration
            //int[][] arr = {
            //                new int[4]{11,12,13,14},
            //                new int[5]{21,22,23,24,25},
            //                new int[3]{31,32,33}
            //               };

            //Creating an jagged array with four rows
            int[][] arr = new int[4][];
            //Initializing each row with different column size
            // Uisng one dimensional array
            arr[0] = new int[5];
            arr[1] = new int[6];
            arr[2] = new int[4];
            arr[3] = new int[5];
            //printing the values of jagged array using nested for loop
            //It will print the default values as we are assigning any
            //values to the array
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write(arr[i][j] + " ");
                }
            }
            Console.WriteLine();
            //assigning values to the jagged array by using nested for loop
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    arr[i][j] = j++;
                }
            }
            //print values the values of jagged array by using foreach loop within for loop
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                foreach (int x in arr[i])
                {
                    Console.Write(x + " ");
                }
            }
            Console.ReadKey();
        }
    }
}
