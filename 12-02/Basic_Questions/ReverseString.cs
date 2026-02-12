using System;
namespace Question
{
    public class Q1
    {
        public static void Main1(string[] args)
        {
            string input=Console.ReadLine();
            string reversed="";
                for (int i = input.Length - 1; i >= 0; i--)
            {
                reversed+=input[i];
            }
            Console.WriteLine(reversed);
        }
    }
}