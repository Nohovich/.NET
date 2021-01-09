using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enums
{
    class Program
    {
        static void Main(string[] args)
        {
            // This line will not compile. Cannot implicitly convert type 'Season' to 'Gender'. 
            // An explicit conversion is required.
            // Gender gender = Season.Winter;


            // This line comiples as we have an explicit cast
            Gender gender = (Gender)Season.Winter;

            // Sample Program listing all enum member values and Names
            int[] Values = (int[])Enum.GetValues(typeof(Gender));
            Console.WriteLine("Gender Enum Values");
            foreach (int value in Values)
            {
                Console.WriteLine(value);
            }

            Console.WriteLine();
            string[] Names = Enum.GetNames(typeof(Gender));
            Console.WriteLine("Gender Enum Names");
            foreach (string Name in Names)
            {
                Console.WriteLine(Name);
            }
        }
        public enum Gender : int
        {
            Unknown = 1,
            Male = 2,
            Female = 3
        }
        public enum Season : int
        {
            Winter = 1,
            Spring = 2,
            Summer = 3
        }
    }
}
