using System;
using System.Collections.Generic;
using System.Linq;

namespace Collection
{
    public class Q5
    {
        public static string Execute(List<string> ops)
        {
            var stack = new Stack<string>();
            foreach(var op in ops)
            {
                if(op.StartsWith("TYPE ")) stack.Push(op.Substring(5));
                else if(op=="UNDO" && stack.Count>0) stack.Pop();
            }
            return string.Join(" ",stack.Reverse());
        }
    }
}
