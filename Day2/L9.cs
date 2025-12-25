using System;
using System.Numerics;

class LargeFactorial
{
    static void Main()
    {
        // Read input number
        int n = ReadValue("Enter number: ");

        // Calculate factorial safely for large numbers
        BigInteger result = CalculateFactorial(n);

        // Display factorial result
        Console.WriteLine("Factorial: " + result);
    }

    // Reads integer input
    static int ReadValue(string message)
    {
        Console.Write(message);
        return int.Parse(Console.ReadLine()!);
    }

    // Calculates factorial using BigInteger to avoid overflow
    static BigInteger CalculateFactorial(int n)
    {
        BigInteger fact = 1;

        // Multiply numbers from 1 to n
        for (int i = 1; i <= n; i++)
            fact *= i;

        return fact;
    }
}
