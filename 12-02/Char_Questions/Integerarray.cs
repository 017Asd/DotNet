using System;
namespace Question
{
    public class Removedigitstoarray
    {
        public static void Main(string[] args)
        {
            string input=Console.ReadLine();
            int i=0;
            int len=0;
             foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    len++;
                }
            }
            int[] array = new int[len];
            foreach(char c in input)
            {
               
                if (char.IsDigit(c))
                {
                    
                    array[i]=c-'0';
                    i++;
                }
            }
            foreach(int num in array)
            {
                Console.WriteLine(num+" ");
            }
        }
    }
}