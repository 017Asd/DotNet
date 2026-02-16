using System;

class Program
{
    static void Main()
    {
        var stock = new FinancialInstrument
        {
            Symbol = "AAPL",
            CurrentPrice = 150
        };

        var crypto = new FinancialInstrument
        {
            Symbol = "BTC",
            CurrentPrice = 30000
        };

        // Track price history
        stock.UpdatePrice(155);
        stock.UpdatePrice(160);

        crypto.UpdatePrice(31000);
        crypto.UpdatePrice(29000);

        var portfolio = new Portfolio<FinancialInstrument>();

        // Buy logic
        portfolio.Buy(stock, 20);
        portfolio.Buy(crypto, 1);

        Console.WriteLine("Initial Portfolio Value:");
        Console.WriteLine(portfolio.GetTotalValue());

        // Trading strategy using lambda
        var strategy = new TradingStrategy<FinancialInstrument>(
            buyCondition: instrument => instrument.CurrentPrice < 200,
            sellCondition: instrument => instrument.CurrentPrice > 30500
        );

        strategy.Execute(stock, portfolio);
        strategy.Execute(crypto, portfolio);

        Console.WriteLine("\nPortfolio Value After Strategy:");
        Console.WriteLine(portfolio.GetTotalValue());

        // Rebalancing
        portfolio.Rebalance();

        Console.WriteLine("\nPortfolio Value After Rebalance:");
        Console.WriteLine(portfolio.GetTotalValue());

        // Trend detection
        Console.WriteLine("\nStock Trend: " +
            MarketAnalyzer.DetectTrend(stock));

        Console.WriteLine("Crypto Trend: " +
            MarketAnalyzer.DetectTrend(crypto));

        // Risk calculation
        Console.WriteLine("\nStock Volatility: " +
            MarketAnalyzer.CalculateVolatility(stock));

        Console.WriteLine("Crypto Volatility: " +
            MarketAnalyzer.CalculateVolatility(crypto));

        Console.ReadKey();
    }
}
