using Microsoft.AspNetCore.Mvc;

namespace ASP_Homework_Product.Controllers
{
    public class WishlistController : Controller
    {
        private readonly Constants constants;
        private readonly IWishlistsRepository wishlistsRepository;
        private readonly IProductsRepository productsRepository;

        public WishlistController(Constants constants, IWishlistsRepository wishlistsRepository, IProductsRepository productsRepository)
        {
            this.constants = constants;
            this.wishlistsRepository = wishlistsRepository;
            this.productsRepository = productsRepository;
        }

        public IActionResult Index()
        {
            var cart = wishlistsRepository.TryGetWishlistByUserId(constants.UserId);
            return View(cart);
        }

        public IActionResult Add(int productId)
        {
            var product = productsRepository.TryGetById(productId);
            wishlistsRepository.AddToWishlist(product, constants.UserId);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int productId)
        {
            var product = productsRepository.TryGetById(productId);
            wishlistsRepository.RemoveFromWishlist(product, constants.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult RemoveAll(int productId)
        {
            var product = productsRepository.TryGetById(productId);
            wishlistsRepository.RemoveIdenticalFromWishlist(product, constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
