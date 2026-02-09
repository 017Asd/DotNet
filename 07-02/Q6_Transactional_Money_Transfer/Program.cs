using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var bank = new Bank();
        bank.AddAccount("A", 1000);
        bank.AddAccount("B", 500);

        bank.Transfer("A", "B", 200);
        Console.WriteLine("Transfer Successful");
    }
}

class Bank
{
    private readonly Dictionary<string, decimal> _accounts = new();
    private readonly object _lock = new();

    public void AddAccount(string id, decimal balance)
    {
        _accounts[id] = balance;
    }

    public void Transfer(string from, string to, decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException();

        lock (_lock)
        {
            if (_accounts[from] < amount)
                throw new InvalidOperationException();

            _accounts[from] -= amount;

            try
            {
                _accounts[to] += amount;
                Log("SUCCESS");
            }
            catch
            {
                _accounts[from] += amount;
                Log("FAILED");
                throw;
            }
        }
    }

    private void Log(string msg) { }
}
