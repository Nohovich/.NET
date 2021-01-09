using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating an array with size 6
            //int[] arr = new int[6];

            //Declaring an array
            int[] arr = { 17, 23, 4, 59, 27, 36, 96, 9, 1, 3 };
            //Printing the array elements
            Console.WriteLine("The Array Contains the Below Elements:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
            //Sorting the array elements
            Array.Sort(arr);
            //Printing the array elements after sorting
            Console.WriteLine("The Array Elements After Sorting:");
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            //Reversing the array elements
            Array.Reverse(arr);
            //Printing the array elements in reverse order
            Console.WriteLine("The Array Elements in the Reverse Order :");
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            //Creating a new array
            int[] brr = new int[10];
            //Copying some of the elements from old array to new array
            Console.WriteLine("The new array elements:");
            Array.Copy(arr, brr, 5);
            //We declare the array with size 10. we copy only 5 elements. so the rest
            //5 elements will take the default value. In this array, it will take 0
            foreach (int i in brr)
            {
                Console.Write(i + " ");
            }
            Console.ReadKey();
        }
    }
}
