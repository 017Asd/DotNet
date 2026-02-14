using System;
using System.Collections.Generic;
using Collection;

class ProgramQ2
{
    static void Main()
    {
        var scans = new List<int> { 10, 20, 10, 30, 20, 40 };
        var result = Q2.Execute(scans);
        Console.WriteLine(string.Join(", ", result));
    }
}
