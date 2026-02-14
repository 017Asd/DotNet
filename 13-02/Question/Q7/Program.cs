using System;
using System.Collections.Generic;
using Collection;

class ProgramQ7
{
    static void Main()
    {
        var txns = new List<(string, decimal)> { ("Food",-200), ("Fuel",-500), ("Food",-50), ("Salary",1000) };
        var spend = Q7.Execute(txns);
        foreach (var kv in spend)
            Console.WriteLine($"{kv.Key}: {kv.Value}");
    }
}
