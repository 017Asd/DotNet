using System;
namespace Question
{
    public class IsSym
    {
        public static void Main(string[] args)
        {
            string productcode=Console.ReadLine();
            string result="";
            int count=0;
            foreach(char c in productcode)
            {
                if (char.IsSymbol(c))
                {
                    result+=c;
                    count+=1;
                }
            }
            if(count<1) Console.WriteLine("Not valid");
            else Console.WriteLine("Valid product code");
            Console.WriteLine("Symbols in input: "+result);
        }
    }
}