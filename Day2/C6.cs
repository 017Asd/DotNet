using System;
class C6
{
    static void Main9()
    {
        Console.WriteLine("Enter the number of units: ");
        int Units=int.Parse(Console.ReadLine());
        double bill=Units;
        if (0<=Units && Units<= 199)
        {
            bill=Units*1.20;
        }
        else if(Units>=200 && Units<=400)
            bill=Units*1.50;
        else if (Units >= 400)
        {
            
            if(Units<=600)
                bill=Units*1.8;
            else
                bill=Units*2.00;
            bill=0.15*bill;
        }
            
        else 
            Console.WriteLine("Enter value)");

        Console.WriteLine("The bill is "+bill);
        

            
    }
}
