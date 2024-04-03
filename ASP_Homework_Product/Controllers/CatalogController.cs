using ASP_Homework_Product.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ASP_Homework_Product.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IProductsRepository productsRepository;

        public CatalogController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public IActionResult Index()
        {
            return View(productsRepository);
        }

        public IActionResult Search(string query)
        {
            if (query != null)
            {
                var matchingProducts = new List<Product>();
                foreach (var product in productsRepository.Products)
                {
                    if (product.Name.ToLower().Contains(query.ToLower()))
                    {
                        matchingProducts.Add(product);
                    }
                }
                if (matchingProducts.Count > 0) return View(matchingProducts);
            }

            return RedirectToAction("Index");
        }
    }
}
