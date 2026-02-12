using System;

namespace Question
{
    public class PassWord
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            if (input.Length >= 5)
            {
                int count = 0;

                for (int i = 0; i < input.Length; i++)
                {
                    if (char.IsLetter(input[i]))
                    {
                        count++;
                    }
                }

                if (count >= 5)
                {
                    Console.WriteLine("ValidPassword");
                }
                else
                {
                    Console.WriteLine("Insufficient characters");
                }
            }
            else
            {
                Console.WriteLine("Password too short");
            }
        }
    }
}