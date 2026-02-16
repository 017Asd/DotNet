using System;

public enum OrderSide
{
    Buy,
    Sell
}

public class MarketData<T>
{
    public T Instrument { get; set; }
    public decimal Price { get; set; }
    public DateTime Timestamp { get; set; }
}

public class OrderMatch<T>
{
    public IOrder<T> BuyOrder { get; set; }
    public IOrder<T> SellOrder { get; set; }
    public decimal MatchPrice { get; set; }
    public int Quantity { get; set; }
}
