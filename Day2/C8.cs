using System;

class TriangleTypeChecker
{
    static void Main()
    {
        // Read side lengths of the triangle
        int sideA = ReadSideLength("Enter side A: ");
        int sideB = ReadSideLength("Enter side B: ");
        int sideC = ReadSideLength("Enter side C: ");

        // Check whether the given sides can form a valid triangle
        if (!IsValidTriangle(sideA, sideB, sideC))
        {
            Console.WriteLine("The given sides do NOT form a valid triangle.");
            return;
        }

        // Determine and display the triangle type
        string triangleType = GetTriangleType(sideA, sideB, sideC);
        DisplayTriangleType(triangleType);
    }

    // Reads a side length from the user
    static int ReadSideLength(string message)
    {
        Console.Write(message);
        return int.Parse(Console.ReadLine());
    }

    // Checks if the sides satisfy the triangle inequality theorem
    static bool IsValidTriangle(int a, int b, int c)
    {
        return (a + b > c) && (a + c > b) && (b + c > a);
    }

    // Determines the type of the triangle
    static string GetTriangleType(int a, int b, int c)
    {
        // All sides equal → Equilateral triangle
        if (a == b && b == c)
            return "Equilateral Triangle";

        // Any two sides equal → Isosceles triangle
        if (a == b || b == c || a == c)
            return "Isosceles Triangle";

        // All sides different → Scalene triangle
        return "Scalene Triangle";
    }

    // Displays the triangle type
    static void DisplayTriangleType(string triangleType)
    {
        Console.WriteLine("Triangle Type: " + triangleType);
    }
}
