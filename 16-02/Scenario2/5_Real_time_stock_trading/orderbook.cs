using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class OrderBook<T> where T : IComparable<T>
{
    private ConcurrentDictionary<string, IOrder<T>> _allOrders =
        new ConcurrentDictionary<string, IOrder<T>>();

    private ConcurrentQueue<IOrder<T>> _buyOrders =
        new ConcurrentQueue<IOrder<T>>();

    private ConcurrentQueue<IOrder<T>> _sellOrders =
        new ConcurrentQueue<IOrder<T>>();

    private ConcurrentBag<OrderMatch<T>> _matches =
        new ConcurrentBag<OrderMatch<T>>();

    private ConcurrentQueue<MarketData<T>> _marketDataStream =
        new ConcurrentQueue<MarketData<T>>();

    private ConcurrentQueue<decimal> _priceHistory =
        new ConcurrentQueue<decimal>();

    public async Task ProcessOrderAsync(IOrder<T> order)
    {
        _allOrders[order.OrderId] = order;

        if (order.Side == OrderSide.Buy)
            _buyOrders.Enqueue(order);
        else
            _sellOrders.Enqueue(order);

        await MatchOrdersAsync();
    }

    private Task MatchOrdersAsync()
    {
        while (_buyOrders.TryPeek(out var buy) &&
               _sellOrders.TryPeek(out var sell))
        {
            if (buy.Price >= sell.Price)
            {
                _buyOrders.TryDequeue(out buy);
                _sellOrders.TryDequeue(out sell);

                int matchedQty = Math.Min(buy.Quantity, sell.Quantity);

                buy.Quantity -= matchedQty;
                sell.Quantity -= matchedQty;

                var match = new OrderMatch<T>
                {
                    BuyOrder = buy,
                    SellOrder = sell,
                    MatchPrice = sell.Price,
                    Quantity = matchedQty
                };

                _matches.Add(match);
                _priceHistory.Enqueue(match.MatchPrice);

                if (buy.Quantity > 0)
                    _buyOrders.Enqueue(buy);

                if (sell.Quantity > 0)
                    _sellOrders.Enqueue(sell);
            }
            else
            {
                break;
            }
        }

        return Task.CompletedTask;
    }

    public IEnumerable<OrderMatch<T>> GetOrderMatches(int count)
    {
        return _matches
            .AsParallel()
            .Take(count)
            .ToList();
    }

    public decimal CalculateVWAP(TimeSpan period)
    {
        var cutoff = DateTime.UtcNow - period;

        var relevantMatches = _matches
            .Where(m => m.BuyOrder.Timestamp >= cutoff);

        decimal totalValue = 0;
        int totalVolume = 0;

        foreach (var match in relevantMatches)
        {
            totalValue += match.MatchPrice * match.Quantity;
            totalVolume += match.Quantity;
        }

        if (totalVolume == 0)
            return 0;

        return totalValue / totalVolume;
    }
}
