using System;
using System.Collections.Generic;

namespace Collection
{
    public class Q8
    {
        public static List<string> Execute(List<string> serials)
        {
            var seen = new HashSet<string>();
            var duplicates = new HashSet<string>();
            var result = new List<string>();
            foreach(var s in serials)
            {
                if(seen.Contains(s) && !duplicates.Contains(s))
                {
                    result.Add(s);
                    duplicates.Add(s);
                }
                seen.Add(s);
            }
            return result;
        }
    }
}
