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

        public override bool PutMoney(double moneyAmount)
        {
            bool isPut = base.PutMoney(moneyAmount);

            if (isPut)
            {
                Console.WriteLine("Money are put on account. Iban: " + Iban);
            }

            return isPut;
        }
        
        public override bool PutMoney(int moneyAmount)
        {
            bool isPut = base.PutMoney(moneyAmount);

            if (isPut)
            {
                Console.WriteLine("Money are put on account. Iban: " + Iban);
            }

            return isPut;
        }

        public override bool WithdrawMoney(double moneyAmount)
        {
            bool isPut = base.WithdrawMoney(moneyAmount);

            if (isPut)
            {
                Console.WriteLine("Money are withdrawn from account. Iban: " + Iban);
            }

            return isPut;
        }
        
        public override bool WithdrawMoney(int moneyAmount)
        {
            bool isPut = base.WithdrawMoney(moneyAmount);

            if (isPut)
            {
                Console.WriteLine("Money are withdrawn from account. Iban: " + Iban);
            }

            return isPut;
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