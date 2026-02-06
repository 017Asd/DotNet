using System;
using System.Collections.Generic;
using System.Text;
namespace HotelRoomBooking
{
    public class Room
    {
        public int RoomNumber { get;  }
        public string RoomType { get; }
        public double PricePerNight { get; }
        public bool IsAvailable { get; private set; }
        public Room(int room, string type, double price)
        {
            RoomNumber = room;
            RoomType = type;
            PricePerNight = price;
            IsAvailable = true;
        }
        public void Book()
        {
            IsAvailable = false;
        }
    }

}
