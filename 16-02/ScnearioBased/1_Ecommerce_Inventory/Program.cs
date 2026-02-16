using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            // Create repository
            var repository = new ProductRepository<ElectronicProduct>();

            // Create products
            var p1 = new ElectronicProduct
            {
                Id = 1,
                Name = "Gaming Laptop",
                Price = 1500,
                Brand = "ASUS",
                WarrantyMonths = 24
            };

            var p2 = new ElectronicProduct
            {
                Id = 2,
                Name = "Smartphone",
                Price = 800,
                Brand = "Samsung",
                WarrantyMonths = 12
            };

            var p3 = new ElectronicProduct
            {
                Id = 3,
                Name = "Headphones",
                Price = 200,
                Brand = "Sony",
                WarrantyMonths = 6
            };

            var p4 = new ElectronicProduct
            {
                Id = 4,
                Name = "4K TV",
                Price = 1800,
                Brand = "LG",
                WarrantyMonths = 36
            };

            var p5 = new ElectronicProduct
            {
                Id = 5,
                Name = "Monitor",
                Price = 400,
                Brand = "Dell",
                WarrantyMonths = 12
            };

            // Add products with validation
            repository.AddProduct(p1);
            repository.AddProduct(p2);
            repository.AddProduct(p3);
            repository.AddProduct(p4);
            repository.AddProduct(p5);

            Console.WriteLine("=== Total Inventory Value ===");
            Console.WriteLine(repository.CalculateTotalValue());

            // Find by brand
            Console.WriteLine("\n=== Products by Brand: Samsung ===");
            var samsungProducts = repository.FindProducts(p => p.Brand == "Samsung");
            foreach (var product in samsungProducts)
            {
                Console.WriteLine(product.Name);
            }

            // Inventory Manager processing
            var manager = new InventoryManager();

            Console.WriteLine("\n=== Processing Products ===");
            manager.ProcessProducts(repository.GetAll());

            // Apply bulk price update (Increase by 5%)
            Console.WriteLine("\n=== Applying 5% Price Increase ===");
            manager.UpdatePrices(
                repository.GetAll(),
                p => p.Price * 1.05m
            );

            Console.WriteLine("\n=== Updated Total Inventory Value ===");
            Console.WriteLine(repository.CalculateTotalValue());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
