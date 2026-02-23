using BusinessLayer;

class Program
{
    static void Main()
    {
        NameService service = new NameService();
        List<string> inputNames = new List<string>();

        Console.WriteLine("Enter names (type 'end' to finish):");

        while (true)
        {
            string name = Console.ReadLine();

            if (name.ToLower() == "end")
                break;

            inputNames.Add(name);
        }

        var reversedNames = service.GetReversedNames(inputNames);

        Console.WriteLine("\nReversed Names:");
        foreach (var name in reversedNames)
        {
            Console.WriteLine(name);
        }
    }
}