using System;
using System.Collections.Generic;

namespace Collection
{
    public class Q2
    {
        public static List<int> Execute(List<int> scans)
        {
            var seen = new HashSet<int>();
            var result = new List<int>();
            foreach (var id in scans)
            {
                if (!seen.Contains(id))
                {
                    result.Add(id);
                    seen.Add(id);
                }
            }
            return result;
        }
    }
}
