using System;
using System.Collections.Generic;
using System.Linq;

namespace Collection
{
    public class Q3
    {
        public static List<(string name,int score)> Execute(List<(string name,int score)> players, int k)
        {
            return players.OrderByDescending(p=>p.score).ThenBy(p=>p.name).Take(k).ToList();
        }
    }
}
