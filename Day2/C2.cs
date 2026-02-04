// See https://aka.ms/new-console-template for more information

using System;
class C2
{
    static void Main2()
    {
        //Taking the input 
        Console.Write("Enter the height in cm: ");
        int height=int.Parse(Console.ReadLine());

        //Conditions for categorising height 
        if (height<150)
            Console.WriteLine("Dwarf");
        else if(height>=150&&height<165)
            Console.WriteLine("Average");
        else if(height>=165&&height<=190)
            Console.WriteLine("Tall");
        else    
            Console.WriteLine("Abnormal");
    }
}