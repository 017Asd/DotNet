//See https://aka.ms/new-console-template for more information

using System;
class C3
{
    static void Main3()
    {
        //Taking the input 
        Console.Write("Enter the first integer: ");
        int a=int.Parse(Console.ReadLine());
        Console.Write("Enter the second integer: ");
        int b=int.Parse(Console.ReadLine());
        Console.Write("Enter the thirc integer: ");
        int c=int.Parse(Console.ReadLine());
        
        if (a>=b && a>=c)
            Console.WriteLine("Maximum number is: "+a);
        else if(b>=a && b>=c)
            Console.WriteLine("Maximum Number is: "+b);
        else 
            Console.WriteLine("Maximum Number is: "+c);
        
}
}