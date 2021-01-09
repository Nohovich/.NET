using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProtectingSharedResourcesInMultithreading
{
    class Program
    {
        static int Total = 0;
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(Program.AddOneMillion);
            Thread thread2 = new Thread(Program.AddOneMillion);
            Thread thread3 = new Thread(Program.AddOneMillion);

            thread1.Start();
            thread2.Start();
            thread3.Start();

            thread1.Join();
            thread2.Join();
            thread3.Join();

            Console.WriteLine("Total = " + Total);
        }


        /// <summary>
        /// Using Interlocked.Increment() method:
        /// Modify AddOneMillion() method as shown below.
        /// The Interlocked.Increment() Method,
        /// increments a specified variable and stores the result, as an atomic operation
        /// </summary>
        public static void AddOneMillion()
        {
            for (int i = 1; i <= 1000000; i++)
            {
                Interlocked.Increment(ref Total);
            }
        }

        static object _lock = new object();
        /// <summary>
        /// 
        /// </summary>
        public static void AddOneMillionlock()
        {
            for (int i = 1; i <= 1000000; i++)
            {
                lock (_lock)
                {
                    Total++;
                }
            }
        }



    }
}
