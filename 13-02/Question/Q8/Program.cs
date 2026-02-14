using System;
using System.Collections.Generic;
using Collection;

class ProgramQ8
{
    static void Main()
    {
        var serials = new List<string> { "S1","S2","S1","S3","S2","S2" };
        var duplicates = Q8.Execute(serials);
        Console.WriteLine(string.Join(", ", duplicates));
    }
}
