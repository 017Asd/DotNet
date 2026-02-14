using System;
using System.Collections.Generic;

namespace Collection
{
    public class Q4
    {
        public static int Execute(Queue<(TimeSpan entryTime,string ticketType)> q)
        {
            TimeSpan start = new TimeSpan(8,0,0);
            TimeSpan end = new TimeSpan(10,0,0);
            int count=0;
            while(q.Count>0)
            {
                var (time,type)=q.Dequeue();
                if(type=="Regular" && time>=start && time<=end) count++;
            }
            return count;
        }
    }
}
