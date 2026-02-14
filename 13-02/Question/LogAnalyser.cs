using System;
using System.Collections.Generic;
using System.Linq;

namespace Collection
{
    public class Q10
    {
        public static string Execute(List<string> codes)
        {
            var freq = new Dictionary<string,int>();
            foreach(var code in codes) freq[code]=freq.GetValueOrDefault(code,0)+1;
            int max=freq.Values.Max();
            return freq.Where(kv=>kv.Value==max).Select(kv=>kv.Key).OrderBy(x=>x).First();
        }
    }
}
