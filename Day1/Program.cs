/*
PROGRAM 1: PRIME NUMBER CHECK
- Takes a number as input
- Checks whether it is prime using an optimized approach
- Uses a separate IsPrime() method
*/

using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1. Check Prime Number");
        Console.WriteLine("2. Check Adult (Age >= 18)");
        Console.WriteLine("3. Convert Feet to Centimeters");
        Console.WriteLine("4. Count Prime Numbers up to N");

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                CheckPrime();
                break;

            case 2:
                CheckAdult();
                break;

            case 3:
                FeetToCentimeter();
                break;

            case 4:
                CountPrimes();
                break;

            default:
                Console.WriteLine("Invalid choice");
                break;
        }
    }

    /*
    PROGRAM 1 LOGIC EXECUTION
    */
    static void CheckPrime()
    {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());

        if (IsPrime(n))
            Console.WriteLine($"{n} is a Prime number");
        else
            Console.WriteLine($"{n} is NOT a Prime number");
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

    /*
    PROGRAM 2: ADULT CHECK
    - Reads age from user
    - Validates input using TryParse
    - Checks if age is >= 18
    */
    static void CheckAdult()
    {
        Console.Write("Enter age: ");
        string? input = Console.ReadLine();

        if (int.TryParse(input, out int age))
        {
            bool isAdult = age >= 18;
            Console.WriteLine("Adult: " + isAdult);
        }
        else
        {
            Console.WriteLine("Invalid age");
        }
    }

    /*
    PROGRAM 3: FEET TO CENTIMETER CONVERSION
    - Reads length in feet
    - Converts it into centimeters
    - Uses double for decimal precision
    */
    static void FeetToCentimeter()
    {
        Console.Write("Enter length in feet: ");
        string? input = Console.ReadLine();

        if (double.TryParse(input, out double feet))
        {
            double cm = feet * 30.48;
            Console.WriteLine("Length in cm: " + cm);
        }
        else
        {
            Console.WriteLine("Invalid input");
        }
    }

    /*
    PROGRAM 4: COUNT PRIME NUMBERS UP TO N
    - Takes upper limit N
    - Counts how many prime numbers exist from 1 to N
    - Uses optimized prime checking
    */
    static void CountPrimes()
    {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());
        int count = 0;

        if (n >= 2)
            count++;

        for (int i = 3; i <= n; i += 2)
        {
            bool isPrime = true;

            for (int j = 3; j * j <= i; j += 2)
            {
                if (i % j == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime)
                count++;
        }

        Console.WriteLine("Number of prime numbers = " + count);
    }
}
