using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolveDeadlockInMultithreaded
{
    public class AccountManager
    {
        Account _fromAccount;
        Account _toAccount;
        double _amountToTransfer;

        public AccountManager(Account fromAccount, Account toAccount, double amountToTransfer)
        {
            this._fromAccount = fromAccount;
            this._toAccount = toAccount;
            this._amountToTransfer = amountToTransfer;
        }

        public void Transfer()
        {
            object _lock1, _lock2;

            if (_fromAccount.ID < _toAccount.ID)
            {
                _lock1 = _fromAccount;
                _lock2 = _toAccount;
            }
            else
            {
                _lock1 = _toAccount;
                _lock2 = _fromAccount;
            }

            Console.WriteLine(Thread.CurrentThread.Name
                + " trying to acquire lock on "
                + ((Account)_lock1).ID.ToString());

            lock (_lock1)
            {
                Console.WriteLine(Thread.CurrentThread.Name
                    + " acquired lock on "
                    + ((Account)_lock1).ID.ToString());

                Console.WriteLine(Thread.CurrentThread.Name
                    + " suspended for 1 second");

                Thread.Sleep(1000);
                Console.WriteLine(Thread.CurrentThread.Name
                    + " back in action and trying to acquire lock on "
                    + ((Account)_lock2).ID.ToString());

                lock (_lock2)
                {
                    Console.WriteLine(Thread.CurrentThread.Name
                        + " acquired lock on "
                        + ((Account)_lock2).ID.ToString());

                    _fromAccount.Withdraw(_amountToTransfer);
                    _toAccount.Deposit(_amountToTransfer);

                    Console.WriteLine(Thread.CurrentThread.Name + " Transfered "
                        + _amountToTransfer.ToString() + " from "
                        + _fromAccount.ID.ToString() + " to "
                        + _toAccount.ID.ToString());
                }
            }
        }
    }
}
