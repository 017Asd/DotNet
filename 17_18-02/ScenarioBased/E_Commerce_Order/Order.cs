using System.Data;
using System.Net.Http.Headers;
using System.Security.AccessControl;

namespace Q3
{
    public class Order
    {
        public int OrderId{get;set;}
        public Customer Customer{get;set;}
        public List<OrderItem> items{get;set;}
        public DateTime OrderDate{get;set;}
        public OrderStatus Status{get;set;}
        public Order(int orderid,Customer customer)
        {
            if(customer.IsBlackListed)
                throw new CustomerBlackListedException("Customer is blacklisted");
            OrderId=orderid;
            Customer=customer;
            items=new List<OrderItem>();
            OrderDate=DateTime.Now;
            Status=OrderStatus.Pending;
        }
        public void AddItem(Product product,int qunatity)
        {
            if(qunatity>product.Stock)
                throw new OutOfStockException($"Not enough stock for {product.Name}");
            product.Stock-=qunatity;
            items.Add(new OrderItem(product,qunatity));
        }
        public double CalculateTotal()
        {
            double total=0;
            foreach (var item in items)
            {
                total+=item.TotalPrice();
            }
            return total;
        }
        public void ShipOrder()
        {
            Status=OrderStatus.Shipped;

        }
        public void CancelOrder()
        {
            if(Status==OrderStatus.Shipped)
                throw new OrderAlreadyShippedException("You cannot cancel the order since its already shipped");
            Status=OrderStatus.Cancelled;
        }

    }
}