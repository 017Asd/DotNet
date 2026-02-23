using System;
namespace MainConstructor
{
    public abstract class Employee
    {
        public int EmpId{get;set;}
        public double salary{get;set;}

        public abstract double CalTax();
       
    }
    public class IndianEmployee : Employee
    {
        public int taxamount;
        public override double CalTax()
        {
            return salary*taxamount;
        }
        
    }

    public class UsEmployee : Employee
    {
        public int Taxation;
        public override double CalTax()
        {
            return salary*2*Taxation;
        }

    }
}