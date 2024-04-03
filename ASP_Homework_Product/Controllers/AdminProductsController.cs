using ASP_Homework_Product.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using System;

namespace ASP_Homework_Product.Controllers
{
    public class AdminProductsController : Controller
    {
        private readonly IProductsRepository productsRepository;

        public AdminProductsController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public IActionResult Index()
        {
            return View(productsRepository);
        }

        public IActionResult Add(string name, string cost, string description)
        {
            var newProduct = new Product(name, Convert.ToDecimal(cost.Replace('.', ',')), description, "/images/in-process.png");
            productsRepository.Add(newProduct);
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int productId)
        {
            var product = productsRepository.TryGetById(productId);
            return View(product);
        }

        public IActionResult Replace(int productId, string name, string cost, string description)
        {
            productsRepository.Edit(productId, name, Convert.ToDecimal(cost.Replace('.', ',')), description);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int productId)
        {
            var product = productsRepository.TryGetById(productId);
            productsRepository.Remove(product);
            return RedirectToAction("Index");
        }
    }
}
