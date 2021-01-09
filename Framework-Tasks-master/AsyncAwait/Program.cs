using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        public const string FILE_PATH = @"C:\Projects\C#\framework\Tasks\AsyncAwait\Async.txt";
        public const int RANGE_WRITE = 1000;
        public const int DELAY_MS = 100;
        private async static Task WriteToFileAsync()
        {
            StreamWriter sw = new StreamWriter(FILE_PATH);
            for (int i = 1; i <= RANGE_WRITE; i++)
            {
                await sw.WriteAsync(i.ToString() + " ");
                Thread.Sleep(10);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Ready. Wait 5 seconds ... very busy now");
            Task t = WriteToFileAsync();
            while (!t.Wait(10))
            {
                Console.Write(".");
            }

            Console.WriteLine("Done!!!");
            Console.ReadLine();
        }
    }
}
