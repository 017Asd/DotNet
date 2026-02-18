using System;

namespace Q2
{
    public static class Rules
    {
        public static void ValidateDeposit(double amount)
        {
            if (amount <= 0)
                throw new InvalidAmountException("Deposit amount must be greater than zero.");
        }

        public static void ValidateWithdrawal(double amount)
        {
            if (amount <= 0)
                throw new InvalidAmountException("Withdrawal amount must be greater than zero.");
        }

        public static void ValidateBalance(double balance, double withdrawalAmount)
        {
            if (withdrawalAmount > balance)
                throw new InsufficientBalanceException("Insufficient balance.");
        }

        public static void ValidateAccountNumber(int accountNumber)
        {
            if (accountNumber <= 0)
                throw new InvalidAccountException("Account number must be positive.");
        }

        public static void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidAccountException("Account holder name cannot be empty.");
        }
    }
}
