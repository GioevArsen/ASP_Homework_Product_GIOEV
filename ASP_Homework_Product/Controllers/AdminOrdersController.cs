using Microsoft.AspNetCore.Mvc;

namespace ASP_Homework_Product.Controllers
{
    public class AdminOrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
