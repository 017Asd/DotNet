using System;

public class Result
{
    private Employee[] employees;
    private int[] scores;
    private int winnerCount;

    public Result(Employee[] empList, int winners)
    {
        employees = empList;
        winnerCount = winners;
        scores = new int[employees.Length];
    }

    // Takes score for all employees
    public void TakeScores()
    {
        for (int i = 0; i < employees.Length; i++)
        {
            Console.Write(
                "Enter score for " + employees[i].Name +
                " (ID " + employees[i].EmployeeID + "): "
            );
            scores[i] = int.Parse(Console.ReadLine());
        }
    }

    // Calculates winners
    public void CalculateWinners()
    {
        for (int i = 0; i < scores.Length - 1; i++)
        {
            for (int j = i + 1; j < scores.Length; j++)
            {
                if (scores[j] > scores[i])
                {
                    int ts = scores[i];
                    scores[i] = scores[j];
                    scores[j] = ts;

                    Employee te = employees[i];
                    employees[i] = employees[j];
                    employees[j] = te;
                }
            }
        }
    }

    public void DisplayWinners()
    {
        Console.WriteLine("\n--- Winners ---");
        for (int i = 0; i < winnerCount; i++)
        {
            Console.WriteLine(
                "Rank " + (i + 1) + ": " +
                employees[i].Name +
                " | Score: " + scores[i]
            );
        }
    }
}
