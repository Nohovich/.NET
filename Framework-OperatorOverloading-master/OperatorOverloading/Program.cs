using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading
{
    class Program
    {
        static void Main(string[] args)
        {
            Camp camp1 = new Camp(12, 22, 10, 5, 20);
            Camp camp2 = new Camp(32, 12, 20, 10, 40);
            Camp camp3 = new Camp(12, 22, 10, 5, 20);
            Console.WriteLine("camp 1 vs camp 1");
            Console.WriteLine("Are the camps equal");
            Console.WriteLine(camp1 == camp1);
            Console.WriteLine("camp 1 vs camp 2");
            Console.WriteLine("Are the camps equal");
            Console.WriteLine(camp1 == camp2);
            Console.WriteLine("Are the camps different");
            Console.WriteLine(camp1 != camp2);
            Console.WriteLine("is the camp bigger");
            Console.WriteLine(camp1 > camp2);
            Console.WriteLine("is the camp smaller");
            Console.WriteLine(camp1 < camp2);
            Console.WriteLine("is the camp bigger or equal");
            Console.WriteLine(camp1 >= camp2);
            Console.WriteLine("is the camp smaller or equal");
            Console.WriteLine(camp1 <= camp2);
            Console.WriteLine("camp 1 vs camp 3");
            Console.WriteLine("Are the camps equal");
            Console.WriteLine(camp1 == camp3);
            Console.WriteLine("Are the camps different");
            Console.WriteLine(camp1 != camp3);
            Console.WriteLine("is the camp bigger");
            Console.WriteLine(camp1 > camp3);
            Console.WriteLine("is the camp smaller");
            Console.WriteLine(camp1 < camp3);
            Console.WriteLine("is the camp bigger or equal");
            Console.WriteLine(camp1 >= camp3);
            Console.WriteLine("is the camp smaller or equal");
            Console.WriteLine(camp1 <= camp3);
        }
    }
}
