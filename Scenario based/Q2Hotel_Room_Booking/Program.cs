using HotelRoomBooking;
using System;
public class Program
{
    static void Main(string[] args)
    {
        var manager = new HotelManager();
        
        manager.AddRoom(101, "Single", 2000);
        manager.AddRoom(102, "Double", 3500);
        manager.AddRoom(201, "Suite", 6000);
        manager.AddRoom(202, "Single", 2200);
        
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Hotel Menu:");
            Console.WriteLine("1. View Available Rooms by Type");
            Console.WriteLine("2. Book a Room");
            Console.WriteLine("3. View Rooms by Price Range");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option: ");
            
            var input = Console.ReadLine();
            
            switch (input)
            {
                case "1":
                    var groupedRooms = manager.GroupRoomsByType();
                    foreach (var type in groupedRooms)
                    {
                        Console.WriteLine($"\n{type.Key} Rooms:");
                        foreach (var room in type.Value)
                        {
                            Console.WriteLine($"Room {room.RoomNumber} - ₹{room.PricePerNight}");
                        }
                    }
                    Console.ReadKey();
                    break;

                case "2":
                    Console.Write("Enter Room Number: ");
                    int roomNumber = int.Parse(Console.ReadLine());

                    Console.Write("Enter Nights: ");
                    int nights = int.Parse(Console.ReadLine());

                    if (!manager.BookRoom(roomNumber, nights))
                    {
                        Console.WriteLine("Room not available or invalid room number.");
                    }
                    Console.ReadKey();
                    break;

                case "3":
                    Console.Write("Enter Minimum Price: ");
                    double min = double.Parse(Console.ReadLine());

                    Console.Write("Enter Maximum Price: ");
                    double max = double.Parse(Console.ReadLine());

                    var rooms = manager.GetAvailableRoomsByPriceRange(min, max);
                    foreach (var room in rooms)
                    {
                        Console.WriteLine($"Room {room.RoomNumber} - {room.RoomType} - ₹{room.PricePerNight}");
                    }
                    Console.ReadKey();
                    break;

                case "4":
                    Console.WriteLine("Exiting...");
                    return;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
