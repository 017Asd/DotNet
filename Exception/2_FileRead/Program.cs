using System;
using System.IO;
class FileReader
{
    static void Main()
    {
        string filePath = "data.txt";
        try
        {
            using StreamReader reader = new StreamReader(filePath);
            Console.WriteLine(reader.ReadToEnd());
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Access denied");
        }
    }
}