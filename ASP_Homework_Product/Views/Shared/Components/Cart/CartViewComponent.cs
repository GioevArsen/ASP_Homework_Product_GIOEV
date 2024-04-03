using Microsoft.AspNetCore.Mvc;

namespace ASP_Homework_Product.Views.Shared.Components.Cart
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartsRepository cartsRepository;
        private readonly Constants constants;

        public CartViewComponent(ICartsRepository cartsRepository, Constants constants)
        {
            this.cartsRepository = cartsRepository;
            this.constants = constants;
        }

        public IViewComponentResult Invoke()
        {
            var cart = cartsRepository.TryGetCartByUserId(constants.UserId);
            var itemCount = 0;
            if (cart != null)
            {
                itemCount = cart.ProductsInCart.Count;
            }
            return View("Cart", itemCount);
        }
    }
}
