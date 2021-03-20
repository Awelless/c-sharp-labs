using System;

namespace BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount();

            Console.WriteLine("Starting balance: " + account.Balance);
            account.PutMoney(200);
            Console.WriteLine("New balance: " + account.Balance);
            Console.WriteLine();
            
            account.WithdrawMoney(150.23153);
            account.BlockAccount();
            
            Console.WriteLine(account);
            Console.WriteLine();
            
            account.WithdrawMoney(20);
            Console.WriteLine();

            BankAccount anotherAccount = new BankAccount();
            
            Console.WriteLine(account.Equals(anotherAccount));
            Console.WriteLine();

            
            Bank bank = new Bank(account, anotherAccount);
            
            Console.WriteLine("2nd account in bank:");
            Console.WriteLine(bank[1]);

            bank[0] = anotherAccount;
            
            Console.WriteLine(bank[0].Equals(bank[1]));
        }
    }
}