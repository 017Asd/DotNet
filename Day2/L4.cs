using System;

class L4
{
    static void Main8()
    {
        // Read the number from the user
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        int originalNumber = number; // Store original value
        int reverse = 0;

        // Reverse the number using while loop
        while (number > 0)
        {
            int digit = number % 10;      // Get last digit
            reverse = reverse * 10 + digit; // Build reversed number
            number = number / 10;         // Remove last digit
        }

        // Display reversed number
        Console.WriteLine("Reversed number: " + reverse);

        // Check if palindrome
        if (originalNumber == reverse)
            Console.WriteLine("The number is a Palindrome");
        else
            Console.WriteLine("The number is NOT a Palindrome");
    }
}
