using System;

class GotoSearch
{
    static void Main()
    {
        // Declare 2D array
        int[,] matrix =
        {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9}
        };

        int target = 5;

        // Search for target element
        Search(matrix, target);
    }

    // Searches element using nested loops and goto
    static void Search(int[,] matrix, int target)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        // Nested loops to traverse matrix
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                // If element found, exit all loops using goto
                if (matrix[i, j] == target)
                {
                    Console.WriteLine("Found at (" + i + ", " + j + ")");
                    goto Found;
                }
            }
        }

        Console.WriteLine("Not Found");

    Found:
        Console.WriteLine("Search completed");
    }
}
