using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
public class Program
{
    public static void Main()
    {
        Console.WriteLine(Sum(new List<int> {1,2,3}));
        //Console.WriteLine(Sum(new List<String> {"a","b"}));
        
    }
    public static T Sum<T>(IEnumerable<T> items) where T : struct
    {
       
        
        dynamic result=default(T);
        foreach(var item in items)
        {
            result+=item;   
        }
        return result;
        }
        
}