using System;
using System.Collections.Generic;
using Collection;

class ProgramQ9
{
    static void Main()
    {
        var seats = Q9.Execute(5, new List<int>{2,4}, 4);
        Console.WriteLine(string.Join(", ", seats));
    }
}
