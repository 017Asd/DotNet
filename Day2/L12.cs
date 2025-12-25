using System;

class ContinueExample
{
    static void Main()
    {
        // Print numbers from 1 to 50 skipping multiples of 3
        PrintNumbers();
    }

    // Prints numbers using continue statement
    static void PrintNumbers()
    {
        for (int i = 1; i <= 50; i++)
        {
            // Skip multiples of 3
            if (i % 3 == 0)
                continue;

            Console.Write(i + " ");
        }
    }
}
