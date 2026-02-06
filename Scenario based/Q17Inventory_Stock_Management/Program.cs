using System;
namespace Q17   
{
class Program
{
    static void Main()
    {
        var manager = new InventoryManager();

        manager.AddProduct(
            "P001",
            "Laptop",
            "Electronics",
            "TechSupplier",
            800,
            20,
            5
        );

        manager.AddProduct(
            "P002",
            "Office Chair",
            "Furniture",
            "FurniCo",
            150,
            10,
            3
        );

        manager.AddProduct(
            "P003",
            "Mouse",
            "Electronics",
            "TechSupplier",
            20,
            50,
            10
        );

        manager.UpdateStock("P001", "Out", 5, "Sale");
        manager.UpdateStock("P002", "Out", 8, "Sale");
        manager.UpdateStock("P003", "In", 20, "Purchase");

        var groupedProducts = manager.GroupProductsByCategory();

        foreach (var category in groupedProducts)
        {
            Console.WriteLine(category.Key);
            foreach (var product in category.Value)
            {
                Console.WriteLine($"{product.ProductCode} {product.ProductName} {product.CurrentStock}");
            }
        }

        var lowStockProducts = manager.GetLowStockProducts();

        Console.WriteLine("Low Stock Products:");
        foreach (var product in lowStockProducts)
        {
            Console.WriteLine($"{product.ProductCode} {product.ProductName} {product.CurrentStock}");
        }

        var stockValueByCategory = manager.GetStockValueByCategory();

        Console.WriteLine("Stock Value By Category:");
        foreach (var item in stockValueByCategory)
        {
            Console.WriteLine($"{item.Key} {item.Value}");
        }

        Console.ReadKey();
    }
}

}