using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        OrderBook<string> orderBook = new OrderBook<string>();

        var buyOrder = new Order<string>
        {
            OrderId = "B1",
            Instrument = "AAPL",
            Side = OrderSide.Buy,
            Price = 150,
            Quantity = 100,
            Priority = 1
        };

        var sellOrder = new Order<string>
        {
            OrderId = "S1",
            Instrument = "AAPL",
            Side = OrderSide.Sell,
            Price = 148,
            Quantity = 100,
            Priority = 1
        };

        await orderBook.ProcessOrderAsync(buyOrder);
        await orderBook.ProcessOrderAsync(sellOrder);

        var matches = orderBook.GetOrderMatches(10);

        foreach (var match in matches)
        {
            Console.WriteLine($"Matched {match.Quantity} at {match.MatchPrice}");
        }

        var vwap = orderBook.CalculateVWAP(TimeSpan.FromMinutes(10));
        Console.WriteLine($"VWAP: {vwap}");
    }
}
