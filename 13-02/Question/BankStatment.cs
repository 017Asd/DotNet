using System;
using System.Collections.Generic;

namespace Collection
{
    public class Q7
    {
        public static Dictionary<string,decimal> Execute(List<(string category,decimal amount)> txns)
        {
            var dict = new Dictionary<string,decimal>();
            foreach(var (cat,amt) in txns)
            {
                if(amt>=0) continue;
                if(!dict.ContainsKey(cat)) dict[cat]=0;
                dict[cat]+=Math.Abs(amt);
            }
            return dict;
        }
    }
}
