using System;

namespace BankAccount.Accounts
{
    public struct CardInfo
    {
        public int Number;
        public DateTime ExpirationDate;

        public CardInfo(int number, DateTime expirationDate)
        {
            Number = number;
            ExpirationDate = expirationDate;
        }

        public override string ToString()
        {
            return String.Format("CardInfo{{\n" +
                                 "number = {0}\n" +
                                 "expirationDate = {1}\n" +
                                 "}}",
                Number, ExpirationDate.ToString("dd-MM-yyyy"));
        }
    }
}