using System;

namespace Q6
{
    public class InsufficientSharesException : Exception
    {
        public InsufficientSharesException(string message) : base(message) { }
    }

    public class InvalidTransactionDateException : Exception
    {
        public InvalidTransactionDateException(string message) : base(message) { }
    }
}
