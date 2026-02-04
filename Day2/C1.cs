using System;

class C1
{
    static void Main1()
    {
        // Declare variables to store coefficients of the quadratic equation
        // Quadratic equation format: ax^2 + bx + c = 0
        double a, b, c;

        // Take input value for coefficient 'a'
        Console.Write("Enter value of a: ");
        a = double.Parse(Console.ReadLine());

        // Take input value for coefficient 'b'
        Console.Write("Enter value of b: ");
        b = double.Parse(Console.ReadLine());

        // Take input value for coefficient 'c'
        Console.Write("Enter value of c: ");
        c = double.Parse(Console.ReadLine());

        // Calculate the discriminant using formula: d = b^2 - 4ac
        double d = (b * b) - (4 * a * c);

        // Check if discriminant is greater than zero
        // This means the equation has two real and different roots
        if (d > 0)
        {
            // Calculate both roots using quadratic formula
            double root1 = (-b + Math.Sqrt(d)) / (2 * a);
            double root2 = (-b - Math.Sqrt(d)) / (2 * a);

            // Display the roots
            Console.WriteLine("Roots are real and different");
            Console.WriteLine("Root 1 = " + root1);
            Console.WriteLine("Root 2 = " + root2);
        }
        // Check if discriminant is equal to zero
        // This means the equation has two real and equal roots
        else if (d == 0)
        {
            // Calculate the single repeated root
            double root = -b / (2 * a);

            // Display the root
            Console.WriteLine("Roots are real and equal");
            Console.WriteLine("Root = " + root);
        }
        // If discriminant is less than zero
        // This means the equation has no real roots (imaginary roots)
        else
        {
            Console.WriteLine("Roots are imaginary (no real roots)");
        }
    }
}
