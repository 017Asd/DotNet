using System;

class C5
{
    static void Main5()
    {
        // Ask the user to enter Mathematics marks
        Console.WriteLine("Math marks:");
        int math = int.Parse(Console.ReadLine());

        // Ask the user to enter Physics marks
        Console.WriteLine("Physics marks:");
        int physics = int.Parse(Console.ReadLine());

        // Ask the user to enter Chemistry marks
        Console.WriteLine("Chemistry marks:");
        int chemistry = int.Parse(Console.ReadLine());

        // Calculate total marks of all three subjects
        int total = math + physics + chemistry;

        // Check eligibility conditions:
        // 1. Math marks should be at least 65
        // 2. Physics marks should be at least 55
        // 3. Chemistry marks should be at least 50
        // 4. Total marks should be >= 180
        //    OR Math + Physics marks should be >= 140
        if (math >= 65 && chemistry >= 50 && physics >= 55 &&
            (total >= 180 || (math + physics >= 140)))
        {
            // If all conditions are satisfied, student is eligible
            Console.WriteLine("You are eligible for the admission!");
        }
        else
        {
            // If any condition fails, student is not eligible
            Console.WriteLine("You are not eligible!");
        }
    }
}