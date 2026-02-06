using System;
namespace Q20{

class Program
{
    static void Main()
    {
        var manager = new RealEstateManager();

        manager.AddProperty("123 Main St", "Apartment", 2, 900, 120000, "John Doe");
        manager.AddProperty("456 Oak Ave", "House", 4, 2500, 350000, "Jane Smith");
        manager.AddProperty("789 Pine Rd", "Villa", 5, 4000, 750000, "Alice Johnson");

        manager.AddClient("Michael Brown", "michael@example.com", "Buyer", 200000, new List<string> { "2 Bedrooms", "City Center" });
        manager.AddClient("Laura White", "laura@example.com", "Buyer", 400000, new List<string> { "4 Bedrooms", "Suburbs" });

        var properties = manager.GroupPropertiesByType();
        Console.WriteLine("Properties grouped by type:");
        foreach (var group in properties)
        {
            Console.WriteLine(group.Key);
            foreach (var prop in group.Value)
            {
                Console.WriteLine($"{prop.PropertyId} {prop.Address} {prop.Bedrooms}BR ${prop.Price}");
            }
        }

        var budgetProperties = manager.GetPropertiesInBudget(100000, 400000);
        Console.WriteLine("\nProperties within budget $100,000 - $400,000:");
        foreach (var prop in budgetProperties)
        {
            Console.WriteLine($"{prop.PropertyId} {prop.Address} {prop.Bedrooms}BR ${prop.Price}");
        }

        var clientId = 1;
        var propertyId = properties["Apartment"][0].PropertyId;
        manager.ScheduleViewing(propertyId, clientId, DateTime.Now.AddDays(2));

        Console.WriteLine("\nScheduled viewings:");
        Console.WriteLine($"Client {clientId} viewing Property {propertyId} on {DateTime.Now.AddDays(2).ToShortDateString()}");

        Console.ReadKey();
    }
}
}