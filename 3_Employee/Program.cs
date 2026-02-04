using System;

class BonusCalculator
{
    static void Main()
    {
        int[] salaries = { 5000, 0, 7000 };

        Console.WriteLine("Enter bonus:");
        int bonus = int.Parse(Console.ReadLine());

        foreach (var salary in salaries)
        {
            try
            {
                int result = bonus / salary;
                Console.WriteLine($"Bonus per salary {salary}: {result}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine($"Error: Salary is zero, cannot divide for this employee.");
            }
        }

        Console.WriteLine("DONE");
    }
}
