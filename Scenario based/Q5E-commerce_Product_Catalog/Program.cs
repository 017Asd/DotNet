using System;
namespace Ecommerce
{

    class Program
    {
        static void Main()
        {
            InventoryManager inventory = new InventoryManager();

            while (true)
            {
                Console.WriteLine("\n===== INVENTORY MANAGEMENT =====");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Display Products by Category");
                Console.WriteLine("3. Update Stock After Sale");
                Console.WriteLine("4. Find Products Below Price");
                Console.WriteLine("5. Category Stock Summary");
                Console.WriteLine("6. Exit");
                Console.Write("Enter choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Product Name: ");
                        string name = Console.ReadLine() ?? "";

                        Console.Write("Category: ");
                        string category = Console.ReadLine() ?? "";

                        Console.Write("Price: ");
                        if (!double.TryParse(Console.ReadLine(), out double price))
                        {
                            Console.WriteLine("Invalid price");
                            break;
                        }

                        Console.Write("Stock Quantity: ");
                        if (!int.TryParse(Console.ReadLine(), out int stock))
                        {
                            Console.WriteLine("Invalid stock");
                            break;
                        }

                        inventory.AddProduct(name, category, price, stock);
                        Console.WriteLine("Product added successfully");
                        break;

                    case 2:
                        var grouped = inventory.GroupProductsByCategory();

                        foreach (var g in grouped)
                        {
                            Console.WriteLine("\nCategory: " + g.Key);

                            foreach (var p in g.Value)
                            {
                                Console.WriteLine(
                                    p.ProductCode + " | " +
                                    p.ProductName + " | " +
                                    p.Price + " | Stock: " +
                                    p.StockQuantity);
                            }
                        }
                        break;

                    case 3:
                        Console.Write("Enter Product Code: ");
                        string code = Console.ReadLine() ?? "";

                        Console.Write("Quantity Sold: ");
                        if (!int.TryParse(Console.ReadLine(), out int qty))
                        {
                            Console.WriteLine("Invalid quantity");
                            break;
                        }

                        bool updated = inventory.UpdateStock(code, qty);
                        Console.WriteLine(updated ? "Stock updated" : "Insufficient stock or invalid code");
                        break;

                    case 4:
                        Console.Write("Enter max price: ");
                        if (!double.TryParse(Console.ReadLine(), out double maxPrice))
                        {
                            Console.WriteLine("Invalid price");
                            break;
                        }

                        var cheapProducts = inventory.GetProductsBelowPrice(maxPrice);

                        foreach (var p in cheapProducts)
                        {
                            Console.WriteLine(
                                p.ProductCode + " | " +
                                p.ProductName + " | " +
                                p.Price);
                        }
                        break;

                    case 5:
                        var summary = inventory.GetCategoryStockSummary();

                        foreach (var s in summary)
                        {
                            Console.WriteLine(s.Key + " → Total Stock: " + s.Value);
                        }
                        break;

                    case 6:
                        return;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}
