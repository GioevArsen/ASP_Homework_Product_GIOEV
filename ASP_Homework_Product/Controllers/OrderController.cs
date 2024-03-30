using ASP_Homework_Product.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ASP_Homework_Product.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICartsRepository cartsRepository;
        private readonly IOrderRepository ordersRepository;
        private readonly IConstants constants;

        public OrderController(ICartsRepository cartsRepository, IOrderRepository orderRepository, IConstants constants)
        {
            this.cartsRepository = cartsRepository;
            this.ordersRepository = orderRepository;
            this.constants = constants;
        }

        public IActionResult Index(string userId)
        {
            var cart = cartsRepository.TryGetCartByUserId(userId);
            return View(cart);
        }

        public IActionResult Submit(string customerName, string customerAddress, string customerPhone, string customerEmail, string customerComment)
        {
            var cart = cartsRepository.TryGetCartByUserId(constants.UserId);
            var newOrder = new Order(cart.TotalCost, cart.ProductsInCart, constants.UserId, customerName, customerAddress, customerPhone, customerEmail, customerComment);
            ordersRepository.CreateOrder(newOrder);
            return RedirectToAction("Success", new { orderId = newOrder.Id });
        }

        public IActionResult Success(int orderId)
        {
            cartsRepository.ClearCart(constants.UserId);
            var order = ordersRepository.TryToGetById(orderId);
            return View(order);
        }
    }
}
