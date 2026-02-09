using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        var processor = new OrderProcessor();
        int result = await processor.StartAsync();
        Console.WriteLine($"Total Processed: {result}");
    }
}

class OrderProcessor
{
    private readonly BlockingCollection<int> _queue = new();

    public async Task<int> StartAsync()
    {
        int processed = 0;

        var consumers = Enumerable.Range(0, 3)
            .Select(_ => Task.Run(async () =>
            {
                foreach (var order in _queue.GetConsumingEnumerable())
                {
                    await Task.Delay(100);
                    Interlocked.Increment(ref processed);
                }
            }))
            .ToArray();

        for (int i = 1; i <= 10; i++)
            _queue.Add(i);

        _queue.CompleteAdding();
        await Task.WhenAll(consumers);

        return processed;
    }
}
