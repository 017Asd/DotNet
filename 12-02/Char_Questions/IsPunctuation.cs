using System;
namespace Question
{
    public class ispun
    {
        public static void Main(string[] args)
        {
            string input=Console.ReadLine();
            string result="";
            int count=input.Length;
            foreach(char c in input)
            {
                if (!char.IsPunctuation(c))
                {
                    result+=c;
                    count-=1;

                }
            }
            Console.WriteLine("Without Punctuation: "+result);
            Console.WriteLine("Punctuation count: "+count);
        }
    }
}