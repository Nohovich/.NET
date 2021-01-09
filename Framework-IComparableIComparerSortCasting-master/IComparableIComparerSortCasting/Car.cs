using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComparableIComparerSortCasting
{
    /// <summary>
    ///  the IComparable interface lets us how we want to compare objects,
    ///  for example: by ID
    /// </summary>
    class Car : IComparable<Car>
    {

        public string Model { get; private set; }
        public int Year { get; private set; }
        public int HorsePower { get; private set; }

        public Car(string model, int year, int horsePower)
        {
            Model = model;
            Year = year;
            HorsePower = horsePower;
        }

        public override string ToString()
        {
            return $"Car Model : {Model,15}    Year : {Year,5}    Horse Power : {HorsePower,7}";
        }

        /// <summary>
        /// this method is implementing the IComparable interface.
        /// we have made that the car year is the default way we comparing
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        public int CompareTo(Car car)
        {
            // long way
            // who is first ? this or obj?
            // if i come first then return 1+
            // if we are equal return 0
            // if obj comes first return 1-

            //Car car = obj as Car;
            /*
            if (this.Year > car.Year)
            {
                return 1;
            }
            if (this.Year == car.Year)
            {
                return 0;
            }
            return -1;
            */

            return this.Year - car.Year;
        }
    }
    /// <summary>
    /// Here we store another comparison logic
    /// </summary>
    class CarHPComparer : IComparer<Car>
    {
        /// <summary>
        /// this method is implementing the IComparable interface.
        /// this time we are comparing the HorsePower of a car
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(Car x, Car y)
        {
            return x.HorsePower - y.HorsePower;
        }
    }
}
