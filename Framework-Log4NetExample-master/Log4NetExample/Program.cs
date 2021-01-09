using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Log4NetExample
{
    class Program
    {
        // creating log4net instance and getting the name of the class using Reflection
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            // writing to file in Info level
            log.Info("Hello world!");
            Employee e = new Employee();
        }
        public class Employee
        {
            private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            public Employee()
            {
                // writing to file in Debug level
                log.Debug("new emplpoyee!");
            }
            public void BuyTicket()
            {
                try
                {

                }
                catch (Exception ex)
                {
                    // writing to file in Error level
                    log.Error("Buy ticket error " + ex.ToString());
                }
            }
        }


    }
}
