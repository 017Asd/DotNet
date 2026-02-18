namespace Q2
{
    public class SavingsAccount : BankAccount
    {
        public SavingsAccount(int accountNumber, string name, double balance)
            : base(accountNumber, name, balance)
        {
        }

        public override double CalculateInterest()
        {
            return Balance * 0.05;
        }
    }

    public class CurrentAccount : BankAccount
    {
        public CurrentAccount(int accountNumber, string name, double balance)
            : base(accountNumber, name, balance)
        {
        }

        public override double CalculateInterest()
        {
            return Balance * 0.02;
        }
    }

    public class LoanAccount : BankAccount
    {
        public LoanAccount(int accountNumber, string name, double balance)
            : base(accountNumber, name, balance)
        {
        }

        public override double CalculateInterest()
        {
            return Balance * 0.10;
        }
    }
}
