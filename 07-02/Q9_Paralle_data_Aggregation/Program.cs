using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var sales = new List<Sale>
        {
            new Sale("East","A",100,DateTime.Today),
            new Sale("East","B",200,DateTime.Today),
            new Sale("West","A",300,DateTime.Today.AddDays(-1)),
            new Sale("West","B",150,DateTime.Today)
        };

        var analyzer = new SalesAnalyzer();
        analyzer.Analyze(sales);
    }
}

class Sale
{
    public string Region;
    public string Category;
    public decimal Amount;
    public DateTime Date;

    public Sale(string r, string c, decimal a, DateTime d)
    {
        Region = r; Category = c; Amount = a; Date = d;
    }
}

class SalesAnalyzer
{
    public void Analyze(List<Sale> sales)
    {
        var totalByRegion = sales
            .AsParallel()
            .GroupBy(s => s.Region)
            .OrderBy(g => g.Key)
            .ToDictionary(g => g.Key, g => g.Sum(x => x.Amount));

        var topCategoryByRegion = sales
            .AsParallel()
            .GroupBy(s => new { s.Region, s.Category })
            .GroupBy(g => g.Key.Region)
            .ToDictionary(
                g => g.Key,
                g => g.OrderByDescending(x => x.Sum(s => s.Amount))
                      .First().Key.Category
            );

        var bestDay = sales
            .GroupBy(s => s.Date.Date)
            .OrderByDescending(g => g.Sum(x => x.Amount))
            .First().Key;

        Console.WriteLine("Best Sales Day: " + bestDay);
    }
}
