using Microsoft.AspNetCore.Mvc;

namespace ASP_Homework_Product.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult LogIn()
        {
            return View();
        }

        public IActionResult LogOut()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        public string CreateNewAccount(string name, string lastName, string email, string password, bool agreement)
        {
            return $"{name} {lastName} your account successfully created! Check the letter we send you to {email}.\n Your password: {password}.\n Aggrement: {agreement}";
        }

        public string LogIntoAccount(string login, string password, bool remember)
        {
            return $"{login} - {password} - {remember}";
        }
    }
}
