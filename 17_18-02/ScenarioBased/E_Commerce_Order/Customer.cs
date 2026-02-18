namespace Q3
{
    public class Customer
    {
        public int CustomerId{get;set;}
        public string Name{get;set;}
        public bool IsBlackListed{get;set;}
        public Customer(int customerid,string name,bool blackliststatus)
        {
            CustomerId=customerid;
            Name=name;
            IsBlackListed=blackliststatus;
        }

    }
}