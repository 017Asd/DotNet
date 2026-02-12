using System;
namespace Question
{
    public class CountNumeric
    {
        public static void Main(String[] args)
        {
            string input=Console.ReadLine();
            int count=0;
            foreach(char a in input)
            {
                if (char.IsDigit(a))
                {
                    count+=1;
                }
            }
            Console.WriteLine(count);
        }
    }
}