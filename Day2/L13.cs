using System;

class MenuSystem
{
    static void Main()
    {
        // Display menu until user exits
        ShowMenu();
    }

    // Displays menu and processes user choice
    static void ShowMenu()
    {
        int choice;

        do
        {
            Console.WriteLine("\n1. Say Hello");
            Console.WriteLine("2. Show Date");
            Console.WriteLine("3. Exit");
            Console.Write("Enter choice: ");

            choice = int.Parse(Console.ReadLine()!);

            // Perform action based on user choice
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Hello User!");
                    break;
                case 2:
                    Console.WriteLine(DateTime.Now);
                    break;
                case 3:
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
        while (choice != 3); // Repeat until exit option selected
    }
}
