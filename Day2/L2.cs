using System;
class P2
{ 
    static void Main7()
    {
        int check=Input();
        CheckPrime(check);
    }
    static int Input()
    {
        Console.WriteLine("Enter the number: ");
        return int.Parse(Console.ReadLine());
    }

    

    static void CheckPrime(int number)
    {
        

        if (IsPrime(number))
            Console.WriteLine($"{number} is a Prime number");
        else
            Console.WriteLine($"{number} is NOT a Prime number");
    }

    static bool IsPrime(int n)
    {
        if (n <= 1) return false;
        if (n == 2) return true;
        if (n % 2 == 0) return false;

        for (int i = 3; i * i <= n; i += 2)
            if (n % i == 0)
                return false;

        return true;
    }
}