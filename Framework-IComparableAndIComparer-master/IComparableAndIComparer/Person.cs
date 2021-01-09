using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComparableAndIComparer
{
    class Person : IComparable<Person>
    {
        public Person(int iD, int age, float height, string name)
        {
            _ID = iD;
            _age = age;
            _height = height;
            _name = name;
        }

        public int _ID { get; private set; }
        public int _age { get; private set; }
        public float _height { get; private set; }
        public string _name { get; private set; }

        public int CompareTo(Person personComper)
        {
            return this._ID - personComper._ID;
        }

        public override string ToString()
        {
            return $"person ID: {_ID}, person name: {_name}, person age: {_age}, person height: {_height},";
        }
    }
    class PersonCompareByID : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return x._ID - y._ID;
        }
    }
    class PersonCompareByAge : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return x._age - y._age;
        }
    }
    class PersonCompareByName : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return x._name.CompareTo(y._name);
        }
    }
    class PersonCompareByHeight : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            if (x._height == y._height)
                return 0;
            if (x._height > y._height)
                return 1;
            return -1;
        }
    }
}
