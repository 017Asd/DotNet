using System;
using System.Security.Cryptography;
namespace question
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreditRiskProcessor processor=new CreditRiskProcessor();
            try
            {
                Console.Write("Customer name: ");
                string? name=Console.ReadLine();
                Console.Write("Age: ");
                int age=int.Parse(Console.ReadLine());
                Console.Write("Employment type");
                string employmentType=Console.ReadLine();
                Console.Write("Monthly Income: ");
                double monthlyIncome=double.Parse(Console.ReadLine());
                Console.Write("Credit dues: ");
                double dues=double.Parse(Console.ReadLine());
                Console.Write("Default loan: ");
                int defaults=int.Parse(Console.ReadLine());
                Console.Write("Credit score: ");
                int creditScore=int.Parse(Console.ReadLine());
                processor.ValidateCustomerDetails(age,employmentType,monthlyIncome,dues,creditScore,defaults);
                double limit=processor.CreditLimitCalculation(monthlyIncome,dues,creditScore,defaults);
                Console.WriteLine("Customer name"+name);
                Console.WriteLine("Approved credit limit: "+limit);
            }
            catch(InvalidCreditDataException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}