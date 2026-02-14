using System;
using System.Collections.Generic;
using Collection;

class ProgramQ1
{
    static void Main()
    {
        var cart = new List<(string, int)> { ("A101", 2), ("B205", 1), ("A101", 3), ("C111", -1) };
        var result = Q1.Execute(cart);
        foreach (var kv in result)
            Console.WriteLine($"{kv.Key}: {kv.Value}");
    }
}
