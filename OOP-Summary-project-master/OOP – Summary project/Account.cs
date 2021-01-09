using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Summary_project
{
   public class Account
    {
        private static int _numberOfAcounts;
        private readonly int _acountNumber;
        private readonly Customer _acountOwner;
        private int _maxMinusAllowed;
        public int AcountNumber
        {
            get
            {
                return _acountNumber;
            }
        }
        public int _balance { get; private set; }
        public Customer AcountOwner
        {
            get
            {
                return _acountOwner;
            }
        }
        public int  maxMinusAllowed
        {
            get
            {
                return _maxMinusAllowed;
            }
        }

        public Account(int monthlyIncome, Customer customer)
        {
            _numberOfAcounts++;
            _acountNumber = _numberOfAcounts;
            _acountOwner = customer;
            _maxMinusAllowed = monthlyIncome * -3;
        }

        public override bool Equals(object obj)
        {
            Account account = obj as Account;
            return this.AcountNumber == account.AcountNumber;
        }

        public override int GetHashCode()
        {
            return AcountNumber;
        }
        public static bool operator ==(Account account1, Account account2)
        {
            if (ReferenceEquals(account1, null) && ReferenceEquals(account2, null))
            {
                return true;
            }
            if (ReferenceEquals(account1, null) || ReferenceEquals(account2, null))
            {
                return false;
            }
            if (account1.AcountNumber == account2.AcountNumber)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Account account1, Account account2)
        {
            return !(account1 == account2);
        }
        public static Account operator +(Account account1, Account account2)
        {
            if(account1.AcountOwner == account2.AcountOwner)
            {
                Account account = new Account(account1._maxMinusAllowed / 3 + account2._maxMinusAllowed / 3, account1._acountOwner);
                return account;
            }
            else throw new NotSameCustomerException("you cant add accounts from two different owners");
        }
        public static Account operator +(Account account1, int amount) // help
        {
            account1.Add(amount);
            return account1;
        }
        public static Account operator -(Account account1, int amount) // help
        {
            if (account1._balance - amount < account1.maxMinusAllowed)
            {
                 throw new BalanceException("you have reached the max minus allowed for your account sorry ");
            }
            else
            {
                 account1.Subtract(amount);
                 return account1;
            }
        }
        public void Add(int amount)
        {
            this._balance += amount;
        }
        public void Subtract(int amount)
        {
            this._balance -= amount;
        }

        public override string ToString()
        {
            return $"Account owner {_acountOwner}, {AcountNumber}";
        }
    }
}
