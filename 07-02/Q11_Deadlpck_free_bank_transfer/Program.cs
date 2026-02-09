using System;

class Program
{
    static void Main()
    {
        var a = new Account { Id = 1, Balance = 1000 };
        var b = new Account { Id = 2, Balance = 500 };

        TransferService.SafeTransfer(a, b, 200);

        Console.WriteLine(a.Balance);
        Console.WriteLine(b.Balance);
    }
}

class Account
{
    public int Id;
    public decimal Balance;
    public readonly object Lock = new();
}

static class TransferService
{
    public static void SafeTransfer(Account a, Account b, decimal amount)
    {
        var first = a.Id < b.Id ? a : b;
        var second = a.Id < b.Id ? b : a;

        lock (first.Lock)
        {
            lock (second.Lock)
            {
                a.Balance -= amount;
                b.Balance += amount;
            }
        }
    }
}
