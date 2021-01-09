using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassingDataToThreadFunctionSafe
{
    class Number
    {
        // Number class also contains the data it needs to print the numbers
            int _target;
            // When an instance is created, the target number needs to be specified
            public Number(int target)
            {
                // The targer number is then stored in the class private variable _target
                this._target = target;
            }

            // Function prints the numbers from 1 to the traget number that the user provided
            public void PrintNumbers()
            {
                for (int i = 1; i <= _target; i++)
                {
                    Console.WriteLine(i);
                }
            } 
    }
}
