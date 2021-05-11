using System;

namespace BankAccount.Accounts
{
    public class ForbiddenOperationException : Exception
    {
        public ForbiddenOperationException(string? message) : base(message)
        {
        }
    }
}