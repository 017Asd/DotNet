using System;

public class Program
{
    public static void Main(string[] args)
    {
        ShipmentDetails shipment = new ShipmentDetails();

        Console.WriteLine("Enter Shipment Code:");
        shipment.ShipmentCode = Console.ReadLine();

        if (!shipment.ValidateShipmentCode())
        {
            Console.WriteLine("Invalid shipment code");
            return;
        }

        Console.WriteLine("Enter Transport Mode:");
        shipment.TransportMode = Console.ReadLine();

        Console.WriteLine("Enter Weight:");
        shipment.Weight = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter Storage Days:");
        shipment.StorageDays = int.Parse(Console.ReadLine());

        double cost = shipment.CalculateTotalCost();
        Console.WriteLine("The total shipping cost is " + cost.ToString("F2"));
    }
}
