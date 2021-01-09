using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetrievingDataFromThreadFunctionCallback
{
    // Step 1: Create a callback delegate. The actual callback method
    // signature should match with the signature of this delegate.
    public delegate void SumOfNumbersCallback(int sumOfNumbers);

    // Step 2: Create Number class to compute the sum of numbers and
    // to call the callback method
    class Number
    {
        // The traget number this class needs to compute the sum of numbers
        int _target;

        // Delegate to call when the the Thread function completes                 
        // computing the sum of numbers
        SumOfNumbersCallback _callbackMethod;

        // Constructor to initialize the target number and the callback delegateinitialize
        public Number(int target, SumOfNumbersCallback callbackMethod)
        {
            this._target = target;
            this._callbackMethod = callbackMethod;
        }

        // This thread function computes the sum of numbers and then invokes
        // the callback method passing it the sum of numbers
        public void ComputeSumOfNumbers()
        {
            int sum = 0;
            for (int i = 1; i <= _target; i++)
            {
                sum = sum + i;
            }

            if (_callbackMethod != null)
            {
                _callbackMethod(sum);
            }
        }
    }
}
