using System;

class StrongNumber
{
    static void Main()
    {
        // Read input number
        int number = ReadValue("Enter number: ");

        // Check if strong number
        CheckStrongNumber(number);
    }

    // Reads integer input
    static int ReadValue(string message)
    {
        Console.Write(message);
        return int.Parse(Console.ReadLine()!);
    }

    // Checks whether number is strong or not
    static void CheckStrongNumber(int number)
    {
        int sum = 0;
        int temp = number;

        // Extract digits and add factorial of each digit
        while (temp > 0)
        {
            int digit = temp % 10;
            sum += Factorial(digit);
            temp /= 10;
        }

        // Compare sum with original number
        if (sum == number)
            Console.WriteLine("Strong Number");
        else
            Console.WriteLine("Not a Strong Number");
    }

    // Calculates factorial of a digit
    static int Factorial(int n)
    {
        int fact = 1;

        for (int i = 1; i <= n; i++)
            fact *= i;

        return fact;
    }
}
