using ASP_Homework_Product.Models;
using System.Collections.Generic;
using System.Linq;

namespace ASP_Homework_Product
{
    public class InMemoryWishlistsRepositories : IWishlistsRepository
    {

        public List<Wishlist> wishlists = new List<Wishlist>();

        public List<Wishlist> Wishlists
        {
            get { return wishlists; }
        }

        public void AddWishlistToRepository(Wishlist wishlist)
        {
            Wishlists.Add(wishlist);
        }

        public void RemoveWishlistFromRepository(Wishlist wishlist)
        {
            Wishlists.Add(wishlist);
        }

        public Wishlist TryGetWishlistByUserId(string userId)
        {
            return Wishlists.FirstOrDefault(wishlist => wishlist.UserId == userId);
        }

        public void AddToWishlist(Product product, string userId)
        {
            var wishlist = TryGetWishlistByUserId(userId);
            if (wishlist == null)
            {
                var newWishlist = new Wishlist
                {
                    UserId = userId,
                    ProductsInWishlist = new List<Product>()
                };
                AddWishlistToRepository(newWishlist);
                if (!newWishlist.ProductsInWishlist.Contains(product))
                {
                    newWishlist.ProductsInWishlist.Add(product);
                }
            }
            else
            {
                wishlist.ProductsInWishlist.Add(product);
            }
        }

        public void RemoveFromWishlist(Product product, string userId)
        {
            var cart = TryGetWishlistByUserId(userId);
            if (cart.ProductsInWishlist.Contains(product))
            {
                cart.ProductsInWishlist.Remove(product);
            }
        }

        public void RemoveIdenticalFromWishlist(Product product, string userId)
        {
            var cart = TryGetWishlistByUserId(userId);
            if (cart.ProductsInWishlist.Contains(product))
            {
                cart.ProductsInWishlist.RemoveAll(prod => prod.Id == product.Id);
            }
        }
        public void ClearWishlist(string userId)
        {
            var wishlist = TryGetWishlistByUserId(userId);
            if (wishlists.Contains(wishlist))
            {
                wishlist.ProductsInWishlist.Clear();
            }
        }
    }

    public interface IWishlistsRepository
    {
        public List<Wishlist> Wishlists { get; }

        public void AddWishlistToRepository(Wishlist wishlist);

        public void RemoveWishlistFromRepository(Wishlist wishlist);

        public Wishlist TryGetWishlistByUserId(string userId);

        public void AddToWishlist(Product product, string userId);

        public void RemoveFromWishlist(Product product, string userId);

        public void RemoveIdenticalFromWishlist(Product product, string userId);

        public void ClearWishlist(string userId);
    }
}
