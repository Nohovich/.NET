using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer()
            {
                ID = 101,
                Name = "Mark",
                Gender = "Male"
            };

            Customer customer2 = new Customer()
            {
                ID = 102,
                Name = "Pam",
                Gender = "Female"
            };

            // Create a Queue
            Queue<Customer> queueCustomers = new Queue<Customer>();
            // To add an item to the queue, use Enqueue() method.
            // customer1 is added first, so this customer, will be the first to get out of the queue
            queueCustomers.Enqueue(customer1);
            // customer2 will be queued up next, so customer2 will be second to get out of the queue
            queueCustomers.Enqueue(customer2);

            // To retrieve an item from the queue, use Dequeue() method. Notice that the 
            // items are dequeued in the same order in which they were enqueued.
            // Dequeue() method removes and returns the item at the beginning of the Queue.
            Customer c1 = queueCustomers.Dequeue();
            Console.WriteLine(c1.ID + " -  " + c1.Name);
            Console.WriteLine("Items left in the Queue = " + queueCustomers.Count);

            Customer c2 = queueCustomers.Dequeue();
            Console.WriteLine(c2.ID + " -  " + c2.Name);
            Console.WriteLine("Items left in the Queue = " + queueCustomers.Count);
            Console.WriteLine("-----------------------------------------------------------");

            // After customer5 is dequeued, there will be no items left in the 
            // queue. So, let's enqueue the five objects once again
            queueCustomers.Enqueue(customer1);
            queueCustomers.Enqueue(customer2);

            // If you need to loop thru items in the queue, foreach loop can be used in the 
            // same way as we use it with other collection classes. The foreach loop will
            // only iterate thru items in the queue, but will not dequeue them.
            foreach (Customer customer in queueCustomers)
            {
                Console.WriteLine(customer.ID + " -  " + customer.Name);
                Console.WriteLine("Items left in the Queue = " + queueCustomers.Count);
            }
            Console.WriteLine("-----------------------------------------------------------");

            // To retrieve an item that is present at the beginning of the 
            // queue, without removing it use Peek() method.
            Customer c = queueCustomers.Peek();
            Console.WriteLine(c.ID + " -  " + c.Name);
            Console.WriteLine("Items left in the Queue = " + queueCustomers.Count);
            Console.WriteLine("-----------------------------------------------------------");

            // To check if an item, exists in the queue, use Contains() method.
            if (queueCustomers.Contains(customer1))
            {
                Console.WriteLine("customer1 is in Queue");
            }
            else
            {
                Console.WriteLine("customer1 is not in Queue");
            }
        }
    }
}
