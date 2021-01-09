using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Summary_project
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer(1,"David",0506);
            Customer customer2 = new Customer(2, "amir", 0526);
            Customer customer3 = new Customer(3, "elad", 0576);
            Customer customer4 = new Customer(4, "israel", 7506);
            Customer customer5 = new Customer(5, "dor", 2106);
            Customer customer6 = new Customer(6, "matan", 1506);
            Account account1 = new Account(1000, customer1);
            Account account2= new Account(800, customer2);
            Account account3= new Account(2500, customer3);
            Account account4 = new Account(9000, customer4);
            Account account5 = new Account(1200, customer5);
            Account account6 = new Account(3400, customer6);
            Account account7 = new Account(1000, customer1);
            Account account8 = new Account(2500, customer3);
            Bank bank = new Bank("Bank","Tel Aviv");
            bank.AddNewCustomer(customer1);
            bank.AddNewCustomer(customer2);
            bank.AddNewCustomer(customer3);
            bank.AddNewCustomer(customer4);
            bank.AddNewCustomer(customer5);
            bank.AddNewCustomer(customer6);
            try
            {
                bank.AddNewCustomer(customer1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            bank.OpenNewAcount(customer1, account1);
            bank.OpenNewAcount(customer2, account2);
            bank.OpenNewAcount(customer3, account3);
            bank.OpenNewAcount(customer4, account4);
            bank.OpenNewAcount(customer5, account5);
            bank.OpenNewAcount(customer6, account6);
            bank.OpenNewAcount(customer1, account7);
            bank.OpenNewAcount(customer3, account8);
            try
            {
                bank.OpenNewAcount(customer1,account1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            Console.WriteLine(bank.GetAccountByNumber(1));
            try
            {
                Console.WriteLine(bank.GetAccountByNumber(121314));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            Console.WriteLine(bank.GetCustomerByID(2));
            try
            {
                Console.WriteLine(bank.GetCustomerByID(5688));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            Console.WriteLine(bank.GetCustomerByNumber(1506));
            try
            {
                Console.WriteLine(bank.GetCustomerByNumber(197426));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            try
            {
                Console.WriteLine(bank.GetCustomerByNumber(197426));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            bank.Deposit(account1, 2500);
            bank.Deposit(account2, 1946);
            bank.Deposit(account3, 345);
            bank.Deposit(account4, 3564);
            bank.Deposit(account5, 12764);
            bank.Deposit(account6, 2348);
            bank.Deposit(account7, 123);
            bank.Deposit(account8, 3456);
            try
            {
                bank.wWthdrawal(account1, 14000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            bank.wWthdrawal(account2, 300);
            bank.wWthdrawal(account3, 5000);
            bank.wWthdrawal(account4, 2000);
            bank.wWthdrawal(account5, 1000);
            bank.wWthdrawal(account6, 1800);
            bank.wWthdrawal(account7, 120);
            bank.wWthdrawal(account8, 1080);
            bank.JoinAccounts(account1, account7);
            bank.JoinAccounts(account3, account8);
            try
            {
                bank.JoinAccounts(account1, account4);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
           foreach(Account account in bank.GetAccountSByCustomer(customer1))
            {
                Console.WriteLine(account);
            }
            foreach (Account account in bank.GetAccountSByCustomer(customer2))
            {
                Console.WriteLine(account);
            }
            Console.WriteLine(account1);
            account1= account1 + 25;
            Console.WriteLine(account1);
            Console.ReadKey();
        }
    }
}
