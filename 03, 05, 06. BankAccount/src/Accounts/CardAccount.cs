using System;

namespace BankAccount.Accounts
{
    public class CardAccount : AbstractAccount
    {
        public int CardNumber { get; }
        
        public CardAccount(Currency currency, int cardNumber) : base(currency)
        {
            CardNumber = cardNumber;
        }
        
        public override bool PutMoney(double moneyAmount)
        {
            bool isPut = base.PutMoney(moneyAmount);
            
            if (isPut)
            {
                Console.WriteLine("Money are put on card: " + CardNumber);   
            }

            return isPut;
        }
        
        public override bool PutMoney(int moneyAmount)
        {
            bool isPut = base.PutMoney(moneyAmount);

            if (isPut)
            {
                Console.WriteLine("Money are put on card: " + CardNumber);   
            }

            return isPut;
        }

        public override bool WithdrawMoney(double moneyAmount)
        {
            bool isPut = base.WithdrawMoney(moneyAmount);
            
            if (isPut)
            {
                Console.WriteLine("Money are withdrawn from card: " + CardNumber);
            }

            return isPut;
        }
        
        public override bool WithdrawMoney(int moneyAmount)
        {
            bool isPut = base.WithdrawMoney(moneyAmount);
            
            if (isPut)
            {
                Console.WriteLine("Money are withdrawn from card: " + CardNumber);
            }

            return isPut;
        }

        public override string ToString()
        {
            return String.Format("CardAccount{{\n" +
                                 "id = {0}\n" +
                                 "balance = {1}\n" +
                                 "currency = {2}\n" +
                                 "isBlocked = {3}\n" +
                                 "cardNumber = {4}\n" +
                                 "}}", 
                Id, Balance, Currency, IsBlocked, CardNumber);
        }
    }
}