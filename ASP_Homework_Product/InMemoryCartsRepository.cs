using ASP_Homework_Product.Models;
using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ASP_Homework_Product
{
    public class InMemoryCartsRepository : ICartsRepository
    {
        public List<Cart> carts = new List<Cart>();

        public List<Cart> Carts
        {
            get { return carts; }
        }

        public void AddCartToRepository(Cart cart)
        {
            Carts.Add(cart);
        }

        public void RemoveCartFromRepository(Cart cart)
        {
            Carts.Add(cart);
        }

        public Cart TryGetCartByUserId(string userId)
        {
            return Carts.FirstOrDefault(cart => cart.UserId == userId);
        }

        public void AddToCart(Product product, string userId)
        {
            var cart = TryGetCartByUserId(userId);
            if (cart == null)
            {
                var newCart = new Cart
                {
                    UserId = userId,
                    ProductsInCart = new List<Product>()
                };
                AddCartToRepository(newCart);
                if (!newCart.ProductsInCart.Contains(product))
                {
                    newCart.ProductsInCart.Add(product);
                }
            }
            else
            {
                cart.ProductsInCart.Add(product);
            }
        }

        public void RemoveFromCart(Product product, string userId)
        {
            var cart = TryGetCartByUserId(userId);
            if (cart.ProductsInCart.Contains(product))
            {
                cart.ProductsInCart.Remove(product);
            }
        }

        public void RemoveIdenticalFromCart(Product product, string userId)
        {
            var cart = TryGetCartByUserId(userId);
            if (cart.ProductsInCart.Contains(product))
            {
                cart.ProductsInCart.RemoveAll(prod => prod.Id == product.Id);
            }
        }
        public void ClearCart(string userId)
        {
            var cart = TryGetCartByUserId(userId);
            if (carts.Contains(cart))
            {
                cart.ProductsInCart.Clear();
            }
        }
    }

    public interface ICartsRepository
    {
        public List<Cart> Carts { get; }

        public void AddCartToRepository(Cart cart);

        public void RemoveCartFromRepository(Cart cart);

        public Cart TryGetCartByUserId(string userId);

        public void AddToCart(Product product, string userId);

        public void RemoveFromCart(Product product, string userId);

        public void RemoveIdenticalFromCart(Product product, string userId);

        public void ClearCart(string userId);
    }
}
