using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            // creating a task and passing a method
            //Task task1 = new Task(PrintCounter);
            // starting task
            //task1.Start();

            // creating task that start immediately using Task.Factory
            //Task task1 = Task.Factory.StartNew(PrintCounter);

            Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Statred");

            // creating task that start immediately using the Run method
            Task task1 = Task.Run(() =>
            {
                PrintCounter();
            });
            //  make the program execution wait until the task1 completes its execution.
            task1.Wait();
            Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Completed");
            Console.ReadKey();
        }
        static void PrintCounter()
        {
            Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Started");
            for (int count = 1; count <= 5; count++)
            {
                Console.WriteLine($"count value: {count}");
            }
            Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Completed");
        }
    }
}
