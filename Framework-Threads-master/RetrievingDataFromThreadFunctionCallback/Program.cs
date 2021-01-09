using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RetrievingDataFromThreadFunctionCallback
{
    class Program
    {
        // Step 3: This class consumes the Number class created in Step 2
        // Callback method that will receive the sum of numbers
        public static void PrintSumOfNumbers(int sum)
        {
            Console.WriteLine("Sum of numbers is " + sum);
        }
        static void Main(string[] args)
        {
            // Prompt the user for the target number
            Console.WriteLine("Please enter the target number");
            // Read from the console and store it in target variable
            int target = Convert.ToInt32(Console.ReadLine());

            // Create an instance of callback delegate and to it's constructor
            // pass the name of the callback function (PrintSumOfNumbers)
            SumOfNumbersCallback callbackMethod = new SumOfNumbersCallback(PrintSumOfNumbers);

            // Create an instance of Number class and to it's constrcutor pass the target
            // number and the instance of callback delegate
            Number number = new Number(target, callbackMethod);

            // Create an instance of Thread class and specify the Thread function to invoke
            Thread T1 = new Thread(new ThreadStart(number.ComputeSumOfNumbers));
            T1.Start();
        }
    }
}
