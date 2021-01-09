using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WaitHandle
{
    class Program
    {
        // the gate start close(false)

        // need to close the gate Manually
        // static ManualResetEvent gate = new ManualResetEvent(false);

        // after the gate is open and a thread got inside the gate will be Auto close
        static AutoResetEvent gate = new AutoResetEvent(false);

        private static void DrawAdv()
        {
            Thread.Sleep(new Random().Next(1000));
            gate.WaitOne(); // wait for the gate to be open then start the work
            Console.WriteLine("Drawing ad.......");
        }

        private static void ShowAllFlights()
        {
            Thread.Sleep(new Random().Next(1000));
            gate.WaitOne();
            Console.WriteLine("Showing all flights.......");
        }

        private static void DrawClocks()
        {
            Thread.Sleep(new Random().Next(1000));
            gate.WaitOne();
            Console.WriteLine("Drawing clock.......");
        }

        private static void ShowCredentials()
        {
            Thread.Sleep(new Random().Next(1000));
            gate.WaitOne();
            Console.WriteLine("Please enter user-name password:");
        }

        /// <summary>
        /// This must occur before all other methods
        /// </summary>
        private static void LoadPage()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Page finished loading............");

            gate.Set(); // make the gate go up(open) -- allow entrance
            // gate.Reset in Manual state if we want to close the gate

        }

        static void Main(string[] args)
        {
            new Thread(ShowAllFlights).Start();
            //Thread.Sleep(new Random().Next(10));
            new Thread(ShowCredentials).Start();
            //Thread.Sleep(new Random().Next(30));
            new Thread(LoadPage).Start();
            //Thread.Sleep(new Random().Next(20));
            new Thread(DrawClocks).Start();
            //Thread.Sleep(new Random().Next(10));
            new Thread(DrawAdv).Start();
            Console.ReadKey();
        }
    }
}
