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
        
        public override void PutMoney(double moneyAmount)
        {
            base.PutMoney(moneyAmount);
            InvokeInfoEvent("Money were put on card: " + CardInfo.Number);
        }
        
        public override void PutMoney(int moneyAmount)
        {
            base.PutMoney(moneyAmount);
            InvokeInfoEvent("Money were put on card: " + CardInfo.Number);
        }

        public override void WithdrawMoney(double moneyAmount)
        {
            base.WithdrawMoney(moneyAmount);
            InvokeInfoEvent("Money were withdrawn from card: " + CardInfo.Number);
        }
        
        public override void WithdrawMoney(int moneyAmount)
        {
            base.WithdrawMoney(moneyAmount);
            InvokeInfoEvent("Money were withdrawn from card: " + CardInfo.Number);
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