using System;

namespace BankAccount.Accounts
{
    public class CardAccount : AbstractAccount
    {
        public CardInfo CardInfo { get; }
        
        public CardAccount(Currency currency, int cardNumber, DateTime cardExpirationDate) : base(currency)
        {
            CardInfo = new CardInfo(cardNumber, cardExpirationDate);
        }
        
        public override bool PutMoney(double moneyAmount)
        {
            bool isPut = base.PutMoney(moneyAmount);
            
            if (isPut)
            {
                Console.WriteLine("Money are put on card: " + CardInfo.Number);   
            }

            return isPut;
        }
        
        public override bool PutMoney(int moneyAmount)
        {
            bool isPut = base.PutMoney(moneyAmount);

            if (isPut)
            {
                Console.WriteLine("Money are put on card: " + CardInfo.Number);   
            }

            return isPut;
        }

        public override bool WithdrawMoney(double moneyAmount)
        {
            bool isPut = base.WithdrawMoney(moneyAmount);
            
            if (isPut)
            {
                Console.WriteLine("Money are withdrawn from card: " + CardInfo.Number);
            }

            return isPut;
        }
        
        public override bool WithdrawMoney(int moneyAmount)
        {
            bool isPut = base.WithdrawMoney(moneyAmount);
            
            if (isPut)
            {
                Console.WriteLine("Money are withdrawn from card: " + CardInfo.Number);
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
                                 "cardInfo = {4}\n" +
                                 "}}", 
                Id, Balance, Currency, IsBlocked, CardInfo);
        }
    }
}