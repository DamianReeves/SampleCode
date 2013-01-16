namespace SpecFlowTrialRun
{
    using System;

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
            if (amount > this.balance)
            {
                throw new Exception(String.Format("Cannot transfer ${0}. The available balance is ${1}.", amount, this.balance));
            }

            this.balance -= amount;
            toAccount.Balance += amount;
        }

        public void Withdraw(decimal amount)
        {            
        }
    }
}
