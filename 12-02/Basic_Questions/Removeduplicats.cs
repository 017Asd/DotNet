using System;
using System.Diagnostics;
namespace Question
{
    public class Q3
    {
        public static void Main4(String[] args)
        {
            int len=int.Parse(Console.ReadLine());
            HashSet<int> input=new HashSet<int>();
            for (int i = 0; i < len; i++)
            {
                int values=int.Parse(Console.ReadLine());
                input.Add(values);
            }
            Console.WriteLine("Output elements: ");
            foreach(int number in input)
            {
                Console.WriteLine(number);
            }
        }
    }
}