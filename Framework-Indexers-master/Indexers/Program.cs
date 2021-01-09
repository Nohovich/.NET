using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexers
{
    class Program
    {
        static void Main(string[] args)
        {
            Company company = new Company();
            Console.WriteLine("Before changing the Gender of all the male employees to Female");
            Console.WriteLine();
            // Get accessor of string indexer is invoked to return the total count of male employees
            Console.WriteLine("Total Number Employees with Gender = Male:" + company["Male"]);
            Console.WriteLine();
            Console.WriteLine("Total Number Employees with Gender = Female:" + company["Female"]);
            Console.WriteLine();

            // Set accessor of string indexer is invoked to change the gender all "Male" employees to "Female"
            company["Male"] = "Female";
            Console.WriteLine("After changing the Gender of all male employees to Female");
            Console.WriteLine();
            Console.WriteLine("Total Employees with Gender = Male:" + company["Male"]);
            Console.WriteLine();
            Console.WriteLine("Total Employees with Gender = Female:" + company["Female"]);

            Console.ReadLine();
        }
    }
}
