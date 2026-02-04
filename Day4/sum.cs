using System;
using System.Diagnostics.Contracts;
using System.Runtime.Intrinsics.X86;
namespace MainConstructor
{
    public class addition{
        //declaration of public variables using get and set
        public int Num1{get; set;}
        public int Num2{get; set;}
        public int Sum{get;}
        //creating a constructor for addition where we are oerrdiing the string output to print the values 
        public addition(int n1,int n2)
    {
       
        this.Num1=n1;
        this.Num2=n2;

        Sum=n1+n2;
        Console.WriteLine("The sum is "+Sum);
        
    }
}

}
