using System;
using System.Collections.Generic;
using System.Linq;


public interface IProduct
{
    int Id { get; }
    string Name { get; }
    decimal Price { get; }
    Category Category { get; }
}

public enum Category { Electronics, Clothing, Books, Groceries }


public class ProductRepository<T> where T : class, IProduct
{
    private List<T> _products = new List<T>();
    
   
    public void AddProduct(T product)
    {
        if (product == null)
            throw new ArgumentNullException(nameof(product));

        if (string.IsNullOrWhiteSpace(product.Name))
            throw new ArgumentException("Product name cannot be null or empty.");

        if (product.Price <= 0)
            throw new ArgumentException("Price must be positive.");

        if (_products.Any(p => p.Id == product.Id))
            throw new InvalidOperationException("Product ID must be unique.");

        _products.Add(product);
    }
    
   
    public IEnumerable<T> FindProducts(Func<T, bool> predicate)
    {
        if (predicate == null)
            throw new ArgumentNullException(nameof(predicate));

        return _products.Where(predicate);
    }
    
    
    public decimal CalculateTotalValue()
    {
        return _products.Sum(p => p.Price);
    }

    public List<T> GetAll()
    {
        return _products;
    }
}


public class ElectronicProduct : IProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Category Category => Category.Electronics;
    public int WarrantyMonths { get; set; }
    public string Brand { get; set; }
}


public class DiscountedProduct<T> where T : IProduct
{
    private T _product;
    private decimal _discountPercentage;
    
    public DiscountedProduct(T product, decimal discountPercentage)
    {
        if (product == null)
            throw new ArgumentNullException(nameof(product));

        if (discountPercentage < 0 || discountPercentage > 100)
            throw new ArgumentException("Discount must be between 0 and 100.");

        _product = product;
        _discountPercentage = discountPercentage;
    }
    
   
    public decimal DiscountedPrice => 
        _product.Price * (1 - _discountPercentage / 100);
    
   
    public override string ToString()
    {
        return $"{_product.Name} | Original: {_product.Price:C} | " +
               $"Discount: {_discountPercentage}% | Final: {DiscountedPrice:C}";
    }
}


public class InventoryManager
{
    
    public void ProcessProducts<T>(IEnumerable<T> products) where T : IProduct
    {
        var list = products.ToList();

        // a) Print all product names and prices
        foreach (var product in list)
        {
            Console.WriteLine($"{product.Name} - {product.Price:C}");
        }

        if (!list.Any())
            return;

        
        var mostExpensive = list.OrderByDescending(p => p.Price).First();
        Console.WriteLine($"Most Expensive: {mostExpensive.Name}");

       
        var grouped = list.GroupBy(p => p.Category);
        foreach (var group in grouped)
        {
            Console.WriteLine($"Category: {group.Key}");
            foreach (var product in group)
            {
                Console.WriteLine($"   - {product.Name}");
            }
        }

        
        foreach (var product in list
            .Where(p => p.Category == Category.Electronics && p.Price > 500))
        {
            var discounted = new DiscountedProduct<T>(product, 10);
            Console.WriteLine(discounted);
        }
    }
    
    // Bulk price update with delegate
    public void UpdatePrices<T>(List<T> products, Func<T, decimal> priceAdjuster) 
        where T : IProduct
    {
        if (products == null)
            throw new ArgumentNullException(nameof(products));

        if (priceAdjuster == null)
            throw new ArgumentNullException(nameof(priceAdjuster));

        foreach (var product in products)
        {
            try
            {
                decimal newPrice = priceAdjuster(product);

                if (newPrice <= 0)
                    throw new InvalidOperationException("Adjusted price must be positive.");

                var priceProperty = product.GetType().GetProperty("Price");
                if (priceProperty != null && priceProperty.CanWrite)
                {
                    priceProperty.SetValue(product, newPrice);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating {product.Name}: {ex.Message}");
            }
        }
    }
}
