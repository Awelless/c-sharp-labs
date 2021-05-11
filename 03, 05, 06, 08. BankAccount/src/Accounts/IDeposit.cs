namespace BankAccount.Accounts
{
    public interface IDeposit
    {
        double Rate { get; }
        void UpdateBalance();
    }
}