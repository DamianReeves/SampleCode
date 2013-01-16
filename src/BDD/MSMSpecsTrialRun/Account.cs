namespace MSMSpecsTrialRun
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    public class Account
    {
        private decimal balance;

        public decimal Balance
        {
            get { return this.balance; }
            set { this.balance = value; }
        }

        public void Transfer(decimal amount, Account toAccount)
        {
            if (amount > balance)
            {
                throw new Exception(String.Format("Cannot transfer ${0}. The available balance is ${1}.", amount, balance));
            }

            balance -= amount;
            toAccount.Balance += amount;
        }

        public void Withdraw(decimal amount)
        {            
        }
    }
}
