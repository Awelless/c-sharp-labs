using System;

namespace BankAccount.Accounts
{
    public abstract class AbstractAccount : IComparable<AbstractAccount>
    {
        private static uint _idCounter = 1;
        
        public uint Id { get; }
        public double Balance { get; protected set; }
        public Currency Currency { get; }
        public bool IsBlocked { get; private set; }

        public AbstractAccount(Currency currency)
        {
            Id = _idCounter++;
            Balance = 0;
            Currency = currency;
            IsBlocked = false;
        }

        public virtual bool PutMoney(double moneyAmount)
        {
            if (moneyAmount < 0)
            {
                Console.WriteLine("Invalid value of moneyAmount: " + moneyAmount);
                return false;
            }

            if (IsBlocked)
            {
                Console.WriteLine("You count put money. Account is blocked");
                return false;
            }

            Balance += moneyAmount;
            return true;
        }
        
        public virtual bool PutMoney(int moneyAmount)
        {
            if (moneyAmount < 0)
            {
                Console.WriteLine("Invalid value of moneyAmount: " + moneyAmount);
                return false;
            }

            if (IsBlocked)
            {
                Console.WriteLine("You count put money. Account is blocked");
                return false;
            }

            Balance += moneyAmount;
            return true;
        }

        public virtual bool WithdrawMoney(double moneyAmount)
        {
            if (moneyAmount < 0)
            {
                Console.WriteLine("Invalid value of moneyAmount: " + moneyAmount);
                return false;
            }
            
            if (IsBlocked)
            {
                Console.WriteLine("You count withdraw money. Account is blocked");
                return false;
            }

            if (moneyAmount > Balance)
            {
                Console.WriteLine("You don't have enough money to withdraw: " + moneyAmount);
                return false;
            }

            Balance -= moneyAmount;
            return true;
        }
        
        public virtual bool WithdrawMoney(int moneyAmount)
        {
            if (moneyAmount < 0)
            {
                Console.WriteLine("Invalid value of moneyAmount: " + moneyAmount);
                return false;
            }
            
            if (IsBlocked)
            {
                Console.WriteLine("You count withdraw money. Account is blocked");
                return false;
            }

            if (moneyAmount > Balance)
            {
                Console.WriteLine("You don't have enough money to withdraw: " + moneyAmount);
                return false;
            }

            Balance -= moneyAmount;
            return true;
        }

        public void BlockAccount()
        {
            IsBlocked = true;
        }
        
        public void UnblockAccount()
        {
            IsBlocked = true;
        }

        public int CompareTo(AbstractAccount o)
        {
            if (o == null)
            {
                return -1;
            }
            
            if (Id > o.Id)
            {
                return 1;
            }

            if (Id < o.Id)
            {
                return -1;
            }

            return 0;
        }

        public override bool Equals(Object o)
        {
            if (o == this)
            {
                return true;
            }

            if (o == null || o.GetType() != GetType())
            {
                return false;
            }

            AbstractAccount bankAbstractAccount = (AbstractAccount) o;
            return bankAbstractAccount.Id == Id;
        }

        public override int GetHashCode()
        {
            return (int) Id;
        }

        public override string ToString()
        {
            return String.Format("BankAccount{{\n" +
                                 "id = {0}\n" +
                                 "balance = {1}\n" +
                                 "currency = {2}\n" +
                                 "isBlocked = {3}\n" +
                                 "}}", 
                Id, Balance, Currency, IsBlocked);
        }
    }
}