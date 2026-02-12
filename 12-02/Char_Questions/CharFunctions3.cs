using System;
namespace Question
{
    public class CharF2
    {
        public static void Main(string[] args){
        string input1=Console.ReadLine();
        string input2=Console.ReadLine();
       
        Console.WriteLine( input1.Equals(input2));
        Console.WriteLine(input1.CompareTo(input2));
        foreach(char c in input1)
            {
                Console.Write(c.ToString()+",");
            }
        Console.WriteLine("MinValue"+(int)char.MinValue);
        Console.WriteLine("MaxValue"+(int)char.MaxValue);
        for (int i = 0; i < input1.Length - 1; i++)
            {
                if (input1[i] == input1[i + 1])
                    Console.WriteLine("Duplicate char: " + input1[i]);
            }
        if (input1.CompareTo(input2) < 0)
                Console.WriteLine("input1 comes before input2");
        else if (input1.CompareTo(input2) > 0)
                Console.WriteLine("input1 comes after input2");
        else
                Console.WriteLine("Strings are equal");
        }
    }
}
