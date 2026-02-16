using System;
using System.Collections.Generic;
using System.Linq;

public enum Trend { Upward, Downward, Sideways }

public interface IInstrument
{
    string Symbol { get; }
    decimal CurrentPrice { get; set; }
    List<decimal> PriceHistory { get; }
}


public class FinancialInstrument : IInstrument
{
    public string Symbol { get; set; }
    public decimal CurrentPrice { get; set; }
    public List<decimal> PriceHistory { get; } = new();

    public void UpdatePrice(decimal newPrice)
    {
        PriceHistory.Add(CurrentPrice);
        CurrentPrice = newPrice;
    }
}


public class Portfolio<T> where T : IInstrument
{
    private Dictionary<T, int> _holdings = new();

    public void Buy(T instrument, int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be positive.");

        if (!_holdings.ContainsKey(instrument))
            _holdings[instrument] = 0;

        _holdings[instrument] += quantity;
    }

    public void Sell(T instrument, int quantity)
    {
        if (!_holdings.ContainsKey(instrument) || _holdings[instrument] < quantity)
            throw new InvalidOperationException("Not enough quantity to sell.");

        _holdings[instrument] -= quantity;

        if (_holdings[instrument] == 0)
            _holdings.Remove(instrument);
    }

    public decimal GetTotalValue()
    {
        return _holdings.Sum(h => h.Key.CurrentPrice * h.Value);
    }

    public Dictionary<T, int> GetHoldings() => _holdings;

   
    public void Rebalance()
    {
        var totalValue = GetTotalValue();
        if (_holdings.Count == 0) return;

        var equalShare = totalValue / _holdings.Count;

        foreach (var item in _holdings.Keys.ToList())
        {
            int newQty = (int)(equalShare / item.CurrentPrice);
            _holdings[item] = newQty;
        }
    }
}

public class TradingStrategy<T> where T : IInstrument
{
    private Func<T, bool> _buyCondition;
    private Func<T, bool> _sellCondition;

    public TradingStrategy(Func<T, bool> buyCondition, Func<T, bool> sellCondition)
    {
        _buyCondition = buyCondition;
        _sellCondition = sellCondition;
    }

    public void Execute(T instrument, Portfolio<T> portfolio)
    {
        if (_buyCondition(instrument))
            portfolio.Buy(instrument, 10);

        if (_sellCondition(instrument))
            portfolio.Sell(instrument, 5);
    }
}


public static class MarketAnalyzer
{
    public static Trend DetectTrend(IInstrument instrument)
    {
        if (instrument.PriceHistory.Count < 2)
            return Trend.Sideways;

        var last = instrument.CurrentPrice;
        var prev = instrument.PriceHistory.Last();

        if (last > prev) return Trend.Upward;
        if (last < prev) return Trend.Downward;
        return Trend.Sideways;
    }

    public static decimal CalculateVolatility(IInstrument instrument)
    {
        if (instrument.PriceHistory.Count < 2)
            return 0;

        var avg = instrument.PriceHistory.Average();
        var variance = instrument.PriceHistory
            .Select(p => Math.Pow((double)(p - avg), 2))
            .Average();

        return (decimal)Math.Sqrt(variance);
    }
}
