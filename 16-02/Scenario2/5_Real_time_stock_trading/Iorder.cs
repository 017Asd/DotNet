using System;

public interface IOrder<T> where T : IComparable<T>
{
    string OrderId { get; }
    T Instrument { get; }
    OrderSide Side { get; }
    decimal Price { get; }
    int Quantity { get; set; }
    DateTime Timestamp { get; }
    int Priority { get; }
}
