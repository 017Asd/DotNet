using System;

class DiamondPattern
{
    static void Main()
    {
        // Read number of rows
        int n = ReadValue("Enter number of rows: ");

        // Print diamond pattern
        PrintDiamond(n);
    }

    // Reads an integer value
    static int ReadValue(string message)
    {
        Console.Write(message);
        return int.Parse(Console.ReadLine()!);
    }

    // Prints full diamond pattern
    static void PrintDiamond(int n)
    {
        // Print upper half of diamond
        for (int i = 1; i <= n; i++)
            PrintRow(n, i);

        // Print lower half of diamond
        for (int i = n - 1; i >= 1; i--)
            PrintRow(n, i);
    }

    // Prints a single row of the diamond
    static void PrintRow(int n, int i)
    {
        // Print leading spaces
        Console.Write(new string(' ', n - i));

        // Print stars
        Console.WriteLine(new string('*', 2 * i - 1));
    }
}
