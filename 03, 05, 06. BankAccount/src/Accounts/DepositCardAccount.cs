using System;

namespace BankAccount.Accounts
{
    public class DepositCardAccount : CardAccount, IDeposit
    {
        public double Rate { get; }
        
        public DepositCardAccount(Currency currency, int cardNumber, double rate) : base(currency, cardNumber)
        {
            Rate = rate;
        }

        public void UpdateBalance()
        {
            Balance += Balance * Rate;
        }

        public override string ToString()
        {
            return String.Format("DepositCardAccount{{\n" +
                                 "id = {0}\n" +
                                 "balance = {1}\n" +
                                 "currency = {2}\n" +
                                 "isBlocked = {3}\n" +
                                 "cardNumber = {4}\n" +
                                 "rate = {5}\n" +
                                 "}}", 
                Id, Balance, Currency, IsBlocked, CardNumber, Rate);
        }
    }
}