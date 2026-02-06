using System;

namespace GymStream
{
    public class InvalidTierException : Exception
    {
        public InvalidTierException(string message) : base(message) { }
    }
}
