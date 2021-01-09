using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelInvoke
{
    class Program
    {
        static void Main(string[] args)
        {
         Parallel.Invoke(
            NormalAction, // Invoking Normal Method
            delegate ()   // Invoking an inline delegate 
            {
             Console.WriteLine($"Method 2, Thread={Thread.CurrentThread.ManagedThreadId}");
            },

            () =>   // Invoking a lambda expression
            {
            Console.WriteLine($"Method 3, Thread={Thread.CurrentThread.ManagedThreadId}");
            }

            );
            Console.WriteLine("Press any key to exist.");
            Console.ReadKey();
        }
          static void NormalAction()
          {
             Console.WriteLine($"Method 1, Thread={Thread.CurrentThread.ManagedThreadId}");
          }
    }
}
