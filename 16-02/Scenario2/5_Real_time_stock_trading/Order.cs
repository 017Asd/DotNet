using System;

public class Order<T> : IOrder<T> where T : IComparable<T>
{
    public string OrderId { get; set; }
    public T Instrument { get; set; }
    public OrderSide Side { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public int Priority { get; set; }
}
