using System;

namespace Question
{
    public class Charfunction
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            
            foreach (char c in input)
            {
                if (char.IsControl(c))
                    Console.WriteLine($"Control character found: {(int)c}");
            }

     
            foreach (char c in input)
            {
                if (char.IsNumber(c))
                    Console.WriteLine($"Numeric character: {c}");
            }

            
            foreach (char c in input)
            {
                if (char.IsSeparator(c))
                    Console.WriteLine($"Separator character detected.");
            }

            
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];

                if (char.IsSurrogate(c))
                    Console.WriteLine($"Surrogate detected at index {i}");

                if (char.IsHighSurrogate(c))
                    Console.WriteLine($"High surrogate at index {i}");

                if (char.IsLowSurrogate(c))
                    Console.WriteLine($"Low surrogate at index {i}");
            }

            
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (char.IsHighSurrogate(input[i]))
                {
                    if (char.IsLowSurrogate(input[i + 1]))
                        Console.WriteLine($"Valid surrogate pair at index {i}");
                    else
                        Console.WriteLine($"Broken surrogate pair at index {i}");
                }
            }

            
            string cleaned = "";
            foreach (char c in input)
            {
                if (!char.IsControl(c))
                    cleaned += c;
            }
            Console.WriteLine("Cleaned string: " + cleaned);
        }
    }
}