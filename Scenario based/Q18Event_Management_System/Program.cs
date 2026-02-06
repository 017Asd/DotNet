using System;

namespace Q18{

class Program
{
    static void Main()
    {
        var manager = new EventManager();

        manager.CreateEvent("Rock Concert", "Concert", DateTime.Now.AddDays(10), "Stadium A", 100, 50);
        manager.CreateEvent("Tech Conference", "Conference", DateTime.Now.AddDays(20), "Convention Center", 200, 150);
        manager.CreateEvent("Photography Workshop", "Workshop", DateTime.Now.AddDays(5), "Studio X", 30, 75);

        int attendee1 = manager.AddAttendee("Alice Johnson", "alice@example.com", "1234567890");
        int attendee2 = manager.AddAttendee("Bob Smith", "bob@example.com", "0987654321");

        manager.BookTicket(1, attendee1, "A1");
        manager.BookTicket(1, attendee2, "A2");
        manager.BookTicket(2, attendee1, "B1");

        var groupedEvents = manager.GroupEventsByType();
        Console.WriteLine("Events grouped by type:");
        foreach (var group in groupedEvents)
        {
            Console.WriteLine(group.Key);
            foreach (var evnt in group.Value)
            {
                Console.WriteLine($"{evnt.EventId} {evnt.EventName} {evnt.EventDate.ToShortDateString()}");
            }
        }

        var upcoming = manager.GetUpcomingEvents(15);
        Console.WriteLine("\nUpcoming events in next 15 days:");
        foreach (var evnt in upcoming)
        {
            Console.WriteLine($"{evnt.EventId} {evnt.EventName} {evnt.EventDate.ToShortDateString()}");
        }

        double revenue1 = manager.CalculateEventRevenue(1);
        double revenue2 = manager.CalculateEventRevenue(2);
        Console.WriteLine($"\nRevenue for Event 1: ${revenue1}");
        Console.WriteLine($"Revenue for Event 2: ${revenue2}");

        Console.ReadKey();
    }
}
}