using System.Collections.Generic;

namespace BankAccount.Bank
{
    public class Bank
    {
        private List<BankAccount> BankAccounts = new List<BankAccount>();

        public Bank()
        { }
        
        public Bank(params BankAccount[] bankAccounts)
        {
            foreach (BankAccount account in bankAccounts)
            {
                this.BankAccounts.Add(account);
            }
        }

        public Bank(List<BankAccount> bankAccounts)
        {
            this.BankAccounts = new List<BankAccount>(bankAccounts);
        }

        public BankAccount this[int index]
        {
            get { return BankAccounts[index]; }
            set { BankAccounts[index] = value;  }
        }

        public int GetNumberOfAccounts()
        {
            return BankAccounts.Count;
        } 

        public List<BankAccount> GetAll()
        {
            return BankAccounts;
        }

        public void Add(BankAccount bankAccount)
        {
            BankAccounts.Add(bankAccount);
        }

        public void Remove(BankAccount bankAccount)
        {
            BankAccounts.Remove(bankAccount);
        }
    }
}