using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComparableAndIComparer
{
    class Program
    {
        static void Main(string[] args)
        {
            Person[] people = new Person[5];
            Person a = new Person(5, 22, 190f, "a");
            Person b = new Person(1, 10, 130f, "b");
            Person c = new Person(3, 23, 150f, "c");
            Person d = new Person(2, 19, 160f, "d");
            Person e = new Person(4, 25, 195f, "e");
            people[0] = a;
            people[1] = b;
            people[2] = c;
            people[3] = d;
            people[4] = e;
            Array.Sort(people);
            Console.WriteLine("Person sort by ID");
            foreach (Person person in people)
            {
                Console.WriteLine(person.ToString());
            }
            PersonCompareByAge personCompareByAge = new PersonCompareByAge();
            Array.Sort(people, personCompareByAge);
            Console.WriteLine("Person sort by age");
            foreach (Person person in people)
            {
                Console.WriteLine(person.ToString());
            }
            PersonCompareByName personCompareByName = new PersonCompareByName();
            Array.Sort(people, personCompareByName);
            Console.WriteLine("Person sort by name");
            foreach (Person person in people)
            {
                Console.WriteLine(person.ToString());
            }
            PersonCompareByHeight personCompareByHeight = new PersonCompareByHeight();
            Array.Sort(people, personCompareByHeight);
            Console.WriteLine("Person sort by height");
            foreach (Person person in people)
            {
                Console.WriteLine(person.ToString());
            }

            Console.ReadKey();
        }
    }
}
