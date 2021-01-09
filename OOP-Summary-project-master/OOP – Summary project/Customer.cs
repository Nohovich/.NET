using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Summary_project
{
    public class Customer
    {
        private static int _numberOfCast;
        private readonly int _customerID;
        private readonly int _customerNumber;
        public string _name { get; private set; }
        public int _phNumber { get; private set; }
        public int CustomerID
        {
            get
            {
                return _customerID;
            }

        }
        public int CustomerNumber
        {
            get
            {
                return _customerNumber;
            }

        }

        public Customer(int customerID, string name, int phNumber)
        {
            _customerID = customerID;
            _name = name;
            _phNumber = phNumber;
            _numberOfCast++;
            _customerNumber = _numberOfCast;

        }
        public override string ToString()
        {
            return $"Customer name {_name}, {CustomerID}, {_phNumber}, {CustomerNumber}";
        }
        public override int GetHashCode()
        {
            return CustomerID;
        }
        public override bool Equals(object obj)
        {
            Customer customer = obj as Customer;
            return this.CustomerID == customer.CustomerID;
        }

        public static bool operator == (Customer customer1, Customer customer2)
        {
           if(ReferenceEquals(customer1,null) && ReferenceEquals(customer2, null))
            {
                return true;
            }
            if (ReferenceEquals(customer1, null) || ReferenceEquals(customer2, null))
            {
                return false;
            }
            if(customer1.CustomerID == customer2.CustomerID)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Customer customer1, Customer customer2)
        {
            return !(customer1 == customer2);
        }
    }
}
