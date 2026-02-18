using System;
using System.Collections.Generic;

namespace Q3
{
    public class Program
    {
        public static void Main()
        {
            List<Product> products = new List<Product>
            {
                new Product(1, "Laptop", 80000, 10),
                new Product(2, "Phone", 40000, 20),
                new Product(3, "Headphones", 3000, 50)
            };

            Dictionary<int, Product> productDictionary = new Dictionary<int, Product>();

            foreach (var product in products)
            {
                productDictionary.Add(product.Id, product);
            }

            List<Customer> customers = new List<Customer>
            {
                new Customer(1, "Rahul", false),
                new Customer(2, "Aman", true)
            };

            List<Order> orders = new List<Order>();

            try
            {
                Order order1 = new Order(1001, customers[0]);

                order1.AddItem(productDictionary[1], 2);
                order1.AddItem(productDictionary[2], 1);

                Console.WriteLine("Order Total: " + order1.CalculateTotal());

                order1.ShipOrder();

                orders.Add(order1);

                order1.CancelOrder();  // This will throw exception
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.WriteLine("\nRemaining Stock:");
            foreach (var p in products)
            {
                Console.WriteLine($"{p.Name} - {p.Stock}");
            }
        }
    }
}
