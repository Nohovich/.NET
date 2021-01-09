using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get the Type Using GetType() static method
            Type T = Type.GetType("Reflection.Customer");
            // Print the Type details
            Console.WriteLine("Full Name = {0}", T.FullName);
            Console.WriteLine("Just the Class Name = {0}", T.Name);
            Console.WriteLine("Just the Namespace = {0}", T.Namespace);
            Console.WriteLine();
            // Print the list of Methods
            Console.WriteLine("Methods in Customer Class");
            MethodInfo[] methods = T.GetMethods();
            foreach (MethodInfo method in methods)
            {
                // Print the Return type and the name of the method
                Console.WriteLine(method.ReturnType.Name + " " + method.Name);
            }
            Console.WriteLine();
            //  Print the Properties
            Console.WriteLine("Properties in Customer Class");
            PropertyInfo[] properties = T.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                // Print the property type and the name of the property
                Console.WriteLine(property.PropertyType.Name + " " + property.Name);
            }
            Console.WriteLine();
            //  Print the Constructors
            Console.WriteLine("Constructors in Customer Class");
            ConstructorInfo[] constructors = T.GetConstructors();
            foreach (ConstructorInfo constructor in constructors)
            {
                Console.WriteLine(constructor.ToString());
            }

            // Late binding using reflection
            // Load the current executing assembly as the Customer class is present in it.
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            // Load the Customer class for which we want to create an instance dynamically
            Type customerType = executingAssembly.GetType("Reflection.Customer");
            // Create the instance of the customer type using Activator class 
            object customerInstance = Activator.CreateInstance(customerType);
            // Get the method information using the customerType and GetMethod()
            MethodInfo getFullName = customerType.GetMethod("GetFullName");
            // Create the parameter array and populate first and last names
            string[] methodParameters = new string[2];
            methodParameters[0] = "David"; //FirstName
            methodParameters[1] = "Nohovich";     //LastName
            // Invoke the method passing in customerInstance and parameters array
            string fullName = (string)getFullName.Invoke(customerInstance, methodParameters);
            Console.WriteLine("Full Name = {0}", fullName);

            Console.ReadKey();
        }
    }
}
