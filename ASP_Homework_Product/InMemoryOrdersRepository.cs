using ASP_Homework_Product.Models;
using System.Collections.Generic;
using System.Linq;

namespace ASP_Homework_Product
{
    public class InMemoryOrdersRepository : IOrderRepository
    {
        List<Order> orders = new List<Order>();

        public List<Order> Orders
        {
            get { return orders; }
        }

        public void CreateOrder(decimal price, List<Product> purchasedProducts, string customerId, string customerName, string customerAddress, string customerPhone, string customerEmail, string customerComment)
        {
            Orders.Add(new Order(price, purchasedProducts, customerId, customerName, customerAddress, customerPhone, customerEmail, customerComment));
        }

        public void CreateOrder(Order newOrder)
        {
            Orders.Add(newOrder);
        }

        public Order TryToGetById(int id)
        {
            return orders.Where(order => order.Id == id).FirstOrDefault();
        }
    }

    public interface IOrderRepository
    {
        public List<Order> Orders { get; }

        public void CreateOrder(decimal price, List<Product> purchasedProducts, string customerId, string customerName, string customerAddress, string customerPhone, string customerEmail, string customerComment);

        public void CreateOrder(Order newOrder);

        public Order TryToGetById(int id);

    }
}
