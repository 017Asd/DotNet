// See https://aka.ms/new-console-template for more information
using System;
using MainConstructor;
public class Program{
    public static void Main(string[] args)
    {
        IndianEmployee employee=new IndianEmployee()
        {
            salary=100000,
            EmpId=2,
            taxamount=2
        };
        Console.WriteLine(employee.CalTax());
    }
}
