using System;
using System.Collections.Generic;
using System.Linq;

namespace Q18
{
    public class EventManager
    {
        private readonly List<Event> _events = new();
        private readonly List<Attendee> _attendees = new();
        private readonly List<Ticket> _tickets = new();

        private int _nextEventId = 1;
        private int _nextAttendeeId = 1;

        public void CreateEvent(string name, string type, DateTime date,
                                string venue, int capacity, double price)
        {
            _events.Add(new Event
            {
                EventId = _nextEventId++,
                EventName = name,
                EventType = type,
                EventDate = date,
                Venue = venue,
                TotalCapacity = capacity,
                TicketsSold = 0,
                TicketPrice = price
            });
        }

        public int AddAttendee(string name, string email, string phone)
        {
            var attendee = new Attendee
            {
                AttendeeId = _nextAttendeeId++,
                Name = name,
                Email = email,
                Phone = phone
            };

            _attendees.Add(attendee);
            return attendee.AttendeeId;
        }

        public bool BookTicket(int eventId, int attendeeId, string seatNumber)
        {
            var evnt = _events.FirstOrDefault(e => e.EventId == eventId);
            var attendee = _attendees.FirstOrDefault(a => a.AttendeeId == attendeeId);

            if (evnt == null || attendee == null)
                return false;

            if (evnt.TicketsSold >= evnt.TotalCapacity)
                return false;

            evnt.TicketsSold++;

            attendee.RegisteredEvents.Add(eventId);

            _tickets.Add(new Ticket
            {
                TicketNumber = Guid.NewGuid().ToString(),
                EventId = eventId,
                AttendeeId = attendeeId,
                PurchaseDate = DateTime.UtcNow,
                SeatNumber = seatNumber
            });

            return true;
        }

        public Dictionary<string, List<Event>> GroupEventsByType()
        {
            return _events
                .GroupBy(e => e.EventType)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        public List<Event> GetUpcomingEvents(int days)
        {
            var endDate = DateTime.Now.AddDays(days);

            return _events
                .Where(e => e.EventDate >= DateTime.Now && e.EventDate <= endDate)
                .ToList();
        }

        public double CalculateEventRevenue(int eventId)
        {
            var evnt = _events.FirstOrDefault(e => e.EventId == eventId);
            if (evnt == null)
                return 0;

            return evnt.TicketsSold * evnt.TicketPrice;
        }
    }
}
