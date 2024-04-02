using ASP_Homework_Product.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Homework_Product.Controllers
{
    public class ComparisonController : Controller
    {
        private readonly IProductsRepository productsRepository;

        public ComparisonController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public IActionResult Index(int productId, int compareId = -1)
        {
            var product = productsRepository.TryGetById(productId);
            Product comparableProduct;
            if(compareId > -1)
            {
                comparableProduct = productsRepository.TryGetById(compareId);
            }
            else
            {
                comparableProduct = productsRepository.TryGetById(productId);
            }
            var viewModel = new ComparisonItem(product, comparableProduct, productsRepository);
            return View(viewModel);
        }
    }
}
