using System;
using System.Collections.Generic;
using Collection;

class ProgramQ6
{
    static void Main()
    {
        var merged = Q6.Execute(new List<int>{1,4,7}, new List<int>{2,3,8});
        Console.WriteLine(string.Join(", ", merged));
    }
}
