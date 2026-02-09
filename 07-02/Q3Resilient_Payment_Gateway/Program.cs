using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        var service = new PaymentService();

        try
        {
            var result = await service.ProcessPaymentAsync(
                new PaymentRequest(),
                CancellationToken.None);

            Console.WriteLine("Payment Success");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

class PaymentService
{
    private int _failureCount;
    private DateTime _circuitOpenedAt;
    private readonly object _lock = new();

    public async Task<PaymentResult> ProcessPaymentAsync(
        PaymentRequest request,
        CancellationToken token)
    {
        lock (_lock)
        {
            if (_failureCount >= 5 &&
                DateTime.UtcNow - _circuitOpenedAt < TimeSpan.FromSeconds(30))
                throw new Exception("Circuit Open");
        }

        for (int i = 0; i < 3; i++)
        {
            token.ThrowIfCancellationRequested();
            try
            {
                await Task.Delay(200, token);
                return new PaymentResult { Success = true };
            }
            catch
            {
                RegisterFailure();
            }
        }

        throw new Exception("Payment Failed");
    }

    private void RegisterFailure()
    {
        lock (_lock)
        {
            _failureCount++;
            if (_failureCount == 5)
                _circuitOpenedAt = DateTime.UtcNow;
        }
    }
}

class PaymentRequest { }
class PaymentResult { public bool Success { get; set; } }
