using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComparableIComparerSortCasting
{
    class Program
    {
        static void Main(string[] args)
        {
            // create cars
            Car honda = new Car("Honda", 2036, 110);
            Car suzuki = new Car("Suzuki", 2016, 90);
            Car mitsubishi = new Car("Mitsubishi", 2030, 150);
            // list of cars
            Car[] cars = { honda, suzuki, mitsubishi };
            // print unsorted
            PrintCars(cars);

            Console.WriteLine("Compare by year:");
            // sort by default
            Array.Sort(cars);
            //printing the car list after storing
            PrintCars(cars);

            Console.WriteLine("Compare by Horse power:");
            // sort by Horsepower
            Array.Sort(cars, new CarHPComparer());
            //printing the car list after storing
            PrintCars(cars);

            Console.ReadKey();
        }
        static void PrintCars(Car[] cars)
        {
            foreach (Car c in cars)
            {
                Console.WriteLine(c);
            }
        }
    }
}

