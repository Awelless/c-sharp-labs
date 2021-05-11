using System;

namespace BankAccount.Accounts
{
    public abstract class AbstractAccount : IComparable<AbstractAccount>
    {
        public delegate void InfoMessageHandler(string message);

        public event InfoMessageHandler InfoEvent;
        
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

        public virtual void PutMoney(double moneyAmount)
        {
            if (moneyAmount < 0)
            {
                throw new ArgumentException("Invalid value of moneyAmount: " + moneyAmount);
            }

            if (IsBlocked)
            {
                throw new ForbiddenOperationException("You can't put money. Account is blocked");
            }

            Balance += moneyAmount;
        }
        
        public virtual void PutMoney(int moneyAmount)
        {
            if (moneyAmount < 0)
            {
                throw new ArgumentException("Invalid value of moneyAmount: " + moneyAmount);
            }

            if (IsBlocked)
            {
                throw new ForbiddenOperationException("You can't put money. Account is blocked");
            }

            Balance += moneyAmount;
        }

        public virtual void WithdrawMoney(double moneyAmount)
        {
            if (moneyAmount < 0)
            {
                throw new ArgumentException("Invalid value of moneyAmount: " + moneyAmount);
            }
            
            if (IsBlocked)
            {
                throw new ForbiddenOperationException("You can't withdraw money. Account is blocked");
            }

            if (moneyAmount > Balance)
            {
                throw new ForbiddenOperationException("You don't have enough money to withdraw: " + moneyAmount);
            }

            Balance -= moneyAmount;
        }
        
        public virtual void WithdrawMoney(int moneyAmount)
        {
            if (moneyAmount < 0)
            {
                throw new ArgumentException("Invalid value of moneyAmount: " + moneyAmount);
            }
            
            if (IsBlocked)
            {
                throw new ForbiddenOperationException("You can't withdraw money. Account is blocked");
            }

            if (moneyAmount > Balance)
            {
                throw new ForbiddenOperationException("You don't have enough money to withdraw: " + moneyAmount);
            }

            Balance -= moneyAmount;
        }

        public void BlockAccount()
        {
            IsBlocked = true;
            InfoEvent?.Invoke("Account is blocked");
        }
        
        public void UnblockAccount()
        {
            IsBlocked = false;
            InfoEvent?.Invoke("Account is unblocked");
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

        protected void InvokeInfoEvent(string message)
        {
            InfoEvent?.Invoke(message);
        }
    }
}