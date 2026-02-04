using System;

class PascalsTriangle
{
    static void Main()
    {
        // Read number of rows from user
        int rows = ReadValue("Enter number of rows: ");

        // Print Pascal's Triangle
        PrintPascalsTriangle(rows);
    }

    // Reads an integer value from the user
    static int ReadValue(string message)
    {
        Console.Write(message);
        return int.Parse(Console.ReadLine()!);
    }

    // Prints Pascal's Triangle up to given number of rows
    static void PrintPascalsTriangle(int rows)
    {
        // Loop through each row
        for (int i = 0; i < rows; i++)
        {
            int number = 1; // First value in each row is 1

            // Loop through columns in each row
            for (int j = 0; j <= i; j++)
            {
                Console.Write(number + " ");

                // Calculate next value using formula
                number = number * (i - j) / (j + 1);
            }

            // Move to next line after each row
            Console.WriteLine();
        }
    }
}
