using System;
namespace Question
{
    public class SpecialRemoval
    {
        public static void Main(string[] args)
        {
            string input=Console.ReadLine();
            string result="";
            foreach(char c in input)
            {
                if (char.IsAsciiLetterOrDigit(c))
                {
                    result+=c;
                }
            }
            Console.WriteLine("Output: "+result);
        }
    }
}