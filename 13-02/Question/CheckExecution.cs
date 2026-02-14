using System;
using System.Collections.Generic;
namespace Collection{

class Program1
{
    static void Main()
    {
        // Q1
        var cart = new List<(string, int)> { ("A101", 2), ("B205", 1), ("A101", 3), ("C111", -1) };
        var q1 = Q1.Execute(cart);
        Console.WriteLine("Q1 Cart Consolidation:");
        foreach (var kv in q1) Console.WriteLine($"{kv.Key}: {kv.Value}");

        // Q2
        var scans = new List<int> { 10, 20, 10, 30, 20, 40 };
        Console.WriteLine("\nQ2 First Unique Attendance: " + string.Join(", ", Q2.Execute(scans)));

        // Q3
        var players = new List<(string, int)> { ("Raj", 80), ("Anu", 95), ("Vikram", 95), ("Meena", 70) };
        var top3 = Q3.Execute(players, 3);
        Console.WriteLine("\nQ3 Leaderboard Top 3:");
        foreach (var p in top3) Console.WriteLine($"{p.name}: {p.score}");

        // Q4
        var q = new Queue<(TimeSpan,string)>();
        q.Enqueue((new TimeSpan(8,15,0),"Regular"));
        q.Enqueue((new TimeSpan(9,0,0),"Regular"));
        q.Enqueue((new TimeSpan(10,30,0),"Regular"));
        Console.WriteLine("\nQ4 Metro Peak Count: " + Q4.Execute(q));

        // Q5
        var ops = new List<string> { "TYPE Hello", "TYPE World", "UNDO", "TYPE CSharp" };
        Console.WriteLine("\nQ5 Text Editor Final Text: " + Q5.Execute(ops));

        // Q6
        var merged = Q6.Execute(new List<int>{1,4,7}, new List<int>{2,3,8});
        Console.WriteLine("\nQ6 Merged Tickets: " + string.Join(", ", merged));

        // Q7
        var txns = new List<(string, decimal)> { ("Food",-200), ("Fuel",-500), ("Food",-50), ("Salary",1000) };
        var spend = Q7.Execute(txns);
        Console.WriteLine("\nQ7 Bank Spend by Category:");
        foreach (var kv in spend) Console.WriteLine($"{kv.Key}: {kv.Value}");

        // Q8
        var serials = new List<string> { "S1","S2","S1","S3","S2","S2" };
        Console.WriteLine("\nQ8 Duplicate Serials: " + string.Join(", ", Q8.Execute(serials)));

        // Q9
        var seats = Q9.Execute(5, new List<int>{2,4}, 4);
        Console.WriteLine("\nQ9 Allocated Seats: " + string.Join(", ", seats));

        // Q10
        var logs = new List<string> { "E02","E01","E02","E01","E03" };
        Console.WriteLine("\nQ10 Most Frequent Error Code: " + Q10.Execute(logs));

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
}