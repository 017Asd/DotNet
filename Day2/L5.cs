using System;

class L5
{
    static void Main8()
    {
        int num1 = ReadNumber("Enter first number: ");
        int num2 = ReadNumber("Enter second number: ");

        int gcd = CalculateGCD(num1, num2);
        int lcm = CalculateLCM(num1, num2, gcd);

        DisplayResult(num1, num2, gcd, lcm);
    }

    // Function to read a number from the user
    static int ReadNumber(string message)
    {
        Console.Write(message);
        return int.Parse(Console.ReadLine());
    }

    // Function to calculate GCD using Euclidean Algorithm
    static int CalculateGCD(int a, int b)
    {
        while (b != 0)
        {
            int remainder = a % b;
            a = b;
            b = remainder;
        }
        return a;
    }

    // Function to calculate LCM using GCD
    static int CalculateLCM(int a, int b, int gcd)
    {
        return (a * b) / gcd;
    }

    // Function to display results
    static void DisplayResult(int a, int b, int gcd, int lcm)
    {
        Console.WriteLine("GCD of " + a + " and " + b + " is: " + gcd);
        Console.WriteLine("LCM of " + a + " and " + b + " is: " + lcm);
    }
}
