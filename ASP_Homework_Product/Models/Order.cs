using System.Collections.Generic;

namespace ASP_Homework_Product.Models
{
    public class Order
    {
        static int unicId = 1;
        public int Id { get; }
        public decimal Price { get;}
        public List<Product> PurchasedProducts { get; }
        public string CustomerId { get; }
        public string CustomerName { get; }
        public string CustomerAddress { get; }
        public string CustomerPhone { get; }
        public string CustomerEmail { get; }
        public string CustomerComment { get; }

        public Order(decimal price, List<Product> purchasedProducts, string customerId, string customerName, string customerAddress, string customerPhone, string customerEmail, string customerComment)
        {
            Id = unicId++;
            Price = price;
            PurchasedProducts = purchasedProducts;
            CustomerId = customerId;
            CustomerName = customerName;
            CustomerAddress = customerAddress;
            CustomerPhone = customerPhone;
            CustomerEmail = customerEmail;
            CustomerComment = customerComment;
        }

        public override string ToString()
        {
            return $"{Id} - {Price} - {PurchasedProducts.Count}";
        }
    }
}
