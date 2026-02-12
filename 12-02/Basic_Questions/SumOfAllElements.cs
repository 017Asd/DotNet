using System;
namespace Question
{
    public class Q6
    {
        public static void Main (String[] args)
        {
            int len=int.Parse(Console.ReadLine());
            int[] arr=new int[len];
            for (int i = 0; i < len; i++)
            {
                arr[i]=int.Parse(Console.ReadLine());
            }
            int sum=0;
            foreach(int number in arr)
            {
                sum+=number;
            }
            Console.WriteLine($"Sum of elements: {sum}");
        }
    }
}