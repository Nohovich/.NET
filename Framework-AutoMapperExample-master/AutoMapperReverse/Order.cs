﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperReverse
{
    public class Order
    {
        public int OrderNo { get; set; }
        public int NumberOfItems { get; set; }
        public int TotalAmount { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Postcode { get; set; }
        public string MobileNo { get; set; }
    }
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FullName { get; set; }
        public string Postcode { get; set; }
        public string ContactNo { get; set; }
    }
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public int NumberOfItems { get; set; }
        public int TotalAmount { get; set; }
        public Customer customer { get; set; }
    }
}
