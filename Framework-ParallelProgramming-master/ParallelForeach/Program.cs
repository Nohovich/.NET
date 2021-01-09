using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelForeach
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime StartDateTime = DateTime.Now;
            Console.WriteLine(@"Parallel foreach method start at : {0}", StartDateTime);
            List<int> integerList = Enumerable.Range(1, 10).ToList();
            Parallel.ForEach(integerList, i =>
            {
                long total = DoSomeIndependentTimeconsumingTask();
                Console.WriteLine("{0} - {1}", i, total);
            });

            DateTime EndDateTime = DateTime.Now;
            Console.WriteLine(@"Parallel foreach method end at : {0}", EndDateTime);
            TimeSpan span = EndDateTime - StartDateTime;
            int ms = (int)span.TotalMilliseconds;
            Console.WriteLine(@"Time Taken by Parallel foreach method in miliseconds {0}", ms);
            Console.WriteLine("Press any key to exist");
            Console.ReadLine();
        }
        static long DoSomeIndependentTimeconsumingTask()
        {
            //Do Some Time Consuming Task here
            //Most Probably some calculation or DB related activity
            long total = 0;
            for (int i = 1; i < 100000000; i++)
            {
                total += i;
            }
            return total;
        }
    }
}
