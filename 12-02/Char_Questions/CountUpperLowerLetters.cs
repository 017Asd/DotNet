using System;
namespace Question
{
    public class CountUpperLetters
    {
        public static void Main(String[] args)
        {
            string input=Console.ReadLine();
            int Ucount=0;
            int Lcount=0;
            foreach(char c in input)
            {
                if (char.IsUpper(c))
                {
                    Ucount+=1;
                }
                if (char.IsLower(c))
                {
                    Lcount+=1;
                }
            }


    
            Console.WriteLine("Number of upper letters: "+Ucount);
            Console.WriteLine("Number of lower letters: "+Lcount);

            //detect if more than 60% characters are uppercase we would be using Ucount
            double percent=Ucount/input.Length;
            if (percent > 0.6)
            {
                Console.WriteLine("Yes more than 60% are uppercase");
            }
            else
            {
                Console.WriteLine("No less than 60% are uppercase");
            }
        }
    }
}