using System.Net.Http.Headers;

namespace Q3
{
    public class OrderItem
    {
        public Product Product{get;set;}
        public int Quantity{get;set;}
        public OrderItem(Product product,int quantity)
        {
            Product=product;
            Quantity=quantity;
        }
        public double TotalPrice()
        {
            return Product.Price*Quantity;
        }
    }
}