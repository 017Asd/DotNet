using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        var analyzer = new LogAnalyzer();
        var results = analyzer.GetTopErrors("log.txt", 3);

        foreach (var r in results)
            Console.WriteLine($"{r.Code} - {r.Count}");
    }
}

class LogAnalyzer
{
    public IEnumerable<ErrorSummary> GetTopErrors(string path, int topN)
    {
        var map = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(path))
        {
            var match = Regex.Match(line, @"ERR\d+");
            if (!match.Success) continue;

            map[match.Value] = map.GetValueOrDefault(match.Value) + 1;
        }

        return map.OrderByDescending(x => x.Value)
                  .Take(topN)
                  .Select(x => new ErrorSummary
                  {
                      Code = x.Key,
                      Count = x.Value
                  });
    }
}

class ErrorSummary
{
    public string Code { get; set; }
    public int Count { get; set; }
}
