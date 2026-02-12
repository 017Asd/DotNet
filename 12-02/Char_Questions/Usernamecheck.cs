using System;

namespace Question
{
    public class UsernameCheck
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            if (input.Length < 8)
            {
                Console.WriteLine("Invalid username");
                return;
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsLetterOrDigit(input[i]))
                {
                    Console.WriteLine("Invalid username");
                    return;
                }
            }

            Console.WriteLine("Valid username");
        }
    }
}