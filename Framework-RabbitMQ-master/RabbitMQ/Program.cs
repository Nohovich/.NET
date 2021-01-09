using EasyNetQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitMQ
{
    class Program
    {
        static void Main(string[] args)
        {
            SendMessage();
            SendMessage();
        }

        static void SendMessage()
        {
            // create the connections we want to listen to
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                Console.WriteLine("Press any key to send the message");
                Thread.Sleep(1500);
                // sends a message to the line
                bus.Publish("{\"text\": \"Hello World\"}", "My_Game");
                Console.WriteLine("Message sent ... Press any key to quit");
            }
        }
    }
}
