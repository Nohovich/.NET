using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MulticastDelegates
{
    class Program
    {
        // Action (1 line !!!)
        public Action<int> TheAfterFunciton { get; set; }

        public delegate void SampleDelegate1();
        public delegate void SampleDelegate2();
        public delegate int SampleDelegate3();
        // Deletegate has an int output parameter
        public delegate void SampleDelegate4(out int Integer);
        static void Main(string[] args)
        {
            // Approach 1: 
            SampleDelegate1 del1 = new SampleDelegate1(SampleMethodOne);
            SampleDelegate1 del2 = new SampleDelegate1(SampleMethodTwo);
            SampleDelegate1 del3 = new SampleDelegate1(SampleMethodThree);
            // In this example del4 is a multicast delegate. You use +(plus) 
            // operator to chain delegates together and -(minus) operator to remove.
            SampleDelegate1 del4 = del1 + del2 + del3 - del2;
            del4();

            // Approach 2:
            // In this example del is a multicast delegate. You use += operator 
            // to chain delegates together and -= operator to remove.
            SampleDelegate2 delAp2 = new SampleDelegate2(SampleMethodOne);
            delAp2 += SampleMethodTwo;
            delAp2 += SampleMethodThree;
            delAp2 -= SampleMethodTwo;
            del2();

            // Multicast delegate with an int return type:
            SampleDelegate3 delAp3 = new SampleDelegate3(SampleMethodOneInt);
            delAp3 += SampleMethodTwoInt;


            // The ValueReturnedByDelegate will be 2, returned by the SampleMethodTwo(),
            // as it is the last method in the invocation list.
            int ValueReturnedByDelegate = delAp3();
            Console.WriteLine("Returned Value = {0}", ValueReturnedByDelegate);

            // Multicast delegate with an integer output parameter:
            SampleDelegate4 delAp4 = new SampleDelegate4(SampleMethodOne);
            delAp4 += SampleMethodTwo;


            // The ValueFromOutPutParameter will be 2, initialized by SampleMethodTwo(),
            // as it is the last method in the invocation list.
            int ValueFromOutPutParameter = -1;
            delAp4(out ValueFromOutPutParameter);
            Console.WriteLine("Returned Value = {0}", ValueFromOutPutParameter);

        }
        public static void SampleMethodOne()
        {
            Console.WriteLine("SampleMethodOne Invoked");
        }


        public static void SampleMethodTwo()
        {
            Console.WriteLine("SampleMethodTwo Invoked");
        }


        public static void SampleMethodThree()
        {
            Console.WriteLine("SampleMethodThree Invoked");
        }

        // This method returns one
        public static int SampleMethodOneInt()
        {
            return 1;
        }


        // This method returns two
        public static int SampleMethodTwoInt()
        {
            return 2;
        }

        // This method sets ouput parameter Number to 1
        public static void SampleMethodOne(out int Number)
        {
            Number = 1;
        }


        // This method sets ouput parameter Number to 2
        public static void SampleMethodTwo(out int Number)
        {
            Number = 2;
        }
    }
}
