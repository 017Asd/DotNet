using System;
using System.Collections.Generic;
using System.Linq;

public class ShoppingCart<T> where T : Product
{
    private Dictionary<T, int> _cartItems = new Dictionary<T, int>();

    public void AddToCart(T product, int quantity)
    {
        if (product == null)
            throw new ArgumentNullException(nameof(product));

        if (quantity <= 0)
            throw new ArgumentException("Quantity must be positive.");

        if (_cartItems.ContainsKey(product))
            _cartItems[product] += quantity;
        else
            _cartItems[product] = quantity;
    }

    public double CalculateTotal(Func<T, double, double> discountCalculator = null)
    {
        double total = 0;

        foreach (var item in _cartItems)
        {
            double price = item.Key.Price * item.Value;

            if (discountCalculator != null)
                price = discountCalculator(item.Key, price);

            total += price;
        }

        return total;
    }

    public List<T> GetTopExpensiveItems(int n)
    {
        return _cartItems
            .OrderByDescending(x => x.Key.Price)
            .Take(n)
            .Select(x => x.Key)
            .ToList();
    }
}
