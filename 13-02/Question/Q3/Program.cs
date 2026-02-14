using System;
using System.Collections.Generic;
using Collection;

class ProgramQ3
{
    static void Main()
    {
        var players = new List<(string, int)> { ("Raj", 80), ("Anu", 95), ("Vikram", 95), ("Meena", 70) };
        var result = Q3.Execute(players, 3);
        foreach (var p in result)
            Console.WriteLine($"{p.name}: {p.score}");
    }
}
