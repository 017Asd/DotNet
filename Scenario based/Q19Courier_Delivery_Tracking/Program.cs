using System;

namespace Q19{

class Program
{
    static void Main()
    {
        var manager = new CourierManager();

        manager.AddPackage("Alice", "Bob", "New York, NY", 2.5, "Parcel", 15.0);
        manager.AddPackage("Charlie", "David", "Los Angeles, CA", 1.2, "Document", 10.0);
        manager.AddPackage("Eve", "Frank", "New York, NY", 5.0, "Fragile", 25.0);

        var packages = manager.GroupPackagesByType();
        Console.WriteLine("Packages grouped by type:");
        foreach (var group in packages)
        {
            Console.WriteLine(group.Key);
            foreach (var p in group.Value)
            {
                Console.WriteLine($"{p.TrackingNumber} {p.SenderName} -> {p.ReceiverName}");
            }
        }

        var nyPackages = manager.GetPackagesByDestination("New York");
        Console.WriteLine("\nPackages destined to New York:");
        foreach (var p in nyPackages)
        {
            Console.WriteLine($"{p.TrackingNumber} {p.SenderName} -> {p.ReceiverName}");
        }

        var firstTracking = nyPackages[0].TrackingNumber;
        manager.UpdateStatus(firstTracking, "InTransit", "Left warehouse");
        manager.UpdateStatus(firstTracking, "Delivered", "Delivered to receiver");

        var delayed = manager.GetDelayedPackages();
        Console.WriteLine("\nDelayed packages:");
        foreach (var p in delayed)
        {
            Console.WriteLine($"{p.TrackingNumber} {p.SenderName} -> {p.ReceiverName}");
        }

        Console.ReadKey();
    }
}
}