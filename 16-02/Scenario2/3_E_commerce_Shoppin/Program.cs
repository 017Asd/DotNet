using System;

class Electronics : Product { }
class Clothing : Product { }

class Program
{
    static void Main()
    {
        ShoppingCart<Electronics> cart = new ShoppingCart<Electronics>();

        cart.AddToCart(new Electronics { Id = 1, Name = "Laptop", Price = 999.99 }, 1);
        cart.AddToCart(new Electronics { Id = 2, Name = "Mouse", Price = 29.99 }, 2);

        double total = cart.CalculateTotal((product, price) =>
            price > 100 ? price * 0.9 : price);

        Console.WriteLine($"Total: ${total:F2}");

        var topItems = cart.GetTopExpensiveItems(1);
        Console.WriteLine(topItems[0].Name);
    }
}
