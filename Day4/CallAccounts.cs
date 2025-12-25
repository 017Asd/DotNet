using System;
namespace MainConstructor{ //sealed classes cannot be inherited
    public sealed  class FinancialAccount
    {
        
    }

public class CallAccount
{
    public static void Main(string[] args)
    {
        Account account=new Account()
        {
            AccountID=2,
            Name="ABC"
        };
        Console.WriteLine(account.AccountDetails());
        SalesAccount sa=new SalesAccount()
        {
            AccountID=1,
            Name="a",
            SalesInfo="i am sales"
        };
        Console.WriteLine(sa.SalesDetails());

    }
}
}