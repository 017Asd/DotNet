using System;
using System.Collections.Generic;
namespace ResturantMenuManagement{
class Program
{
    static void Main(string[] args)
    {
        MenuManager manager = new MenuManager();

        while (true)
        {
            Console.WriteLine("\n--- Menu Management System ---");
            Console.WriteLine("1. Add Menu Item");
            Console.WriteLine("2. View Items Grouped By Category");
            Console.WriteLine("3. View Vegetarian Items");
            Console.WriteLine("4. Calculate Average Price By Category");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Item Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Category (Appetizer/Main Course/Dessert): ");
                    string category = Console.ReadLine();

                    Console.Write("Price: ");
                    double price = double.Parse(Console.ReadLine());

                    Console.Write("Is Vegetarian (true/false): ");
                    bool isVeg = bool.Parse(Console.ReadLine());

                    manager.AddMenuItem(name, category, price, isVeg);
                    Console.WriteLine("Item added successfully.");
                    break;

                case "2":
                    var grouped = manager.GroupItemsByCategory();
                    foreach (var cat in grouped)
                    {
                        Console.WriteLine($"\nCategory: {cat.Key}");
                        foreach (var item in cat.Value)
                        {
                            Console.WriteLine($"{item.ItemName} - ₹{item.Price}");
                        }
                    }
                    break;

                case "3":
                    var vegItems = manager.GetVegetarianItems();
                    Console.WriteLine("\nVegetarian Items:");
                    foreach (var item in vegItems)
                    {
                        Console.WriteLine($"{item.ItemName} ({item.Category}) - ₹{item.Price}");
                    }
                    break;

                case "4":
                    Console.Write("Enter category: ");
                    string avgCategory = Console.ReadLine();
                    double avgPrice = manager.CalculateAveragePriceByCategory(avgCategory);
                    Console.WriteLine($"Average price for {avgCategory}: ₹{avgPrice}");
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
}