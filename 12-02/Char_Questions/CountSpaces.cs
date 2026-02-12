using System;
using System.IO.Pipelines;
namespace Question
{
    public class CountSpaces
    {
        public static void Main(string[] args)
        {
            string input=Console.ReadLine();
            int Scount=0;
            string result="";

            for(int i = 0; i < input.Length; i++)
            {
                if (char.IsWhiteSpace(input[i]))
                {
                    Scount++;
                    //if previous letter is not whitespace then only add
                    if(i==0 || !char.IsWhiteSpace(input[i - 1]))
                    {
                        result+=" ";
                    }
                }
                else
                    {
                        result+=input[i];
                    }            
            }
            Console.WriteLine("Number of spaces,tabs,newlines: "+Scount);
            Console.WriteLine(result);


        }
    }
}