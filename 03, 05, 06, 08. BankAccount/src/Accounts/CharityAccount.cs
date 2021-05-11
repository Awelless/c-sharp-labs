using System;

namespace BankAccount.Accounts
{
    public class CharityAccount : AbstractAccount, ICharity
    {
        public CharityAccount(Currency currency) : base(currency)
        {
        }

        public void Donate(double moneyAmount)
        {
            Balance += moneyAmount;
            Console.WriteLine("You've donated to charity. Thank you");
        }

        public void Donate(int moneyAmount)
        {
            Balance += moneyAmount;
            Console.WriteLine("You've donated to charity. Thank you");
        }

        public override string ToString()
        {
            return String.Format("CharityAccount{{\n" +
                                 "id = {0}\n" +
                                 "balance = {1}\n" +
                                 "currency = {2}\n" +
                                 "isBlocked = {3}\n" +
                                 "}}", 
                Id, Balance, Currency, IsBlocked);
        }
    }
}