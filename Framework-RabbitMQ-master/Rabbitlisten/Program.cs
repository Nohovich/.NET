using EasyNetQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbitlisten
{
    class Program
    {
        static void Main(string[] args)
        {
            Listen();
        }
        static void Listen()
        {
            // create the connections we want to listen to
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                //Console.WriteLine("press key to start listening");
                //Console.ReadKey();
                // subscribe to the line we call My_Game
                bus.Subscribe<string>("My_Game", HandleClusterNodes);
                Console.WriteLine("Listening ...Press any key to quit");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// this method pulls the message from the line we listening.
        /// after the message is getting pulled it deleted from the line
        /// </summary>
        /// <param name="obj"></param>
        private static void HandleClusterNodes(string obj)
        {
            Console.WriteLine(obj); // the string will be json which describe work, i.e. write to database
        }
    }
}
