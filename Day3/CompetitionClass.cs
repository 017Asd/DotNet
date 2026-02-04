using System;

public class Competition
{
    public int CompetitionID;
    public string Description;
    public int WinnerCount;

    private Result result;

    public Competition(int id, string desc, int winners, Employee[] employees)
    {
        CompetitionID = id;
        Description = desc;
        WinnerCount = winners;

        // Competition OWNS the result
        result = new Result(employees, winners);
    }

    // Runs the competition
    public void ConductCompetition()
    {
        Console.WriteLine("\n=== " + Description + " ===");
        result.TakeScores();
        result.CalculateWinners();
        result.DisplayWinners();
    }
}
//as a school management collect informtion high school ug aand pg students 