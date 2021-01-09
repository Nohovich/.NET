using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeakReference
{
    class Program
    {
        /// <summary>
        /// Points to data that can be garbage collected any time.
        /// </summary>
        static WeakReference _weak;

        static void Main()
        {
            // Assign the WeakReference.
            _weak = new WeakReference(new StringBuilder("perls"));

            // See if weak reference is alive.
            if (_weak.IsAlive)
            {
                Console.WriteLine((_weak.Target as StringBuilder).ToString());
            }

            // Invoke GC.Collect.
            // ... If this is commented out, the next condition will evaluate true.
            GC.Collect();

            // Check alive.
            if (_weak.IsAlive)
            {
                Console.WriteLine("IsAlive");
            }

            // Finish.
            Console.WriteLine("[Done]");
            Console.Read();
        }
    }
}
