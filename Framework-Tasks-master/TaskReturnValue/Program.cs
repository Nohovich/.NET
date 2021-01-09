using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskReturnValue
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Main Thread Started");
            // this task returns the data of type double
            Task<double> task1 = Task.Run(() =>
            {
                // the method returns data of type double as well
                return CalculateSum(10);
            });

            // getting the data(Result) from the task
            Console.WriteLine($"Sum is: {task1.Result}");
            Console.WriteLine($"Main Thread Completed");

            // same as example 1 just with using anonymous method
            Task<double> task2 = Task.Run(() =>
            {
                double sum = 0;
                for (int count = 1; count <= 10; count++)
                {
                    sum += count;
                }
                return sum;
            });
            Console.WriteLine($"Sum is: {task2.Result}");
            Console.WriteLine($"Main Thread Completed");

            Console.ReadKey();
        }
        static double CalculateSum(int num)
        {
            double sum = 0;
            for (int count = 1; count <= num; count++)
            {
                sum += count;
            }
            return sum;
        }
    }
}
