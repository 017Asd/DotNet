using System;
namespace Question
{
    public class Q4
    {
        public static void Main(String[] args)
        {
            int len=int.Parse(Console.ReadLine());
            int[] arr=new int[len];
            for(int i = 0; i < len; i++)
            {
                arr[i]=int.Parse(Console.ReadLine());
            }
            Dictionary<int,int> freq=new Dictionary<int, int>();
            foreach(int num in arr)
            {
                if(freq.ContainsKey(num)) freq[num]++;
                else freq[num]=1;
            }
          
        }
    }
}