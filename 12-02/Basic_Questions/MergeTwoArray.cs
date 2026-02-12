using System;
using System.IO.Pipelines;
namespace Question
{
    public class Q7
    {
        public static void Main(string[] args)
        {
            int[] arr1=[1,4,6,8,10];
            int[] arr2=[2,3,5,7];
            int[] result = new int[arr1.Length+arr2.Length];
            int i=0;
            int j=0;
            int k=0;
            while (i<arr1.Length && j < arr2.Length)
            {
                if(arr1[i]<arr2[j])
                result[k++]=arr1[i++];
                result[k++]=arr2[j++];
            }
            while (i < arr1.Length)
            {
                result[k++]=arr1[i++];
            }
            while (j < arr2.Length)
            {
                result[k++]=arr2[j++];
            }
            foreach(int num in result)
            {
                Console.Write(num+" ");
            }

        }
    }
}