using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASP_Homework_Product.Models
{
    public class Order
    {
        static int unicId = 1;
        public int Id { get; }
        public decimal Price { get;}
        public List<Product> PurchasedProducts { get; }
        public string CustomerId { get; }

        [Required(ErrorMessage = "Please enter your name")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Please enter your real name")]
        public string CustomerName { get; }

        [Required(ErrorMessage = "Please enter your lastname")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Please enter your real lastname")]
        public string CustomerLastName { get; }

        [Required(ErrorMessage = "Please enter your phone")]
        [RegularExpression("^[\\+]?[(]?[0-9]{3}[)]?[-\\s\\.]?[0-9]{3}[-\\s\\.]?[0-9]{4,6}$", ErrorMessage = "Please enter a valid phone number")]
        public string CustomerPhone { get; }

        [Required(ErrorMessage = "Please enter your email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string CustomerEmail { get; }

        [StringLength(300, ErrorMessage = "Maximum number of characters - 300")]
        public string CustomerComment { get; }

        public Order()
        {

        }

        public Order(decimal price, List<Product> purchasedProducts, string customerId, string customerName, string customerLastName, string customerPhone, string customerEmail, string customerComment)
        {
            Id = unicId++;
            Price = price;
            PurchasedProducts = purchasedProducts;
            CustomerId = customerId;
            CustomerName = customerName;
            CustomerLastName = customerLastName;
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
