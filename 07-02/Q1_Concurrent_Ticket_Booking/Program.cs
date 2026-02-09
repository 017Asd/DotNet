using System;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        Seat seat = new Seat(1);

        Parallel.Invoke(
            () => Console.WriteLine(seat.BookSeat(1, "UserA")),
            () => Console.WriteLine(seat.BookSeat(1, "UserB"))
        );
    }
}

class Seat
{
    public int SeatNo { get; }
    public bool IsBooked { get; private set; }
    private readonly object _lock = new();

    public Seat(int seatNo)
    {
        SeatNo = seatNo;
    }

    public bool BookSeat(int seatNo, string userId)
    {
        lock (_lock)
        {
            if (IsBooked)
                return false;

            IsBooked = true;
            return true;
        }
    }
}
