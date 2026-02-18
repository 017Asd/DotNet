using System;
using System.Collections.Generic;

namespace Q6
{
    public class Program
    {
        public static void Main()
        {
            List<Investor> investors = new List<Investor>();
            List<Stock> stocks = new List<Stock>();
            List<Transaction> transactions = new List<Transaction>();
            Dictionary<string, List<Transaction>> investorTransactions =
                new Dictionary<string, List<Transaction>>();

            // Create Stocks
            Stock s1 = new Stock("AAPL", "Apple", 180, 1.2);
            Stock s2 = new Stock("TSLA", "Tesla", 250, 2.5);

            stocks.Add(s1);
            stocks.Add(s2);

            // Create Investor
            Investor investor1 = new Investor(1, "Rahul");
            investors.Add(investor1);

            investorTransactions[investor1.Name] = new List<Transaction>();

            Console.WriteLine("=== BUY TRANSACTION ===");

            try
            {
                Transaction t1 = new Transaction(1, s1, 10, DateTime.Now, TransactionType.Buy);
                investor1.Portfolio.BuyStock(t1);

                transactions.Add(t1);
                investorTransactions[investor1.Name].Add(t1);

                Console.WriteLine("Stock bought successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.WriteLine("\n=== SELL TRANSACTION ===");

            try
            {
                Transaction t2 = new Transaction(2, s1, 5, DateTime.Now, TransactionType.Sell);
                investor1.Portfolio.SellStock(t2);

                transactions.Add(t2);
                investorTransactions[investor1.Name].Add(t2);

                Console.WriteLine("Stock sold successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.WriteLine("\n=== SELL MORE THAN OWNED ===");

            try
            {
                Transaction t3 = new Transaction(3, s1, 20, DateTime.Now, TransactionType.Sell);
                investor1.Portfolio.SellStock(t3);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.WriteLine("\n=== PORTFOLIO RISK ===");
            double risk = investor1.Portfolio.CalculateRisk(stocks);
            Console.WriteLine($"Total Portfolio Risk: {risk}");
        }
    }
}
