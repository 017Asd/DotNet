using System;
using System.Collections.Generic;
using Collection;

class ProgramQ5
{
    static void Main()
    {
        var ops = new List<string> { "TYPE Hello", "TYPE World", "UNDO", "TYPE CSharp" };
        string text = Q5.Execute(ops);
        Console.WriteLine(text);
    }
}
