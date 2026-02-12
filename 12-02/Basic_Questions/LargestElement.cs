using System;
namespace Question
{
    public class Q2
    {
        public static void Main2(string[] args)
        {
            Console.WriteLine("Input the length of array: ");
            int len=int.Parse(Console.ReadLine());
            int[] input=new int[len];
            Console.WriteLine("Input the elements");
            for(int i = 0; i < len; i++)
            {
                input[i]=int.Parse(Console.ReadLine());
            }
            int largest=input[0];
            for(int i = 1; i < len; i++)
            {
                if (input[i] > largest)
                {
                    largest=input[i];
                }
            }
            Console.WriteLine($"Largest element: {largest}");
        }
    }
}