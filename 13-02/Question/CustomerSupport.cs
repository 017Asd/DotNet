using System;
using System.Collections.Generic;

namespace Collection
{
    public class Q6
    {
        public static List<int> Execute(List<int> a, List<int> b)
        {
            var result = new List<int>();
            int i=0,j=0;
            while(i<a.Count && j<b.Count)
            {
                if(a[i]<=b[j]) result.Add(a[i++]);
                else result.Add(b[j++]);
            }
            while(i<a.Count) result.Add(a[i++]);
            while(j<b.Count) result.Add(b[j++]);
            return result;
        }
    }
}
