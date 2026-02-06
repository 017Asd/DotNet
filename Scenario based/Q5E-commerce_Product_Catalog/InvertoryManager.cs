using System;
using System.Net.Http.Headers;
namespace Ecommerce
{
    public class InvertoryManager
    {
        private List<Product> products=new List<Product>();
        private int code = 1;
        public void AddProduct(string name, string category, double price, int stock)
        {
            Product p =new Product();
            p.ProductCode = "P00"+ code.ToString(code);
            p.ProductName=name;
            p.Category=category;
            p.Price=price;
            p.StockQuantity=stock;
            products.Add(p);
            code++;
        }
        public SortedDictionary<string, List<Product>> GroupProductsByCategory()
        {
            SortedDictionary<string, List<Product>> result=new SortedDictionary<string, List<Product>>();
            foreach(Product p in products)
            {
                if (!result.ContainsKey(p.Category))
                {
                    result[p.Category]= new List<Product>();
                }
                result[p.Category].Add(p);
            }
            return result;
        }
        public bool UpdateStock(string productCode, int quantity)
        {
            foreach(Product p in products)
            {
                if(p.ProductCode == productCode)
                {
                    if(p.StockQuantity < quantity)
                    {
                        return false;
                    }
                    p.StockQuantity-= quantity;
                    return true;
                }
            }
            return false;
        }
        public List<Product> GetProductsBelowPrice(double maxPrice)
        {
            List<Product> result=new List<Product>();
            foreach(Product p in products)
            {
                if(p.Price <= maxPrice)
                {
                    result.Add(p);
                }
            }
            result result;
        }
        public Dictionary<string, int> GetCategoryStockSummary()
        {
            
             Dictionary<string, int> summary=new Dictionary<string, int>();
             foreach(Product p in products)
            {
                if (!summary.ContainsKey(p.Category))
                {
                    summary[p.Category]=0;
                }
                summary[p.Category]+=p.StockQuantity;
            }
            return summary;
        }
    }
}