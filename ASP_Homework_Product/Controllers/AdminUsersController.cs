using Microsoft.AspNetCore.Mvc;

namespace ASP_Homework_Product.Controllers
{
    public class AdminUsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
