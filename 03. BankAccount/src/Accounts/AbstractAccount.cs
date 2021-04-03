#nullable enable
using System;

namespace BankAccount.Accounts
{
    public class Account
    {
        private static uint _idCounter = 1;
        
        public uint id { get; }
        public double Balance { get; private set; }
        public bool IsBlocked { get; private set; }

        public Account()
        {
            id = _idCounter++;
            Balance = 0;
            IsBlocked = false;
        }

        public void PutMoney(double moneyAmount)
        {
            if (moneyAmount < 0)
            {
                Console.WriteLine("Invalid value of moneyAmount: " + moneyAmount);
                return;
            }

            if (IsBlocked)
            {
                Console.WriteLine("You count put money. Account is blocked");
                return;
            }

            Balance += moneyAmount;
        }
        
        public void PutMoney(int moneyAmount)
        {
            if (moneyAmount < 0)
            {
                Console.WriteLine("Invalid value of moneyAmount: " + moneyAmount);
                return;
            }

            if (IsBlocked)
            {
                Console.WriteLine("You count put money. Account is blocked");
                return;
            }

            Balance += moneyAmount;
        }

        public void WithdrawMoney(double moneyAmount)
        {
            if (moneyAmount < 0)
            {
                Console.WriteLine("Invalid value of moneyAmount: " + moneyAmount);
                return;
            }
            
            if (IsBlocked)
            {
                Console.WriteLine("You count withdraw money. Account is blocked");
                return;
            }

            if (moneyAmount > Balance)
            {
                Console.WriteLine("You don't have enough money to withdraw: " + moneyAmount);
                return;
            }

            Balance -= moneyAmount;
        }
        
        public void WithdrawMoney(int moneyAmount)
        {
            if (moneyAmount < 0)
            {
                Console.WriteLine("Invalid value of moneyAmount: " + moneyAmount);
                return;
            }
            
            if (IsBlocked)
            {
                Console.WriteLine("You count withdraw money. Account is blocked");
                return;
            }

            if (moneyAmount > Balance)
            {
                Console.WriteLine("You don't have enough money to withdraw: " + moneyAmount);
                return;
            }

            Balance -= moneyAmount;
        }

        public void BlockAccount()
        {
            IsBlocked = true;
        }
        
        public void UnblockAccount()
        {
            IsBlocked = true;
        }

        public override bool Equals(object? o)
        {
            if (o == this)
            {
                return true;
            }

            if (o == null || o.GetType() != GetType())
            {
                return false;
            }

            Account bankAccount = (Account) o;
            return bankAccount.id == id;
        }

        public override int GetHashCode()
        {
            return (int) id;
        }

        public override string ToString()
        {
            return String.Format("BankAccount{{\n" +
                                 "id = {0}\n" +
                                 "balance = {1}\n" +
                                 "isBlocked = {2}\n" +
                                 "}}", 
                id, Balance, IsBlocked);
        }
    }
}