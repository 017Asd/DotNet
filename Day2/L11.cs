using System;

class DigitalRoot
{
    static void Main()
    {
        // Read input number
        int number = ReadValue("Enter number: ");

        // Calculate digital root
        int result = CalculateDigitalRoot(number);

        // Display result
        Console.WriteLine("Single Digit Sum: " + result);
    }

    // Reads integer input
    static int ReadValue(string message)
    {
        Console.Write(message);
        return int.Parse(Console.ReadLine()!);
    }

    // Repeatedly sums digits until single digit remains
    static int CalculateDigitalRoot(int number)
    {
        while (number >= 10)
            number = SumDigits(number);

        return number;
    }

    // Sums digits of a number
    static int SumDigits(int number)
    {
        int sum = 0;

        while (number > 0)
        {
            sum += number % 10;
            number /= 10;
        }

        return sum;
    }
}
