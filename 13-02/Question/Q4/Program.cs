using System;
using System.Collections.Generic;
using Collection;

class ProgramQ4
{
    static void Main()
    {
        var q = new Queue<(TimeSpan,string)>();
        q.Enqueue((new TimeSpan(8,15,0),"Regular"));
        q.Enqueue((new TimeSpan(9,0,0),"Regular"));
        q.Enqueue((new TimeSpan(10,30,0),"Regular"));
        int count = Q4.Execute(q);
        Console.WriteLine(count);
    }
}
