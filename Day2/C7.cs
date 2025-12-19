using System;

class C7
{
    static void Main9()
    {
        Console.Write("Enter a character: ");
        char ch = char.ToLower(Console.ReadKey().KeyChar);
        Console.WriteLine();

        switch (ch)
        {
            case 'a':
            case 'e':
            case 'i':
            case 'o':
            case 'u':
                Console.WriteLine("It is a Vowel");
                break;

            default:
                Console.WriteLine("It is a Consonant");
                break;
        }
    }
}
