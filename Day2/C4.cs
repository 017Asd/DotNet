using System;
class c4
{
    static void Main4()
    {
        Console.WriteLine("Enter the year: ");
        int year=int.Parse(Console.ReadLine());
        if (year%4==0 || year%400==0)
            Console.WriteLine(year+" is a leap year");
        else    
            Console.WriteLine(year+" is not a leap year");
    } 
}