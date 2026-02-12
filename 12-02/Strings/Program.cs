using System;
class Program

{
    //check whether @ is there or not more than one @ not valid
    //split by @ w get two parts any dot and symnol in front part is invalid in second part it is true
    public static void Main(string[] args)
    {
        string ch = "  ";
        while (ch == "" )
        {
            Console.WriteLine("Input email: ");
            string? email=Console.ReadLine();

            if (!email.Contains("@") || email.Split('@').Length>1)
            {
                Console.WriteLine("It is invalid");
            }
            if (email.Split('@').Length==1){
            string[] parts=email.Split("@");
            foreach (char a in parts[0])
            {
                if (!char.IsLetterOrDigit(a))
                {
                    Console.WriteLine("Invalid");
          
                }
            }
            string[] secondparts = parts[1].Split(".");
            string s1=secondparts[0];
            string s2=secondparts[1];
            if (parts[0].Contains(s1) || s1==s2 ||!parts[1].Contains(".") )
            {
                Console.WriteLine("Invalid");
            }
            }

            Console.WriteLine("Input email: ");
            email=Console.ReadLine();
        }
    }
}