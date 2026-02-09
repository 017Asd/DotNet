using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var cache = new AdvancedCache<string, string>(2);

        cache.Set("A", "Apple", 5);
        cache.Set("B", "Ball", 5);

        Console.WriteLine(cache.Get("A"));

        cache.Set("C", "Cat", 5);

        Console.WriteLine(cache.Get("B"));
        Console.WriteLine(cache.Get("C"));
    }
}

class AdvancedCache<TKey, TValue>
{
    private readonly int _capacity;
    private readonly Dictionary<TKey, LinkedListNode<(TKey, TValue, DateTime)>> _map = new();
    private readonly LinkedList<(TKey, TValue, DateTime)> _lru = new();

    public AdvancedCache(int capacity)
    {
        _capacity = capacity;
    }

    public void Set(TKey key, TValue value, int ttlSeconds)
    {
        if (_map.ContainsKey(key))
            _lru.Remove(_map[key]);

        if (_map.Count >= _capacity)
        {
            var last = _lru.Last;
            _map.Remove(last.Value.Item1);
            _lru.RemoveLast();
        }

        var node = new LinkedListNode<(TKey, TValue, DateTime)>
            ((key, value, DateTime.UtcNow.AddSeconds(ttlSeconds)));

        _lru.AddFirst(node);
        _map[key] = node;
    }

    public TValue Get(TKey key)
    {
        if (!_map.ContainsKey(key))
            return default;

        var node = _map[key];

        if (node.Value.Item3 < DateTime.UtcNow)
        {
            _map.Remove(key);
            _lru.Remove(node);
            return default;
        }

        _lru.Remove(node);
        _lru.AddFirst(node);
        return node.Value.Item2;
    }
}
