using System;
namespace MainConstructor{
public class Inheritance
{
    public static void Main(string[] args)
    {
        Son son=new Son(10000, 2000, 5000);
    //calling 
        Console.WriteLine(son.Insurance());
        Console.WriteLine(son.SavingMoney());
        Console.WriteLine(son.Savings());
    }
}
}