using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace OOP___Summary_project
{
    public class Bank : IBank
    {
        List<Account> accounts;
        List<Customer> customers;
        Dictionary<int,Customer> _dictionaryCustomerID;
        Dictionary<int, Customer> _dictionaryCustomerPh;
        Dictionary<int, Account> _dictionaryAccountNum;
        Dictionary<Customer, List<Account>> _dictionaryAccountList;
        private int _TotalMoneyInBank;
        private int _profits;

        public string Name { get; private set; }

        public string Address { get; private set; }

        public int CustomerCount { get; private set; }

        public Bank(string name, string address)
        {
            Name = name;
            Address = address;
            accounts = new List<Account>();
            customers = new List<Customer>();
            _dictionaryCustomerID = new Dictionary<int, Customer>();
            _dictionaryCustomerPh = new Dictionary<int, Customer>();
            _dictionaryAccountNum = new Dictionary<int, Account>();
            _dictionaryAccountList = new Dictionary<Customer, List<Account>>();
            CustomerCount = 0;
            _TotalMoneyInBank = 0;
            _profits = 0;
        }
        public Bank()
        {

        }
        internal Customer GetCustomerByID(int customerID)
        {
            if (_dictionaryCustomerID.ContainsKey(customerID))
            {
                return _dictionaryCustomerID[customerID];
            }
            else throw new CustomerNotFoundException("we cant find the customer you are looking / you have entered a wrong key");
        }
        internal Customer GetCustomerByNumber(int customerNumber)
        {
            if (_dictionaryCustomerPh.ContainsKey(customerNumber))
            {
                return _dictionaryCustomerPh[customerNumber];
            }
            else throw new CustomerNotFoundException("we cant find the customer you are looking / you have entered a wrong key");
        }
        internal Account GetAccountByNumber(int AccountNumber)
        {
            if (_dictionaryAccountNum.ContainsKey(AccountNumber))
            {
                return _dictionaryAccountNum[AccountNumber];
            }
            else throw new AccountNotFoundException("we cant find the account you are looking / you have entered a wrong key");
        }
        internal List<Account> GetAccountSByCustomer(Customer customer)
        {
            if (_dictionaryAccountList.ContainsKey(customer))
            {
                return _dictionaryAccountList[customer];
            }
            else throw new AccountNotFoundException("we cant find the account you are looking / you have entered a wrong key  ");
        }
        internal void AddNewCustomer(Customer customer)
        {
            if (!customers.Contains(customer))
            {
                _dictionaryCustomerID.Add(customer.CustomerID, customer);
                _dictionaryCustomerPh.Add(customer._phNumber, customer);
                customers.Add(customer);
                CustomerCount++;
            }
            else throw new ThisCustomerIsAlreadyInTheSystemException("you are trying to add a customer thats already in the system");
        }
        internal void OpenNewAcount(Customer customer, Account account)
        {

            if (customers.Contains(customer))
            {
                if (!accounts.Contains(account))
                {
                    if (!_dictionaryAccountList.ContainsKey(customer))
                    {
                        List<Account> accounts = new List<Account>();
                        _dictionaryAccountList.Add(customer, accounts);

                    }
                    if (_dictionaryAccountList.ContainsKey(customer))
                    {
                        List<Account> accounts = _dictionaryAccountList[customer];
                        accounts.Add(account);
                        _dictionaryAccountList[customer] = accounts;
                    }
                    _dictionaryAccountNum.Add(account.AcountNumber, account);
                    accounts.Add(account);
                    _TotalMoneyInBank += account._balance;
                }
                else throw new ThisAccountIsAlreadyInTheSystemException("you are trying to add an account thats already in the system");
            }
            else throw new CustomerNotFoundException("we cant find the customer you are looking / try add the customer to the system first");

        }
        internal int Deposit(Account account, int amount)
        {
            account.Add(amount);
            _TotalMoneyInBank += amount;
            return account._balance;
        }
        internal int wWthdrawal(Account account, int withdrawal)
        {
            if(account._balance - withdrawal < account.maxMinusAllowed)
            {
                throw new BalanceException("you have reached the max minus allowed for your account sorry ");
            }
            account.Subtract(withdrawal);
            _TotalMoneyInBank -= withdrawal;
            return account._balance;
        }
        internal int GetCustomerTotalBalance(Account account)
        {
            int totalBalance = 0;
            foreach (Account account1 in accounts)
            {
                if(account1.AcountOwner == account.AcountOwner)
                {
                    totalBalance += account1._balance;
                }
            }
            return totalBalance;
        }
        internal void CloseAcount(Account account, Customer customer)
        {
            if (accounts.Contains(account))
            {
                _dictionaryAccountNum.Remove(account.AcountNumber);
                accounts.Remove(account);
                _TotalMoneyInBank -= account._balance;
            }
        }
        internal void ChargeAnnualCommossion(float percentage)
        {
            foreach (Account account in accounts)
            {
                if (account._balance<=0)
                {
                    _profits += (int)(account._balance * percentage * 2);
                    account.Subtract((int)(account._balance * percentage * 2));
                    _TotalMoneyInBank -= (int)(account._balance * percentage * 2);
                }
                if (account._balance>0)
                {
                    _profits += (int)(account._balance * percentage);
                    account.Subtract((int)(account._balance * percentage));
                    _TotalMoneyInBank -= (int)(account._balance * percentage);
                }
            }
        }
        internal Account JoinAccounts(Account account1, Account account2)
        {
            Account account;
            account = account1 + account2;
            if(account != null)
            {
                _TotalMoneyInBank -= account1._balance;
                _TotalMoneyInBank -= account2._balance;
                _dictionaryAccountNum.Remove(account1.AcountNumber);
                accounts.Remove(account1);
                accounts.Remove(account2);
                _dictionaryAccountNum.Remove(account2.AcountNumber);
                _dictionaryAccountNum.Add(account.AcountNumber, account);
                accounts.Add(account);
                _TotalMoneyInBank += account._balance;
            }
            return account;
        }

    }
}
