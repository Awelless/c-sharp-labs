using System;

namespace BankAccount.Accounts
{
    public class InternationalAccount : AbstractAccount
    {
        public int Iban { get; }

        public InternationalAccount(Currency currency, int iban) : base(currency)
        {
            Iban = iban;
        }

        public override void PutMoney(double moneyAmount)
        {
            base.PutMoney(moneyAmount);
            Console.WriteLine("Money are put on account. Iban: " + Iban);
        }
        
        public override void PutMoney(int moneyAmount)
        {
            base.PutMoney(moneyAmount);
            Console.WriteLine("Money are put on account. Iban: " + Iban);
        }

        public override void WithdrawMoney(double moneyAmount)
        {
            base.WithdrawMoney(moneyAmount);
            Console.WriteLine("Money are withdrawn from account. Iban: " + Iban);
        }
        
        public override void WithdrawMoney(int moneyAmount)
        {
            base.WithdrawMoney(moneyAmount);
            Console.WriteLine("Money are withdrawn from account. Iban: " + Iban);
        }

        public override string ToString()
        {
            return String.Format("InternationalAccount{{\n" +
                                 "id = {0}\n" +
                                 "balance = {1}\n" +
                                 "currency = {2}\n" +
                                 "isBlocked = {3}\n" +
                                 "iban = {4}\n" +
                                 "}}", 
                Id, Balance, Currency, IsBlocked, Iban);
        }
    }
}