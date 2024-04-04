using Microsoft.AspNetCore.Mvc;
using System.Linq;

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

        public string CreateNewAccount(string name, string lastName, string phone, string email, string newPassword, string newPassportConfirmation, bool agreement)
        {
            if(agreement == false)
            {
                ModelState.AddModelError("", "Please read and agree to our privacy policy");
            } 
            else if (name == newPassword || lastName == newPassword)
            {
                ModelState.AddModelError("", "Please make sure your password doesn't match your name or lastname");
            }

            if(ModelState.IsValid)
            {
                return $"{name} {lastName} your account successfully created! Check the letter we send you to {email} and {phone}.\nYour password: {newPassword}.\nAggrement: {agreement}";
            }

            return string.Join("\n", ModelState.Values
                                        .SelectMany(v => v.Errors)
                                        .Select(e => e.ErrorMessage)); ;
        }

        public string LogIntoAccount(string email, string password, bool remember)
        {
            if (ModelState.IsValid)
            {
                return $"You logged in successfully \n{email} - {password} - {remember}";
            }

            return $"Something went wrong";
        }
    }
}
