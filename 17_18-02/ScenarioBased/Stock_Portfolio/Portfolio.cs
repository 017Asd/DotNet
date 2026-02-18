using System;
using System.Collections.Generic;

namespace Q6
{
    public class Portfolio
    {
        public Dictionary<string, int> Holdings { get; set; }
        public List<Transaction> Transactions { get; set; }

        public Portfolio()
        {
            Holdings = new Dictionary<string, int>();
            Transactions = new List<Transaction>();
        }

        public void BuyStock(Transaction transaction)
        {
            if (transaction.Type != TransactionType.Buy)
                return;

            if (!Holdings.ContainsKey(transaction.Stock.Symbol))
                Holdings[transaction.Stock.Symbol] = 0;

            Holdings[transaction.Stock.Symbol] += transaction.Quantity;
            Transactions.Add(transaction);
        }

        public void SellStock(Transaction transaction)
        {
            if (transaction.Type != TransactionType.Sell)
                return;

            if (!Holdings.ContainsKey(transaction.Stock.Symbol) ||
                Holdings[transaction.Stock.Symbol] < transaction.Quantity)
            {
                throw new InsufficientSharesException("Cannot sell more shares than owned.");
            }

            Holdings[transaction.Stock.Symbol] -= transaction.Quantity;
            Transactions.Add(transaction);
        }

        public double CalculateRisk(List<Stock> stocks)
        {
            double totalRisk = 0;

            foreach (var holding in Holdings)
            {
                string symbol = holding.Key;
                int shares = holding.Value;

                foreach (var stock in stocks)
                {
                    if (stock.Symbol == symbol)
                    {
                        totalRisk += shares * stock.RiskFactor;
                    }
                }
            }

            return totalRisk;
        }
    }
}
