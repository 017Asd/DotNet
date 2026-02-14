using System;
using System.Collections.Generic;
using Collection;

class ProgramQ10
{
    static void Main()
    {
        var logs = new List<string> { "E02","E01","E02","E01","E03" };
        string result = Q10.Execute(logs);
        Console.WriteLine(result);
    }
}
