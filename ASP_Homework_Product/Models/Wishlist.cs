using System.Collections.Generic;

namespace ASP_Homework_Product.Models
{
    public class Wishlist
    {
        public List<Product> ProductsInWishlist { get; set; }
        public string UserId { get; set; }

        public Wishlist()
        {
            ProductsInWishlist = new List<Product>();
        }
    }
}
