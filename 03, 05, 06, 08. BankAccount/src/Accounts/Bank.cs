using System.Collections.Generic;

namespace BankAccount.Accounts
{
    public class Bank
    {
        private List<AbstractAccount> Accounts = new List<AbstractAccount>();

        public Bank()
        { }
        
        public Bank(params AbstractAccount[] Accounts)
        {
            foreach (AbstractAccount account in Accounts)
            {
                this.Accounts.Add(account);
            }
        }

        public Bank(List<AbstractAccount> Accounts)
        {
            this.Accounts = new List<AbstractAccount>(Accounts);
        }

        public AbstractAccount this[int index]
        {
            get { return Accounts[index]; }
            set { Accounts[index] = value;  }
        }

        public int GetNumberOfAccounts()
        {
            return Accounts.Count;
        } 

        public List<AbstractAccount> GetAll()
        {
            return Accounts;
        }

        public void Add(AbstractAccount abstractAccount)
        {
            Accounts.Add(abstractAccount);
        }

        public void Remove(AbstractAccount abstractAccount)
        {
            Accounts.Remove(abstractAccount);
        }
    }
}