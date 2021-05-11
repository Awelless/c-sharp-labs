using System;
using BankAccount.Accounts;

namespace BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractAccount cardAccount = new CardAccount(Currency.EUR, 4133, DateTime.Parse("10/12/2023"));
            cardAccount.InfoEvent += PrintEventInConsole;

            try
            {
                Console.WriteLine("Starting balance: " + cardAccount.Balance);
                cardAccount.PutMoney(200);
                Console.WriteLine("New balance: " + cardAccount.Balance);
                Console.WriteLine();
                
                cardAccount.WithdrawMoney(150.23153);
                cardAccount.BlockAccount();
                
                Console.WriteLine(cardAccount);
                Console.WriteLine();
                
                cardAccount.WithdrawMoney(20);
            }
            catch (ForbiddenOperationException e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            Console.WriteLine();

            AbstractAccount depositCardAccount = new DepositCardAccount(Currency.USD, 1234, DateTime.Parse("10/12/2024"), 0.05);
            depositCardAccount.InfoEvent += message => Console.WriteLine("Info: " + message); 
            
            depositCardAccount.PutMoney(100);
            ((DepositCardAccount) depositCardAccount).UpdateBalance();
            
            Console.WriteLine(cardAccount.Equals(depositCardAccount));
            Console.WriteLine();

            AbstractAccount internationalAccount = new InternationalAccount(Currency.GBP, 1239812389);
            internationalAccount.InfoEvent += delegate(string message)
            {
                Console.WriteLine("Very important info: " + message);
            };
            
            internationalAccount.PutMoney(10000);

            AbstractAccount charityAccount = new CharityAccount(Currency.RUB);
            charityAccount.InfoEvent += PrintEventInConsole;
            ((CharityAccount) charityAccount).Donate(20);

            Bank bank = new Bank(cardAccount, depositCardAccount, internationalAccount, charityAccount);
            
            Console.WriteLine();
            Console.WriteLine("2nd account in bank:");
            Console.WriteLine(bank[1]);
            Console.WriteLine();

            bank[0] = depositCardAccount;
            
            Console.WriteLine(bank[0].Equals(bank[1]));
            Console.WriteLine(internationalAccount.CompareTo(depositCardAccount));
            
            ICharity charity = new CharityAccount(Currency.RUB);
            charity.Donate(123);

            bool enoughMoney = IsEnoughMoney(internationalAccount, moneyAmount => moneyAmount > 5000);
            Console.WriteLine("Enough money: " + enoughMoney);
        }

        private static void PrintEventInConsole(string message)
        {
            Console.WriteLine(message);
        }

        private static bool IsEnoughMoney(AbstractAccount account, Predicate<double> predicate)
        {
            return predicate.Invoke(account.Balance);
        } 
    }
}