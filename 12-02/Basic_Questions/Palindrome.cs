using System;
namespace Question
{
    public class Q5
    {
        public static void Main5(String[] args)
        {
            Console.WriteLine("Give input string: ");
            string input=Console.ReadLine();
            int len=input.Length;
            int mid=(input.Length)/2;
            string one_part="";
            string two_part="";
            for(int i = 0; i < mid; i++)
            {
                one_part+=input[i];
            }
            for(int i = len-1; i >= mid; i--)
            {
                two_part+=input[i];
            }
            if (one_part == two_part)
            {
                Console.WriteLine("Is Palindrome");
            }
            else
            {
                Console.WriteLine("Is not Palindrome");
            }
        }
    }
}