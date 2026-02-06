using HotelRoomBooking;
using System.Collections.Generic;
using System.Linq;

namespace HotelRoomBooking
{
    public class HotelManager
    {
        private readonly List<Room> rooms = new();

        public void AddRoom(int roomNumber, string type, double price)
        {
            if (rooms.Any(r => r.RoomNumber == roomNumber))
                return;

            rooms.Add(new Room(roomNumber, type, price));
        }

        public Dictionary<string, List<Room>> GroupRoomsByType()
        {
            var result = new Dictionary<string, List<Room>>();

            foreach (var room in rooms.Where(r => r.IsAvailable))
            {
                if (!result.ContainsKey(room.RoomType))
                {
                    result[room.RoomType] = new List<Room>();
                }

                result[room.RoomType].Add(room);
            }

            return result;
        }

        public bool BookRoom(int roomNumber, int nights)
        {
            var room = rooms.FirstOrDefault(r => r.RoomNumber == roomNumber && r.IsAvailable);

            if (room == null)
                return false;

            var totalCost = room.PricePerNight * nights;
            room.Book();
            return true;
        }

        public List<Room> GetAvailableRoomsByPriceRange(double min, double max)
        {
            return rooms
                .Where(r => r.IsAvailable && r.PricePerNight >= min && r.PricePerNight <= max)
                .ToList();
        }
    }
}
