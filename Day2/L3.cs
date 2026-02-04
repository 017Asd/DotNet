using System;

class L3
{
    static void Main7()
    {
        int number = ReadNumber();
        int digitCount = CountDigits(number);
        int armstrongSum = CalculateArmstrongSum(number, digitCount);

        DisplayResult(number, armstrongSum);
    }

    // Reads the number from the user
    static int ReadNumber()
    {
        Console.Write("Enter a number: ");
        return int.Parse(Console.ReadLine());
    }

    // Recursively counts the number of digits
    static int CountDigits(int number)
    {
        if (number == 0)
            return 0;

        return 1 + CountDigits(number / 10);
    }

    // Recursively calculates the Armstrong sum
    static int CalculateArmstrongSum(int number, int digits)
    {
        if (number == 0)
            return 0;

        int digit = number % 10;
        return Power(digit, digits) + CalculateArmstrongSum(number / 10, digits);
    }

    // Recursive power function
    static int Power(int baseValue, int exponent)
    {
        if (exponent == 0)
            return 1;

        return baseValue * Power(baseValue, exponent - 1);
    }

    // Displays the final result
    static void DisplayResult(int number, int armstrongSum)
    {
        if (number == armstrongSum)
            Console.WriteLine($"{number} is an Armstrong number");
        else
            Console.WriteLine($"{number} is NOT an Armstrong number");
    }
}
