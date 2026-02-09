using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main()
    {
        RateLimiter limiter = new RateLimiter();
        string client = "client1";

        for (int i = 1; i <= 6; i++)
        {
            Console.WriteLine(
                $"Request {i}: " +
                limiter.AllowRequest(client, DateTime.UtcNow)
            );
            Thread.Sleep(1000);
        }
    }
}

class RateLimiter
{
    private readonly Dictionary<string, Queue<DateTime>> _requests = new();
    private readonly object _lock = new();

    public bool AllowRequest(string clientId, DateTime now)
    {
        lock (_lock)
        {
            if (!_requests.ContainsKey(clientId))
                _requests[clientId] = new Queue<DateTime>();

            var queue = _requests[clientId];

            while (queue.Count > 0 &&
                   (now - queue.Peek()).TotalSeconds > 10)
            {
                queue.Dequeue();
            }

            if (queue.Count >= 5)
                return false;

            queue.Enqueue(now);
            return true;
        }
    }
}
