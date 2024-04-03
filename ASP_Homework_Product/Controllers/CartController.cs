using ASP_Homework_Product.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ASP_Homework_Product.Controllers
{
    public class CartController : Controller
    {
        private readonly Constants constants;
        private readonly ICartsRepository cartsRepository;
        private readonly IProductsRepository productsRepository;

        public CartController(Constants constants, ICartsRepository cartsRepository, IProductsRepository productsRepository)
        {
            this.constants = constants;
            this.cartsRepository = cartsRepository;
            this.productsRepository = productsRepository;
        }

        public IActionResult Index()
        {
            var cart = cartsRepository.TryGetCartByUserId(constants.UserId);
            return View(cart);
        }

        public IActionResult Add(int productId)
        {
            var product = productsRepository.TryGetById(productId);
            cartsRepository.AddToCart(product, constants.UserId);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int productId)
        {
            var product = productsRepository.TryGetById(productId);
            cartsRepository.RemoveFromCart(product, constants.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult RemoveAll(int productId)
        {
            var product = productsRepository.TryGetById(productId);
            cartsRepository.RemoveIdenticalFromCart(product, constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
