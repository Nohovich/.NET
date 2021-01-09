using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating the ThreadStart Delegate instance by passing the
            //method name as a parameter to its constructor
            ThreadStart obj = new ThreadStart(DisplayNumbers);
            //Passing the ThreadStart Delegate instance as a parameter
            //its constructor
            Thread t1 = new Thread(obj);
            t1.Start();
            Console.Read();

            int x = 5;
            int y = 3;

            // passing the thread a anonymous function
            Thread t = new Thread(() =>
            {
                for (int i = 5; i >= 0; i--)
                {
                    Console.WriteLine($"{i} seconds left....");
                    Thread.Sleep(1000);
                }
                Console.WriteLine("Time over...........");
            });
            t.Start();

            int result = Convert.ToInt32(Console.ReadLine());

            if (t.ThreadState != ThreadState.Stopped && result == 5 + 3)
            {
                Console.WriteLine("You are a hero!");
            }
            else
            {
                Console.WriteLine("Booooooooooooo");
            }
            t.Abort();
        }
        static void DisplayNumbers()
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("Method1 :" + i);
            }
        }
    }
}
