using System;
namespace Question
{
    public class RemoveExceptLettersAndSpaces
    {
        public static void Main(string[] args)
        {
            string input=Console.ReadLine();
            string result="";
            foreach(char c in input)
            {
                if(char.IsLetter(c) || c==' ')
                {
                    result+=c;
                }
            }
            Console.WriteLine("Ouput: "+result);
        }
    }
}