namespace BankAccount.Accounts
{
    public interface ICharity
    {
        void Donate(double moneyAmount);
        void Donate(int moneyAmount);
    }
}