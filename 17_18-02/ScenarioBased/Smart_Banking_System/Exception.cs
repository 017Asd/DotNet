using System;

namespace Q2
{
    public class InvalidAmountException : Exception
    {
        public InvalidAmountException(string message) : base(message)
        {
        }
    }

    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message) : base(message)
        {
        }
    }

    public class InvalidAccountException : Exception
    {
        public InvalidAccountException(string message) : base(message)
        {
        }
    }
}
