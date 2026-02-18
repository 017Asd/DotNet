namespace Q3
{

        public class OutOfStockException : Exception
        {
            public OutOfStockException(string message) : base(message){}
        }
        public class OrderAlreadyShippedException : Exception
        {
            public OrderAlreadyShippedException(String message) : base(message){}
        }
        public class CustomerBlackListedException : Exception{
        public  CustomerBlackListedException(string message): base(message){}
        }
        
        
    
}