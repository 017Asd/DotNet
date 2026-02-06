using System;
using System.Collections.Generic;
using System.Linq;

namespace Q20
{
    public class RealEstateManager
    {
        private readonly List<Property> _properties = new();
        private readonly List<Client> _clients = new();
        private readonly List<Viewing> _viewings = new();

        private int _nextClientId = 1;
        private int _nextViewingId = 1;

        public void AddProperty(string address, string type, int bedrooms,
                                double area, double price, string owner)
        {
            _properties.Add(new Property
            {
                PropertyId = Guid.NewGuid().ToString(),
                Address = address,
                PropertyType = type,
                Bedrooms = bedrooms,
                AreaSqFt = area,
                Price = price,
                Status = "Available",
                Owner = owner
            });
        }

        public void AddClient(string name, string contact, string type,
                              double budget, List<string> requirements)
        {
            _clients.Add(new Client
            {
                ClientId = _nextClientId++,
                Name = name,
                Contact = contact,
                ClientType = type,
                Budget = budget,
                Requirements = requirements
            });
        }

        public bool ScheduleViewing(string propertyId, int clientId, DateTime date)
        {
            var property = _properties.FirstOrDefault(p => p.PropertyId == propertyId);
            var client = _clients.FirstOrDefault(c => c.ClientId == clientId);

            if (property == null || client == null)
                return false;

            _viewings.Add(new Viewing
            {
                ViewingId = _nextViewingId++,
                PropertyId = propertyId,
                ClientId = clientId,
                ViewingDate = date,
                Feedback = string.Empty
            });

            return true;
        }

        public Dictionary<string, List<Property>> GroupPropertiesByType()
        {
            return _properties
                .GroupBy(p => p.PropertyType)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        public List<Property> GetPropertiesInBudget(double minPrice, double maxPrice)
        {
            return _properties
                .Where(p => p.Price >= minPrice && p.Price <= maxPrice && p.Status == "Available")
                .ToList();
        }
    }
}
