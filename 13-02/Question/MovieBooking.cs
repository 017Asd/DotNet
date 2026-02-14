using System;
using System.Collections.Generic;
using System.Linq;

namespace Collection
{
    public class Q9
    {
        public static List<int> Execute(int n,List<int> booked,int requestCount)
        {
            var available = new SortedSet<int>(Enumerable.Range(1,n));
            foreach(var seat in booked) available.Remove(seat);
            var allocated = new List<int>();
            for(int i=0;i<requestCount;i++)
            {
                if(available.Count==0) allocated.Add(-1);
                else
                {
                    int seat=available.Min;
                    allocated.Add(seat);
                    available.Remove(seat);
                }
            }
            return allocated;
        }
    }
}
