using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComparableIComparerSortCasting.CastingObjects
{
    public abstract class Shape : Object
    {
    }
    public class Circle : Shape
    {
        public double Radius { get; set; }

    }
    public class Rectangle : Shape
    {
        public Circle Igul { get; set; }
    }
    public static class CastingObjects
    {
        public static void Foo(Shape shape)
        {
            // 1
            Circle circle = shape as Circle;

            // if shape isn't a Circle will receive a null value
            if (circle != null)
            {
                // shape is Circle, now we can work with the object

            }

            // 2
            // returns a boll of the shape is of type Circle
            if (shape is Circle)
            {
                Circle c2 = shape as Circle;
                Circle c4 = (Circle)shape;
            }

            // 3 - casting
            // use only of we know the type will be compatible 100%
            Circle c3 = (Circle)shape; // crash if s is not Circle

            Console.WriteLine();

        }
    }
}
