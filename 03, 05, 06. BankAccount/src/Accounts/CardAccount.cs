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
        
        public override void PutMoney(double moneyAmount)
        {
            base.PutMoney(moneyAmount);
            Console.WriteLine("Money are put on card: " + CardNumber);
        }
        
        public override void PutMoney(int moneyAmount)
        {
            base.PutMoney(moneyAmount);
            Console.WriteLine("Money are put on card: " + CardNumber);
        }

        public override void WithdrawMoney(double moneyAmount)
        {
            base.WithdrawMoney(moneyAmount);
            Console.WriteLine("Money are withdrawn from card: " + CardNumber);
        }
        
        public override void WithdrawMoney(int moneyAmount)
        {
            base.WithdrawMoney(moneyAmount);
            Console.WriteLine("Money are withdrawn from card: " + CardNumber);
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